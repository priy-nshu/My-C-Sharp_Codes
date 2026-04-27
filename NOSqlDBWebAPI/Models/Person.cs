using System.Text.Json.Serialization;

namespace NOSqlDBWebAPI.Models
{
    public class Person
    {
        public string? Id { get; set; }
        [JsonPropertyName("firstname")]
        public string firstName { get; set; } = null;
        public int? age { get;set;  }
    }
}
