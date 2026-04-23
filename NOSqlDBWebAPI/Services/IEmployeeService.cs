using Microsoft.Azure.Cosmos;
using NOSqlDBWebAPI.Models;

namespace NOSqlDBWebAPI.Services
{
    public interface IEmployeeService
    {
        Task<IList<EmployeeModel>> GetEmployees();
        Task<ItemResponse<EmployeeModel>> GetEmployeeById(string EmpId, string partitionKey);
        Task<ItemResponse<EmployeeModel>> AddEmployees(EmployeeModel employee);
        Task<ItemResponse<EmployeeModel>> UpdateEmployee(EmployeeModel employee,string partitionKey);
        Task<ItemResponse<EmployeeModel>> DeleteEmployee(string employeeId,string partitionKey);
    }
}
