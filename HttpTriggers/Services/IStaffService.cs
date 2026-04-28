using HttpTriggers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpTriggers.Services
{
    public interface IStaffService
    {
        Task<List<Staff>> GetAllStaffs();
    }
}
