using Newtonsoft.Json;

namespace HeimkaupLib.Models
{
    public class Datum
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("parent_id")]
        public object ParentId { get; set; }

        [JsonProperty("has_children")]
        public long HasChildren { get; set; }

        [JsonProperty("allow_add_to_cart_from_band")]
        public long AllowAddToCartFromBand { get; set; }
    }
}