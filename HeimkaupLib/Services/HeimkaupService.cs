// Decompiled with JetBrains decompiler
// Type: HeimkaupLib.Service.HeimkaupService
// Assembly: HeimkaupLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 217F18A5-984F-4386-AA97-5BF5D17900D7
// Assembly location: C:\Users\ingi.ragnarsson\source\repos\Restore\HeimkaupLib.dll

using HeimkaupLib.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace HeimkaupLib.Service
{
    public class HeimkaupService : IHeimkaupService
    {
        private string apiKey;

        public HeimkaupService(string apiKey)
        {
            this.apiKey = apiKey;
        }

        public List<Filter> GetFilters(List<int> categoryIds, bool exclude)
        {
            List<Filter> filterList = new List<Filter>();
            List<Value> objList = new List<Value>();
            foreach (int categoryId in categoryIds)
            {
                objList.Add(new Value()
                {
                    Exclude = exclude,
                    Type = "int",
                    ValueValue = categoryId.ToString()
                });
            }

            filterList.Add(new Filter()
            {
                Name = "category_ids",
                Values = objList
            });
            return filterList;
        }

        public async Task<Dictionary<string, SearchResponse>> GetAllByCategory()
        {
            MemoryCache mc = MemoryCache.Default;
            if (mc["products"] != null)
                return (Dictionary<string, SearchResponse>)mc["products"];

            Dictionary<string, SearchResponse> searches = new Dictionary<string, SearchResponse>();
            foreach (var category in GetCategories().Result.Data)
            {
                searches.Add(category.Name, 
                        await GetProductsOnDiscount(new List<int>()
                                                        {
                                                          (int) category.Id
                                                        }, false));
            }

            mc.Add("products", searches, new CacheItemPolicy()
            {
                AbsoluteExpiration = new DateTimeOffset(DateTime.Now.AddMinutes(120))
            }, null);
            return searches;
        }

        public async Task<SearchResponse> GetProductsOnDiscount(List<int> categoryIds, bool exclude)
        {
            Uri requestUri = new Uri("https://www.heimkaup.is/api/v1/product/search");
            SearchResponse searchResponse = null;
            using (HttpClient client = new HttpClient())
            {
                StringContent stringContent = new StringContent(JsonConvert.SerializeObject(new SearchRequest()
                {
                    Page = 1,
                    PerPage = 100,
                    Query = "*",
                    SortBy = "-discount_percentage",
                    Filters = GetFilters(categoryIds, exclude)
                }), Encoding.UTF8, "application/json");

                client.DefaultRequestHeaders.Add("api-key", apiKey);
                using (HttpContent responseContent = client.PostAsync(requestUri, stringContent).Result.Content)
                    searchResponse = JsonConvert.DeserializeObject<SearchResponse>(await responseContent.ReadAsStringAsync());
            }
            return searchResponse;
        }

        public async Task<CategoryResponse> GetCategories()
        {
            Uri requestUri = new Uri("https://www.heimkaup.is/api/v1/category/get-list/0");
            CategoryResponse categoryResponse = null;
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("api-key", apiKey);
                using (HttpContent responseContent = client.GetAsync(requestUri).Result.Content)
                    categoryResponse = JsonConvert.DeserializeObject<CategoryResponse>(await responseContent.ReadAsStringAsync());
            }
            return categoryResponse;
        }
    }
}
