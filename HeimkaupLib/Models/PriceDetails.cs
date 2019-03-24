using Newtonsoft.Json;
using System;

namespace HeimkaupLib.Models
{
    public class PriceDetails
    {
        [JsonProperty("original_price")]
        public double OriginalPrice { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("discount")]
        public double Discount { get; set; }

        [JsonProperty("discount_percentage")]
        public double DiscountPercentage { get; set; }

        [JsonProperty("discount_end_time")]
        public DateTime? DiscountEndTime { get; set; }

        [JsonProperty("price_per_unit")]
        public double? PricePerUnit { get; set; }
    }
}
