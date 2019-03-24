using Newtonsoft.Json;

namespace HeimkaupLib.Models
{
    public class Attribute
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
