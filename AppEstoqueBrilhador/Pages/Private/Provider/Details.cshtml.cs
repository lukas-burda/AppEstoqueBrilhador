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
        private readonly AppDAL.Context _context;

        public DetailsModel(AppDAL.Context context)
        {
            _context = context;
        }

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
    }
}
