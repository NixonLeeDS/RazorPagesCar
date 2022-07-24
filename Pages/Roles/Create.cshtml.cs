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


namespace RazorPagesCar.Pages.Roles
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly RazorPagesCar.Models.RazorPagesCarContext _context;
        public CreateModel(RoleManager<ApplicationRole> roleManager, ILogger<LoginModel> logger, RazorPagesCar.Models.RazorPagesCarContext context)
        {
            _roleManager = roleManager;
            _logger = logger;
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ApplicationRole ApplicationRole { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ApplicationRole.CreatedDate = DateTime.UtcNow;
            ApplicationRole.IPAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();

            IdentityResult roleRuslt = await _roleManager.CreateAsync(ApplicationRole);


            if(roleRuslt.Succeeded)
            {
                // Create an auditrecord object
                var auditrecord = new AuditRecord();
                auditrecord.AuditActionType = "Created new role";
                auditrecord.DateTimeStamp = DateTime.Now;
                auditrecord.KeyMovieFieldID = 5;
                // Get current logged-in user
                var userID = User.Identity.Name.ToString();
                auditrecord.Username = userID;

                _context.AuditRecords.Add(auditrecord);
                await _context.SaveChangesAsync();
            }


            return RedirectToPage("Index");
        }
    }
}
