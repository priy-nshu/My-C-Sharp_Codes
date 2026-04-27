using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace HttpTriggers;

public class HttpTriggers
{
    private readonly ILogger<HttpTriggers> _logger;

    public HttpTriggers(ILogger<HttpTriggers> logger)
    {
        _logger = logger;
    }

    [Function("GetAllStaffs")]
    public IActionResult GetAllStaffs([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        return new OkObjectResult("Welcome to Azure Functions!");
    }
}