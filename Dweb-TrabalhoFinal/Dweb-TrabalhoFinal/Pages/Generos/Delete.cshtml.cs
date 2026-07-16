using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dweb_TrabalhoFinal.Data;
using ModeloDados.Models;

namespace Dweb_TrabalhoFinal.Pages.Generos
{
    public class DeleteModel : PageModel
    {
        private readonly Dweb_TrabalhoFinal.Data.ApplicationDbContext _context;

        public DeleteModel(Dweb_TrabalhoFinal.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Genero Genero { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genero = await _context.Generos.FirstOrDefaultAsync(m => m.Id == id);

            if (genero is not null)
            {
                Genero = genero;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genero = await _context.Generos.FindAsync(id);
            if (genero != null)
            {
                Genero = genero;
                _context.Generos.Remove(Genero);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
