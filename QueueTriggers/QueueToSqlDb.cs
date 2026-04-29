using Azure.Storage.Queues.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using QueueTriggers.Models;
using QueueTriggers.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace QueueTriggers
{
    public class QueueToSqlDb
    {
        private readonly ILogger<QueueToSqlDb> _logger;
        private readonly IStaffService _staffService;

        public QueueToSqlDb(ILogger<QueueToSqlDb> logger, IStaffService staffService)
        {
            _logger = logger;
            _staffService = staffService;
        }

        [Function("QueueToSqlDb")]
        public async Task Run([QueueTrigger("staff-queue", Connection = "QueueCon")] string message)
        {
            _logger.LogInformation($"C# Queue trigger function processed: {message}");

            try
            {
                var staffRecord = JsonConvert.DeserializeObject<Staff>(message);

                if (staffRecord != null)
                {
                    await _staffService.AddStaff(staffRecord);
                    _logger.LogInformation("Successfully saved staff record to the database.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error saving to DB: {ex.Message}");
            }
        }
    }
}
