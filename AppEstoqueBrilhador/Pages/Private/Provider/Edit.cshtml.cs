using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppDAL;
using AppDomain;

namespace AppEstoqueBrilhador.Pages.Provider
{
    public class EditModel : PageModel
    {
        private readonly AppDAL.Context _context;

        public EditModel(AppDAL.Context context)
        {
            _context = context;
        }

        [BindProperty]
        public ProviderX ProviderX { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProviderX = await _context.Providers.FirstOrDefaultAsync(m => m.id == id);

            if (ProviderX == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ProviderX).State = EntityState.Modified;
            Log log = new Log();
            log.date = DateTime.Now;
            log.action = "Edição de Fornecedor";
            log.log = ProviderX.nomeFantasia;
            _context.Lista.Add(log);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProviderXExists(ProviderX.id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ProviderXExists(int id)
        {
            return _context.Providers.Any(e => e.id == id);
        }
    }
}
