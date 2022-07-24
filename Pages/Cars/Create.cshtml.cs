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

namespace RazorPagesCar.Pages.Cars
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        
            private readonly SignInManager<ApplicationUser> _signInManager;
            private readonly ILogger<LoginModel> _logger;
            private readonly RazorPagesCar.Models.RazorPagesCarContext _context;

            public CreateModel(SignInManager<ApplicationUser> signInManager, ILogger<LoginModel> logger, RazorPagesCar.Models.RazorPagesCarContext context)
            {
                _signInManager = signInManager;
                _logger = logger;
                _context = context;
            }

            public IActionResult OnGet()
        {

            //Car = new Car
           // {
                //carName = "Mercedes-Benz A-Class",
               // ManufactureDate = DateTime.Parse("2018-2-12"),
                ///Type = "Car",
               // Price = 150M,
               // Availability= " "
           // };
            //throw new Exception("Test Error");
            return Page();


        }

        [BindProperty]
        public Car Car { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Car.Add(Car);
            //await _context.SaveChangesAsync();

            // Once a record is added, create an audit record
            if (await _context.SaveChangesAsync() > 0)
            {
                // Create an auditrecord object
                var auditrecord = new AuditRecord();
                auditrecord.AuditActionType = "Added New Car Record";
                auditrecord.DateTimeStamp = DateTime.Now;
                auditrecord.KeyMovieFieldID = Car.ID;
                // Get current logged-in user
                var userID = User.Identity.Name.ToString();
                auditrecord.Username = userID;

                _context.AuditRecords.Add(auditrecord);
                await _context.SaveChangesAsync();
            }


            return RedirectToPage("./Index");
        }
    }
}
