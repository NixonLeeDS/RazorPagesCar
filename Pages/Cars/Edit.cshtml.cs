using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesCar.Models;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using RazorPagesCar.Areas.Identity.Pages.Account;

namespace RazorPagesCar.Pages.Cars
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly RazorPagesCar.Models.RazorPagesCarContext _context;

        public EditModel(SignInManager<ApplicationUser> signInManager, ILogger<LoginModel> logger, RazorPagesCar.Models.RazorPagesCarContext context)
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

            // Create an auditrecord object
            var auditrecord = new AuditRecord();
            auditrecord.AuditActionType = "edit Car Record";
            auditrecord.DateTimeStamp = DateTime.Now;
            auditrecord.KeyMovieFieldID = Car.ID;
            // Get current logged-in user
            var userID = User.Identity.Name.ToString();
            auditrecord.Username = userID;

            _context.AuditRecords.Add(auditrecord);
            await _context.SaveChangesAsync();
            if (Car == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Car).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(Car.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CarExists(int id)
        {
            return _context.Car.Any(e => e.ID == id);
        }
    }
}
