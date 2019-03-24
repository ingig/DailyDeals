using Newtonsoft.Json;
using System.Collections.Generic;

namespace HeimkaupLib.Models
{
    public class AvailableFilter
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("translatable")]
        public bool Translatable { get; set; }

        [JsonProperty("options")]
        public List<Option> Options { get; set; }
    }
}
