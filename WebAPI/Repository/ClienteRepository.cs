using API.Context;
using API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace API.Repository
{
    public interface IClienteRepository : IDisposable
    {
        Task<List<Cliente>> GetAll();   
        Task<Cliente> GetClienteById(long id);
        Task<bool> Add(Cliente cliente);
        Task<bool> Update(Cliente cliente);
        Task<bool> DeleteClienteById(long id);
    }

    public class ClienteRepository : IClienteRepository
    {
        private ClienteContext _context = new ClienteContext();

        public async Task<List<Cliente>> GetAll()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task<Cliente> GetClienteById(long id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<bool> Add(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(Cliente cliente)
        {
            var toUpdate = _context.Clientes.Find(cliente.Id);
            if (toUpdate == null)
                return false;

            _context.Clientes.AddOrUpdate(cliente);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteClienteById(long id)
        {
            var toRemove = _context.Clientes.Find(id);

            if (toRemove == null)
                return false;

            _context.Clientes.Remove(toRemove);
            return await _context.SaveChangesAsync() > 0;
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if(_context != null)
                {
                    _context.Dispose();
                    _context = null;
                } 
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}