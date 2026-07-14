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
    public class GeneroAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GeneroAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/GeneroAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenerosDTO>>> GetGeneros()
        {
            return await _context.Generos
                                  .Select(c => new GenerosDTO {
                                      Id = c.Id,
                                      NomeGenero = c.NomeGenero
                                  })
                                  .ToListAsync();
        }

        // GET: api/GeneroAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GenerosSimplerDTO>> GetGenero(int id)
        {
            var genero = await _context.Generos
                                        .Where(c => c.Id == id)
                                        .Select(c => new GenerosSimplerDTO {
                                            NomeGenero = c.NomeGenero
                                        })
                                        .FirstOrDefaultAsync();

            if (genero == null)
            {
                return NotFound();
            }

            return genero;
        }

        //// PUT: api/GeneroAPI/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutGenero(int id, Genero genero)
        //{
        //    if (id != genero.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(genero).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!GeneroExists(id))
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

        // POST: api/GeneroAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Genero>> PostGenero(Genero genero)
        {
            _context.Generos.Add(genero);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGenero", new { id = genero.Id }, genero);
        }

        //// DELETE: api/GeneroAPI/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteGenero(int id)
        //{
        //    var genero = await _context.Generos.FindAsync(id);
        //    if (genero == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Generos.Remove(genero);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool GeneroExists(int id)
        {
            return _context.Generos.Any(e => e.Id == id);
        }
    }
}
