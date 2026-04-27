using Newtonsoft.Json;

namespace ProductsWebApp.Models
{
    public class Attributes
    {
        [JsonProperty("processor")]
        public string Processor { get; set; }

        [JsonProperty("ram")]
        public string Ram { get; set; }

        [JsonProperty("storage")]
        public string Storage { get; set; }

        [JsonProperty("displaySize")]
        public string DisplaySize { get; set; }
    }
}