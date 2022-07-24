using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RazorPagesCar.Models;
using RazorPagesCar.Areas.Identity.Pages.Account;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesCar.Pages.Cars
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly RazorPagesCar.Models.RazorPagesCarContext _context;

        public DeleteModel(SignInManager<ApplicationUser> signInManager, ILogger<LoginModel> logger, RazorPagesCar.Models.RazorPagesCarContext context)
        {
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Car = await _context.Car.FindAsync(id);

            if (Car != null)
            {
                _context.Car.Remove(Car);
               // await _context.SaveChangesAsync();
            }

            // Once a record is deleted, create an audit record
            if (await _context.SaveChangesAsync() > 0)
            {
                var auditrecord = new AuditRecord();
                auditrecord.AuditActionType = "Delete Car Record";
                auditrecord.DateTimeStamp = DateTime.Now;
                auditrecord.KeyMovieFieldID = Car.ID;
                var userID = User.Identity.Name.ToString();
                auditrecord.Username = userID;
                _context.AuditRecords.Add(auditrecord);
                await _context.SaveChangesAsync();
            }




            return RedirectToPage("./Index");
        }
    }
}
