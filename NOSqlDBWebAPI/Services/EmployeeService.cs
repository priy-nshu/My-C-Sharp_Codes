using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;
//using Microsoft.Azure.Cosmos.Serialization.HybridRow.Schemas;
using NOSqlDBWebAPI.Models;

namespace NOSqlDBWebAPI.Services
{
    public class EmployeeService : IEmployeeService
    {

        public CosmosClient cosmosDbClient;
        private readonly CosmosDbSettings _setting;
        private readonly Container container;

        public EmployeeService(CosmosClient client, IConfiguration config)
        {
            //cosmosDbClient = client;
            //_setting = options.Value;
            //container = cosmosDbClient.GetContainer(_setting.DatabaseName, _setting.ContainerName);
            container = client.GetContainer(config["CosmosCon:DatabaseName"], config["CosmosCon:ContainerName"]);
        }


        public async Task<IList<EmployeeModel>> GetEmployees()
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
                            EmployeeId = items.id,
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
                return employees;
            }
            catch (Exception ex) { throw ex; }
        }
        public async Task<ItemResponse<EmployeeModel>> GetEmployeeById(string EmpId, string partitionKey)
        {
            try
            {

                ItemResponse<EmployeeModel> response = await container.ReadItemAsync<EmployeeModel>(EmpId, new PartitionKey(partitionKey));
                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public async Task<ItemResponse<EmployeeModel>> AddEmployees([FromBody]EmployeeModel employee)
        {
            try
            {
                var response = await container.CreateItemAsync(item: employee, partitionKey: new PartitionKey(employee.EmpDepartment.Name));
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<ItemResponse<EmployeeModel>> UpdateEmployee(EmployeeModel employee, string partitionKey)
        {

            try
            {
                ItemResponse<EmployeeModel> res = await container.ReadItemAsync<EmployeeModel>(employee.EmployeeId,
                                                                                                    new PartitionKey(partitionKey));
                var existingItem = res.Resource;

                existingItem.EmployeeName.First = employee.EmployeeName.First;
                existingItem.EmployeeName.Last = employee.EmployeeName.Last;
                existingItem.Email = employee.Email;
                existingItem.EmpDepartment.Name = employee.EmpDepartment.Name;

                var updateRes = await container.ReplaceItemAsync(existingItem, employee.EmployeeId, new PartitionKey(partitionKey));

                return updateRes;
            }
            catch (Exception e)
            {
               throw;
            }
        }
        public async Task<ItemResponse<EmployeeModel>> DeleteEmployee(string employeeId, string partitionKey)
        {
            try
            {
                var response = await container.DeleteItemAsync<EmployeeModel>(employeeId, new PartitionKey(partitionKey));
                return response;
            }
            catch (Exception e)
            {
               throw;
            }
        }
    }
}
