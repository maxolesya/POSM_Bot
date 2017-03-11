using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace TryToBuildBot
{
    class Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public Context():base("localsql")
        {
        }
    }
}
