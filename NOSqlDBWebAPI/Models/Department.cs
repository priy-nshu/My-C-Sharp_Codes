using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace NOSqlDBWebAPI.Models
{
    public class Department
    {
        [JsonProperty("name")]
        public string Name{get; set;}
    }
}
