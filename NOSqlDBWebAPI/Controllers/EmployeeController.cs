using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;
using NOSqlDBWebAPI.Models;

namespace NOSqlDBWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public CosmosClient cosmosDbClient;
        private readonly CosmosDbSettings _setting;
        private readonly Container container;
        
        public EmployeeController(CosmosClient client,IOptions<CosmosDbSettings> options)
        {
            cosmosDbClient = client;
            _setting = options.Value;
            container = cosmosDbClient.GetContainer(_setting.DatabaseName, _setting.ContainerName);
        }

        //[HttpPost]
        //public async Task<IActionResult> AddEmployee([FromBody]EmployeeModel employee)
        //{
            
        //}

        [HttpGet]
        public async Task<IActionResult> GetEmployeeDetails()
        {
            try
            {
                var sqlQuery = "SELECT * FROM c";
                QueryDefinition queryDefinition = new QueryDefinition(sqlQuery);
                FeedIterator<dynamic> queryResultSetIterator = container.GetItemQueryIterator<dynamic>(queryDefinition);
                List<EmployeeModel> employees = new List<EmployeeModel>();

                while (queryResultSetIterator.HasMoreResults)
                {
                    FeedResponse<dynamic> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                    foreach (var items in currentResultSet)
                    {
                        EmployeeModel emp = new EmployeeModel
                        {
                            EmployeeId = items.EmployeeId,
                            EmployeeName = new Name
                            {
                                First = items.name.first,
                                Last = items.name.last
                            },
                            Email = items.email,
                            EmpDepartment = new Department
                            {
                                Name = items.department.name
                            }
                           
                        };
                        employees.Add(emp);
                    }
                }
                return Ok(employees);
                    }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
    }
}
