using API.Models;
using System.Data.Entity;

namespace API.Context
{
    public class ClienteContext : DbContext
    {
        public ClienteContext()
            :base ("ClienteDB")
        {

        }

        public DbSet<Cliente> Clientes { get; set; }    
    }
}