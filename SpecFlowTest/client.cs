using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowTest
{
    public class SpecFlowTestContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
    }

    public class Client
    {
        public int ClientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
