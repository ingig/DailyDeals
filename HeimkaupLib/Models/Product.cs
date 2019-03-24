using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace HeimkaupLib.Models
{
    public class Product
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("variant_id")]
        public long VariantId { get; set; }

        [JsonProperty("sister_variant_ids")]
        public List<long> SisterVariantIds { get; set; }

        [JsonProperty("number_of_variants")]
        public long NumberOfVariants { get; set; }

        [JsonProperty("shopping_cart_item_count")]
        public long ShoppingCartItemCount { get; set; }

        [JsonProperty("slug")]
        public string Slug { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("image_url")]
        public Uri ImageUrl { get; set; }

        [JsonProperty("price_details")]
        public PriceDetails PriceDetails { get; set; }

        [JsonProperty("is_in_wish_list")]
        public bool IsInWishList { get; set; }

        [JsonProperty("is_free_shipment")]
        public bool IsFreeShipment { get; set; }

        [JsonProperty("is_e_delivery")]
        public bool? IsEDelivery { get; set; }

        [JsonProperty("sale_type")]
        public string SaleType { get; set; }

        [JsonProperty("sale_unit")]
        public string SaleUnit { get; set; }

        [JsonProperty("measure")]
        public string Measure { get; set; }

        [JsonProperty("rating")]
        public double Rating { get; set; }

        [JsonProperty("rating_count")]
        public long RatingCount { get; set; }

        [JsonProperty("has_price_protection")]
        public bool HasPriceProtection { get; set; }

        [JsonProperty("brand_logo")]
        public string BrandLogo { get; set; }

        [JsonProperty("brand_url")]
        public string BrandUrl { get; set; }

        [JsonProperty("brand_name")]
        public string BrandName { get; set; }

        [JsonProperty("attributes")]
        public List<Attribute> Attributes { get; set; }
    }
}
