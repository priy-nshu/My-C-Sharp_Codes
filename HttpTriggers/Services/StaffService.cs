using HttpTriggers.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpTriggers.Services
{
    public class StaffService :IStaffService
    {
        private readonly BykeStoresContext context;

        public StaffService(BykeStoresContext context)
        {
            this.context = context;
        }

        public async Task<List<Staff>> GetAllStaffs()
        {
            var staffs= await context.Staffs.Take(10).ToListAsync();
            return staffs;
        }
       
    }
}
