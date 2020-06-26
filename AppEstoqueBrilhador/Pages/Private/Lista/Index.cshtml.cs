using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AppDAL;
using AppDomain;

namespace AppEstoqueBrilhador.Pages.Lista
{
    public class IndexModel : PageModel
    {
        private readonly AppDAL.Context _context;

        public IndexModel(AppDAL.Context context)
        {
            _context = context;
        }

        public IList<Log> Log { get;set; }

        public async Task OnGetAsync()
        {
            Log = await _context.Lista.ToListAsync();
        }
    }
}
