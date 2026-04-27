using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace NOSqlDBWebAPI.Models
{
    public class Name
    {
        [JsonProperty("first")]
        public string First { get; set; }

        [JsonProperty("last")]
        public string Last { get; set; }

    }
}
