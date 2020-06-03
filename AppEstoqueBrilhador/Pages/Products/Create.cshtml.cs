using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using AppDAL;
using AppDomain;

namespace AppEstoqueBrilhador.Pages.Products
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
        public Product Product { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Products.Add(Product);

            Log log = new Log();
            log.date = DateTime.Now;
            log.action = "Adição de novo Produto";
            log.log = Product.Name;
            _context.Lista.Add(log);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
