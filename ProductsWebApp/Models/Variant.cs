using Newtonsoft.Json;

namespace ProductsWebApp.Models
{
    public class Variant
    {
        [JsonProperty("sku")]
        public string Sku { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}