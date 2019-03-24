using Newtonsoft.Json;
using System.Collections.Generic;

namespace HeimkaupLib.Models
{
    public class CategoryResponse
    {
        [JsonProperty("data")]
        public List<Datum> Data { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}
