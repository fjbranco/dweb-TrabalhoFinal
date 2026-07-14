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
    public class BilhetesAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BilhetesAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/BilhetesAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BilhetesDTO>>> GetBilhetes()
        {
            return await _context.Bilhetes
                                  .Select(c => new BilhetesDTO {
                                      Id = c.Id,
                                      DataCompra = c.DataCompra
                                  })
                                  .ToListAsync();
        }

        // GET: api/BilhetesAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BilhetesSimplerDTO>> GetBilhete(int id)
        {
            var bilhete = await _context.Bilhetes
                                        .Where(c => c.Id == id)
                                        .Select(c => new BilhetesSimplerDTO {
                                            DataCompra = c.DataCompra
                                        })
                                        .FirstOrDefaultAsync();

            if (bilhete == null)
            {
                return NotFound();
            }

            return bilhete;
        }

        // PUT: api/BilhetesAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBilhete(int id, Bilhete bilhete)
        {
            if (id != bilhete.Id)
            {
                return BadRequest();
            }

            _context.Entry(bilhete).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BilheteExists(id))
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

        // POST: api/BilhetesAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Bilhete>> PostBilhete(Bilhete bilhete)
        {
            _context.Bilhetes.Add(bilhete);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBilhete", new { id = bilhete.Id }, bilhete);
        }

        // DELETE: api/BilhetesAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBilhete(int id)
        {
            var bilhete = await _context.Bilhetes.FindAsync(id);
            if (bilhete == null)
            {
                return NotFound();
            }

            _context.Bilhetes.Remove(bilhete);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BilheteExists(int id)
        {
            return _context.Bilhetes.Any(e => e.Id == id);
        }
    }
}
