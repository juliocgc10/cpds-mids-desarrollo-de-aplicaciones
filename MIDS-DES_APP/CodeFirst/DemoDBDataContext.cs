using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public class DemoDBDataContext : DbContext
    {
        public DemoDBDataContext() : base("DemoDBConnectionString")
        {            
        }

        public DbSet<Person> Person { get; set; }

    }
}
