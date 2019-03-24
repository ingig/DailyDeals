using Newtonsoft.Json;

namespace HeimkaupLib.Models
{
    public class Option
    {
        [JsonProperty("minimum")]
        public long? Minimum { get; set; }

        [JsonProperty("maximum")]
        public long? Maximum { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("number_of_results")]
        public long NumberOfResults { get; set; }

        [JsonProperty("order")]
        public object Order { get; set; }
    }
}
