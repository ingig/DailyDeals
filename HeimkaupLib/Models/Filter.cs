using Newtonsoft.Json;
using System.Collections.Generic;

namespace HeimkaupLib.Models
{
    public class Filter
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("values")]
        public List<Value> Values { get; set; }
    }
}
