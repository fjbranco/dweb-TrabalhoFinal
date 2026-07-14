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
    public class SalasAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SalasAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SalasAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalasDTO>>> GetSalas()
        {
            return await _context.Salas
                                  .Select(s => new SalasDTO {
                                      Id = s.Id,
                                      Nome = s.Nome,
                                      Localidade = s.Localidade
                                  })
                                  .ToListAsync();
        }

        // GET: api/SalasAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SalasSimplerDTO>> GetSala(int id)
        {
            var sala = await _context.Salas
                                     .Where(s => s.Id == id)
                                     .Select(s => new SalasSimplerDTO {
                                         Nome = s.Nome,
                                         Localidade = s.Localidade
                                     })
                                     .FirstOrDefaultAsync();

            if (sala == null)
            {
                return NotFound();
            }

            return sala;
        }

        // PUT: api/SalasAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSala(int id, Sala sala)
        {
            if (id != sala.Id)
            {
                return BadRequest();
            }

            _context.Entry(sala).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/SalasAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sala>> PostSala(Sala sala)
        {
            _context.Salas.Add(sala);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSala", new { id = sala.Id }, sala);
        }

        // DELETE: api/SalasAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSala(int id)
        {
            var sala = await _context.Salas.FindAsync(id);
            if (sala == null)
            {
                return NotFound();
            }

            _context.Salas.Remove(sala);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SalaExists(int id)
        {
            return _context.Salas.Any(e => e.Id == id);
        }
    }
}
