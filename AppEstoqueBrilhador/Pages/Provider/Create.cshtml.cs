using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppDAL;
using AppDomain;

namespace AppEstoqueBrilhador.Pages.Provider
{
    public class CreateModel : PageModel
    {
        private readonly AppDAL.ProviderContext _context;

        public CreateModel(AppDAL.ProviderContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ProviderX ProviderX { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Providers.Add(ProviderX);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
