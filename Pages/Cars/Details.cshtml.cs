using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesCar.Models;
using Microsoft.AspNetCore.Authorization;
namespace RazorPagesCar.Pages.Cars
{
    [Authorize(Roles = "Admin, Users")]
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesCar.Models.RazorPagesCarContext _context;

        public DetailsModel(RazorPagesCar.Models.RazorPagesCarContext context)
        {
            _context = context;
        }

        public Car Car { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _context.Car.FirstOrDefaultAsync(m => m.ID == id);

            if (Car == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
