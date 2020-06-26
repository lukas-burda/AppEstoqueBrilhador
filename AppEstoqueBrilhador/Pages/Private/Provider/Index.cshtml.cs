using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppDAL;
using AppDomain;
using Microsoft.AspNetCore.Http.Features;

namespace AppEstoqueBrilhador.Pages.Provider
{
    public class IndexModel : PageModel
    {
        private readonly AppDAL.Context _context;

        public IndexModel(AppDAL.Context context)
        {
            _context = context;
        }

        public IList<ProviderX> ProviderX { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public async Task OnGetAsync()
        {
            var searchProv = from m in _context.Providers
                         select m;
            var searchProvName = from m in _context.Providers
                             select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                searchProv = searchProv.Where(s => s.cnpj.Contains(SearchString));
                searchProvName = searchProvName.Where(s => s.nomeFantasia.Contains(SearchString));
            }


            ProviderX = await searchProv.ToListAsync();
            
            if (ProviderX.Count == 0) { 
            ProviderX = await searchProvName.ToListAsync();
            }
        }
    }
}
