using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Options;
using NOSqlDBWebAPI.Models;
using NOSqlDBWebAPI.Services;

namespace NOSqlDBWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // OLD: Direct Cosmos dependencies
        // public CosmosClient cosmosDbClient;
        // private readonly CosmosDbSettings _setting;
        // private readonly Container container;

        private readonly IEmployeeService _employeeService;

        // OLD Constructor:
        // public EmployeeController(CosmosClient client, IConfiguration config)
        // {
        //     container = client.GetContainer(config["CosmosCon:DatabaseName"], config["CosmosCon:ContainerName"]);
        // }
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeModel employee)
        {
            try
            {
                // OLD:
                // var response = await container.CreateItemAsync(item: employee, partitionKey: new PartitionKey(employee.EmpDepartment.Name));
                // return Ok(response);

                var response = await _employeeService.AddEmployees(employee);
                return Ok(response.Resource);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeeDetails()
        {
            try
            {
                // OLD:
                // var sqlQuery = "SELECT * FROM c";
                // QueryDefinition queryDefinition = new QueryDefinition(sqlQuery);
                // FeedIterator<dynamic> queryResultSetIterator = container.GetItemQueryIterator<dynamic>(queryDefinition);
                // List<EmployeeModel> employees = new List<EmployeeModel>();
                // while (queryResultSetIterator.HasMoreResults)
                // {
                //     FeedResponse<dynamic> currentResultSet = await queryResultSetIterator.ReadNextAsync();
                //     foreach (var items in currentResultSet)
                //     {
                //         EmployeeModel emp = new EmployeeModel { ... };
                //         employees.Add(emp);
                //     }
                // }
                // return Ok(employees);

                var employees = await _employeeService.GetEmployees();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{empId}/{partitionKey}")]
        public async Task<IActionResult> GetEmployeeDetailsById(string empId, string partitionKey)
        {
            try
            {
                // OLD:
                // ItemResponse<EmployeeModel> response = await container.ReadItemAsync<EmployeeModel>(empId, new PartitionKey(partitionKey));
                // return Ok(response.Resource);

                var response = await _employeeService.GetEmployeeById(empId, partitionKey);
                return Ok(response.Resource);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeModel employee, [FromQuery] string partitionKey)
        {
            try
            {
                // OLD:
                // ItemResponse<EmployeeModel> res = await container.ReadItemAsync<EmployeeModel>(employee.EmployeeId, new PartitionKey(partitionKey));
                // var existingItem = res.Resource;
                // existingItem.EmployeeName.First = employee.EmployeeName.First;
                // existingItem.EmployeeName.Last = employee.EmployeeName.Last;
                // existingItem.Email = employee.Email;
                // existingItem.EmpDepartment.Name = employee.EmpDepartment.Name;
                // var updateRes = await container.ReplaceItemAsync(existingItem, employee.EmployeeId, new PartitionKey(partitionKey));
                // return Ok(updateRes.Resource);

                var response = await _employeeService.UpdateEmployee(employee, partitionKey);
                return Ok(response.Resource);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(string employeeId, string partitionKey)
        {
            try
            {
                // OLD:
                // var response = await container.DeleteItemAsync<EmployeeModel>(employeeId, new PartitionKey(partitionKey));
                // return Ok(response.Resource);

                var response = await _employeeService.DeleteEmployee(employeeId, partitionKey);
                return Ok(response.Resource);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}