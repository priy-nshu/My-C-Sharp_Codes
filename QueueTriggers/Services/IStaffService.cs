using QueueTriggers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueTriggers.Services
{
    public interface IStaffService
    {
        Task AddStaff(Staff staff);
    }
}
