using Newtonsoft.Json;
using System.Collections.Generic;

namespace HeimkaupLib.Models
{
    public class Data
    {
        [JsonProperty("products")]
        public List<Product> Products { get; set; }

        [JsonProperty("total_records")]
        public long TotalRecords { get; set; }

        [JsonProperty("available_filters")]
        public List<AvailableFilter> AvailableFilters { get; set; }
    }
}
