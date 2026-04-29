using QueueTriggers.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueTriggers.Services
{
    public class StaffService :IStaffService
    {
        private readonly QueueDbContext _context;

        public StaffService(QueueDbContext context)
        {
            _context = context;
        }

        public async Task AddStaff(Staff staff)
        {
            _context.Staff.Add(staff);
            await _context.SaveChangesAsync();
        }
    }
}
