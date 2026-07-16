using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ModeloDados.Models;
using Dweb_TrabalhoFinal.Data;

namespace Dweb_TrabalhoFinal.Pages.Bilhetes;

public class DeleteModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DeleteModel(ApplicationDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Bilhete Bilhete { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var bilhete = await _context.Bilhetes.FirstOrDefaultAsync(m => m.Id == id);
        if (bilhete is null)
        {
            return NotFound();
        }
        else
        {
            Bilhete = bilhete;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var bilhete = await _context.Bilhetes.FindAsync(id);
        if (bilhete != null)
        {
            Bilhete = bilhete;
            _context.Bilhetes.Remove(Bilhete);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
