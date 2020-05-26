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
    public class DetailsModel : PageModel
    {
        private readonly AppDAL.ProviderContext _context;

        public DetailsModel(AppDAL.ProviderContext context)
        {
            _context = context;
        }

        public ProviderX Provider { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Provider = await _context.Providers.FirstOrDefaultAsync(m => m.id == id);

            if (Provider == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
