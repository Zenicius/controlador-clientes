using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using API.Context;
using API.Filters;
using API.Models;
using API.Repository;

namespace API.Controllers
{
    public class ClientesController : ApiController
    {
        private readonly IClienteRepository _clienteRepository;

        public ClientesController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        // GET: api/clientes
        public async Task<List<Cliente>> Get()
        {
            return await _clienteRepository.GetAll();
        }

        // GET: api/clientes/{id}
        public async Task<IHttpActionResult> Get(long Id)
        {
            var cliente = await _clienteRepository.GetClienteById(Id);

            if (cliente == null)
                return NotFound();

            return Ok(cliente); 
        }

        // POST: api/clientes
        [ValidateModel]
        public async Task<Cliente> Post(Cliente cliente)
        {
            await _clienteRepository.Add(cliente);

            return cliente;
        }

        // PUT: api/clientes
        [ValidateModel]
        public async Task<IHttpActionResult> Put([FromBody] Cliente cliente)
        {
            var updated = await _clienteRepository.Update(cliente);

            if (!updated)
                return NotFound();

            return Ok(cliente);
        }

        // DELETE: api/clientes/{id}
        public async Task<IHttpActionResult> Delete(long Id)
        {
            var deleted = await _clienteRepository.DeleteClienteById(Id); 

            if (!deleted)
                return NotFound();

            return Ok();
        }
    }
}