using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Threading.Tasks;
using WCFServiceHost.Context;
using WCFServiceHost.Models;

namespace WCFServiceHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ClienteService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ClienteService.svc or ClienteService.svc.cs at the Solution Explorer and start debugging.
    public class ClienteService : ICliente
    {
        private ClienteContext _context = new ClienteContext();

        public async Task<Cliente> Add(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return cliente;
        }

        public async Task<bool> DeleteClienteById(long id)
        { 
            var toRemove = _context.Clientes.Find(id);

            if (toRemove == null)
                return false;

            _context.Clientes.Remove(toRemove);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<Cliente>> GetAll()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetClienteById(long id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<Cliente> Update(Cliente cliente)
        {
            _context.Clientes.AddOrUpdate(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }
    }
}
