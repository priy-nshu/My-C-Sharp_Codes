using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace NOSqlDBWebAPI.Models
{
    using Newtonsoft.Json;

    public class EmployeeModel
    {
        [JsonProperty("id")]
        public string EmployeeId { get; set; }

        [JsonProperty("name")]
        public Name EmployeeName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("department")]
        public Department EmpDepartment { get; set; }
    }
}
