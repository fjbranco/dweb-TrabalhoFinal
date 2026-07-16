using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ModeloDados.Models;
using Dweb_TrabalhoFinal.Data;

namespace Dweb-TrabalhoFinal.Pages.SalaPages;

public class DetailsModel : PageModel
{
    private readonly ApplicationDbContext _context;
    public DetailsModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public Sala Sala { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var sala = await _context.Salas.FirstOrDefaultAsync(m => m.Id == id);
        if (sala is null)
        {
            return NotFound();
        }
        else
        {
            Sala = sala;
        }

        return Page();
    }
}
