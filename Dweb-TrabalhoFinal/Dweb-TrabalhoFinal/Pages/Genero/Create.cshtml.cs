using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Dweb_TrabalhoFinal.Data;
using ModeloDados.Models;

namespace Dweb_TrabalhoFinal.Pages.Genero
{
    public class CreateModel : PageModel
    {
        private readonly Dweb_TrabalhoFinal.Data.ApplicationDbContext _context;

        public CreateModel(Dweb_TrabalhoFinal.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Genero Genero { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Generos.Add(Genero);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
