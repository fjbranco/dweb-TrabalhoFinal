using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ModeloDados.Models;
using Dweb_TrabalhoFinal.Data;

namespace Dweb_TrabalhoFinal.Pages.Filmes;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public IList<Filme> Filme { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Filme = await _context.Filmes.ToListAsync();
    }
}
