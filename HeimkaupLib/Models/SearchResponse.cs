using Newtonsoft.Json;

namespace HeimkaupLib.Models
{
    public class SearchResponse
    {
        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}
