using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WCFServiceHost.Models;

namespace WCFServiceHost.Context
{
    public class ClienteContext : DbContext
    {
        public ClienteContext()
            : base("ClienteDB")
        {

        }

        public DbSet<Cliente> Clientes { get; set; }   
    }
}