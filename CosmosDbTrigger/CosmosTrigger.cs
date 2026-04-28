using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;  
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace CosmosDbTrigger;

public class CosmosTrigger
{
    private readonly ILogger<CosmosTrigger> _logger;

    public CosmosTrigger(ILogger<CosmosTrigger> logger)
    {
        _logger = logger;
    }

    [Function("Function1")]
    public void Run([CosmosDBTrigger(
        databaseName: "cosmicworks",
        containerName: "employee",
        Connection = "cosmicworkCon",
        LeaseContainerName = "leases",
        CreateLeaseContainerIfNotExists = false)]  
        IReadOnlyList<Employee> input)
    {
        if (input != null && input.Count > 0)
        {
            _logger.LogInformation("Documents modified: " + input.Count);
            _logger.LogInformation("First document Id: " + input[0].Id);
            _logger.LogInformation("First document Name: " + input[0].Name);
        }
    }
}

public class Employee
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("name")]
    public EmployeeName? Name { get; set; }        

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("department")]
    public Department? Department { get; set; }    
}

public class EmployeeName
{
    [JsonPropertyName("first")]
    public string? First { get; set; }

    [JsonPropertyName("last")]
    public string? Last { get; set; }
}

public class Department
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }
}
public class MyDocument
{
    public string id { get; set; }

    public string Text { get; set; }

    public int Number { get; set; }

    public bool Boolean { get; set; }
}