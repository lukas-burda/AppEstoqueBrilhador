using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AppDomain;

namespace AppEstoqueBrilhador.Pages.Provider
{
    public class CreateModel : PageModel
    {
        private readonly AppDAL.Context _context;

        public CreateModel(AppDAL.Context context)
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

            Log log = new Log();
            log.date = DateTime.Now;
            log.action = "Adição de fornecedor";
            log.log = ProviderX.nomeFantasia;
            _context.Lista.Add(log);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
