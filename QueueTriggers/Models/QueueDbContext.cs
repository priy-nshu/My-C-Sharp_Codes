using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueTriggers.Models
{
    public class QueueDbContext :DbContext
    {
        public QueueDbContext(DbContextOptions<QueueDbContext> options) : base(options) { }

        public DbSet<Staff> Staff { get; set; }
    }
}
