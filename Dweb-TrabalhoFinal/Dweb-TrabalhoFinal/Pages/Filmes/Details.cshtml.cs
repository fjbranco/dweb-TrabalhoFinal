using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ModeloDados.Models;
using Dweb_TrabalhoFinal.Data;

namespace Dweb_TrabalhoFinal.Pages.Filmes;

public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;
    public DetailsModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public Filme Filme { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var filme = await _context.Filmes.FirstOrDefaultAsync(m => m.Id == id);
        if (filme is null)
        {
            return NotFound();
        }
        else
        {
            Filme = filme;
        }

        return Page();
    }
}
