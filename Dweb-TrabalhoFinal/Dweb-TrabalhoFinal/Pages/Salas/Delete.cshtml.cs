using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ModeloDados.Models;
using Dweb_TrabalhoFinal.Data;

namespace Dweb_TrabalhoFinal.Pages.Salas;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
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

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var sala = await _context.Salas.FindAsync(id);
        if (sala != null)
        {
            Sala = sala;
            _context.Salas.Remove(Sala);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
