using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dweb_TrabalhoFinal.Data;
using ModeloDados.Models;
using Dweb_TrabalhoFinal.Models.ViewModels;

namespace Dweb_TrabalhoFinal.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClientesAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ClientesAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClientesDTO>>> GetClientes()
        {
            return await _context.Clientes
                                  .Select(c => new ClientesDTO {
                                      Id = c.Id,
                                      Nome = c.Nome
                                  })
                                  .ToListAsync();
        }

        // GET: api/ClientesAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ClientesSimplerDTO>> GetCliente(int id)
        {
            var cliente = await _context.Clientes
                                         .Where(c => c.Id == id)
                                         .Select(c => new ClientesSimplerDTO {
                                             Nome = c.Nome
                                         })
                                         .FirstOrDefaultAsync();

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        //// PUT: api/ClientesAPI/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        //{
        //    if (id != cliente.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(cliente).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ClienteExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/ClientesAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCliente", new { id = cliente.Id }, cliente);
        }

        //// DELETE: api/ClientesAPI/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCliente(int id)
        //{
        //    var cliente = await _context.Clientes.FindAsync(id);
        //    if (cliente == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Clientes.Remove(cliente);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }
    }
}
