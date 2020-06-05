using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppDAL;
using AppDomain;

namespace AppEstoqueBrilhador.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly AppDAL.Context _context;

        public IndexModel(AppDAL.Context context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public async Task OnGetAsync()
        {
            var searchProd = from Name in _context.Products
                         select Name;
            if (!string.IsNullOrEmpty(SearchString))
            {
                searchProd = searchProd.Where(s => s.Name.Contains(SearchString));
            }

            Product = await searchProd.ToListAsync();
        }

    }
}
