using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppDAL;
using AppDomain;

namespace AppEstoqueBrilhador.Pages.Provider
{
    public class DeleteModel : PageModel
    {
        private readonly AppDAL.Context _context;

        public DeleteModel(AppDAL.Context context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ProviderX = await _context.Providers.FindAsync(id);

            if (ProviderX != null)
            {
                _context.Providers.Remove(ProviderX);
                Log log = new Log();
                log.date = DateTime.Now;
                log.action = "Remoção de Fornecedor";
                log.log = ProviderX.nomeFantasia;
                _context.Lista.Add(log);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
