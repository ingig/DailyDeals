using Newtonsoft.Json;

namespace HeimkaupLib.Models
{
    public class Value
    {
        [JsonProperty("exclude")]
        public bool Exclude { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("value")]
        public string ValueValue { get; set; }
    }
}
