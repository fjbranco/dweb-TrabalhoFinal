using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dweb_TrabalhoFinal.Data;
using ModeloDados.Models;

namespace Dweb_TrabalhoFinal.Pages.Genero
{
    public class IndexModel : PageModel
    {
        private readonly Dweb_TrabalhoFinal.Data.ApplicationDbContext _context;

        public IndexModel(Dweb_TrabalhoFinal.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<ModeloDados.Models.Genero> Genero { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Genero = await _context.Generos.ToListAsync();
        }
    }
}
