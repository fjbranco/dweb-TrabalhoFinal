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
    public class SessaoAPIController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SessaoAPIController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/SessaoAPI
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SessoesDTO>>> GetSessoes()
        {
            //return await _context.Sessoes.ToListAsync();

            return await _context.Sessoes
                                  .Select(c => new SessoesDTO {
                                      Id = c.Id,
                                      DataSessao = c.DataSessao,
                                      HoraSessao = c.HoraSessao,
                                      Preco = (int)c.Preco
                                  })
                                  .ToListAsync();
        }

        // GET: api/SessaoAPI/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sessao>> GetSessao(int id)
        {
            var sessao = await _context.Sessoes.FindAsync(id);

            if (sessao == null)
            {
                return NotFound();
            }

            return sessao;
        }

        // PUT: api/SessaoAPI/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSessao(int id, Sessao sessao)
        {
            if (id != sessao.Id)
            {
                return BadRequest();
            }

            _context.Entry(sessao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SessaoExists(id))
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

        // POST: api/SessaoAPI
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sessao>> PostSessao(Sessao sessao)
        {
            _context.Sessoes.Add(sessao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSessao", new { id = sessao.Id }, sessao);
        }

        // DELETE: api/SessaoAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSessao(int id)
        {
            var sessao = await _context.Sessoes.FindAsync(id);
            if (sessao == null)
            {
                return NotFound();
            }

            _context.Sessoes.Remove(sessao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SessaoExists(int id)
        {
            return _context.Sessoes.Any(e => e.Id == id);
        }
    }
}
