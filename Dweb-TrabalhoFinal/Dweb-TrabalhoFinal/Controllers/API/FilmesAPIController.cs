using Dweb_TrabalhoFinal.Data;
using Dweb_TrabalhoFinal.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ModeloDados.Models;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class FilmesAPIController : ControllerBase
{

    /// <summary>
    /// Referência à base de dados
    /// </summary>
    private readonly ApplicationDbContext _context;
    public FilmesAPIController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Filme
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FilmesDTO>>> GetFilme()
    {
        //return await _context.Filmes.ToListAsync();
        return await _context.Filmes
                              .Select(c => new FilmesDTO {
                                  Id = c.Id,
                                  Titulo = c.Titulo,
                                  Ano = c.Ano
                              })
                              .ToListAsync();
    }

    // GET: api/Filme/5
    [HttpGet("{id}")]
    public async Task<ActionResult<FilmesSimplerDTO>> GetFilme(int id)
    {
        var filme = await _context.Filmes
                                      .Where(c => c.Id == id)
                                      .Select(c => new FilmesSimplerDTO {
                                          Titulo = c.Titulo,
                                          Ano = c.Ano
                                      })
                                      .FirstOrDefaultAsync();

        if (filme == null)
        {
            return NotFound();
        }

        return filme;
    }

    //// PUT: api/Filme/5
    //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    //[HttpPut("{id}")]
    //public async Task<IActionResult> PutFilme(int? id, Filme filme)
    //{
    //    if (id != filme.Id)
    //    {
    //        return BadRequest();
    //    }

    //    _context.Entry(filme).State = EntityState.Modified;

    //    try
    //    {
    //        await _context.SaveChangesAsync();
    //    }
    //    catch (DbUpdateConcurrencyException)
    //    {
    //        if (!FilmeExists(id))
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

    // POST: api/Filme
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<FilmesSimplerDTO>> PostFilme(FilmesSimplerDTO nomeDoFilme)
    {
        Filme filme = new() 
        {
            Titulo = nomeDoFilme.Titulo,
            Ano = nomeDoFilme.Ano
        };
        try {
            _context.Filmes.Add(filme);
            await _context.SaveChangesAsync();
        } catch (Exception) {
            return BadRequest();
        }

        return CreatedAtAction("GetFilme", new { id = filme.Id }, filme);
    }

    //// DELETE: api/Filme/5
    //[HttpDelete("{id}")]
    //public async Task<IActionResult> DeleteFilme(int? id)
    //{
    //    var filme = await _context.Filmes.FindAsync(id);
    //    if (filme == null)
    //    {
    //        return NotFound();
    //    }

    //    _context.Filmes.Remove(filme);
    //    await _context.SaveChangesAsync();

    //    return NoContent();
    //}

    private bool FilmeExists(int? id)
    {
        return _context.Filmes.Any(e => e.Id == id);
    }
}
