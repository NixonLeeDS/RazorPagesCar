using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesCar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RazorPagesCar.Pages.Cars
{
   
    // if commented out the top, This is to ensure that when the audit trail is being tested, the authorization will not affect the testing.
    public class IndexModel : PageModel
    {
        private readonly RazorPagesCar.Models.RazorPagesCarContext _context;

        public IndexModel(RazorPagesCar.Models.RazorPagesCarContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Types { get; set; }
        [BindProperty(SupportsGet = true)]
        public string CarType { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Car
                                            orderby m.Type
                                            select m.Type;

            var movies = from m in _context.Car
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.carName.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(CarType))
            {
                movies = movies.Where(x => x.Type == CarType);
            }

            Types = new SelectList(await genreQuery.Distinct().ToListAsync());
            Car = await movies.ToListAsync();
        }
    }
}
