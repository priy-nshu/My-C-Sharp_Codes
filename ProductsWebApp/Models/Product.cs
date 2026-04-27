using Newtonsoft.Json;

namespace ProductsWebApp.Models
{
    public class Product
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("SubCategory")]
        public string SubCategory { get; set; }

        [JsonProperty("brand")]
        public string Brand { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("attributes")]
        public Attribute? Attributes { get; set; }

        [JsonProperty("variants")]
        public List<Variant>? Variants { get; set; } = new();
    }
}
