using DailyDeals.Logic;
using HeimkaupLib.Models;
using HeimkaupLib.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using System.Linq;

namespace DailyDealWeb.Pages
{

    [ValidateAntiForgeryToken]
    public class IndexModel : PageModel
    {
        public Dictionary<string, List<Product>> Products;
        public string SubscribedInfo;

        public void OnGet()
        {
            Dictionary<string, SearchResponse> result = new HeimkaupService(Startup.ApiKey).GetAllByCategory().Result;
            Products = new Dictionary<string, List<Product>>();
            foreach (KeyValuePair<string, SearchResponse> keyValuePair in result)
            {
                List<Product> list = keyValuePair.Value.Data.Products.Where(p => p.PriceDetails.Discount > 0.0).ToList();
                Products.Add(keyValuePair.Key, list);
            }
            string unsubscribe = Request.Query["unsub"];
            if (unsubscribe != null)
            {
                new Subscriptions().Unsubscribe(int.Parse(Request.Query["id"]), Request.Query["email"]);
                SubscribedInfo = "Þú ert núna afskráður af listanum";
            }
        }

        [BindProperty]
        public string email { get; set; }

        
        public void OnPost()
        {
            if (new Subscriptions().Subscribe(Request.Form["email"]))
                SubscribedInfo = "Þú ert núna skráð(ur) á póstlistann.";

            OnGet();
        }

    }
}