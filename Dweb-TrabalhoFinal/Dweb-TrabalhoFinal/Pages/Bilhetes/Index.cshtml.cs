using Dweb_TrabalhoFinal.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ModeloDados.Models;

namespace Dweb_TrabalhoFinal.Pages.Bilhetes;

[Authorize(Roles = "Admin")]
public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Bilhete> Bilhete { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Bilhete = await _context.Bilhetes.ToListAsync();
    }
}
