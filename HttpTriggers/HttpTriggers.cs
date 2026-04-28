using HttpTriggers.Models;
using HttpTriggers.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace HttpTriggers;

public class HttpTriggers
{
    private readonly ILogger<HttpTriggers> _logger;

    private IStaffService staffService;
    private IGradeService gradeService;
    private ICustomerService customerService;
    public HttpTriggers(ILogger<HttpTriggers> logger,IStaffService service,IGradeService gradeService,ICustomerService customerService)
    {
        _logger = logger;
        staffService = service;
        this.gradeService=gradeService;
        this.customerService = customerService;
    }

[Function("GetAllStaffs")]
    public async Task<IActionResult> GetAllStaffs([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        var staff = await staffService.GetAllStaffs();
        return new OkObjectResult(staff);
    }
    [Function("GetAllGrades")]
    public async Task<IActionResult> GetAllGrades([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");
            var grades = await gradeService.GetAllGrades();
            return new OkObjectResult(grades);
        }
    //[Function("GetAllStudents")]
    //public async Task<IActionResult> GetAllStudents([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
    //{
    //    _logger.LogInformation("C# HTTP trigger function processed a request.");
    //    var students = await staffService.GetAllStudents();
    //    return new OkObjectResult(students);
    //}
    [Function("GetAllCustomers")]
    public async Task<IActionResult> GetAllCustomers([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        var customers = await customerService.GetCustomers();
        return new OkObjectResult(customers);
    }
    [Function("GetCustomersById")]
    public async Task<IActionResult> GetCustomersById([HttpTrigger(AuthorizationLevel.Anonymous, "get",Route = "customers/{id}")] HttpRequest req,string id)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        var customers = await customerService.GetCustomersById(Convert.ToInt32(id));
        return new OkObjectResult(customers);
    }
    [Function("PostCustomers")]
    public async Task<IActionResult> PostCustomers([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "customers")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        var result = JsonSerializer.Deserialize<Customer>(requestBody);
        var customers = await customerService.PostCustomers(result);
        return new OkObjectResult(customers);
    }
}
