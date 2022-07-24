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
    public class DeleteModel : PageModel
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly ILogger<LoginModel> _logger;
        private readonly RazorPagesCar.Models.RazorPagesCarContext _context;
        public DeleteModel(RoleManager<ApplicationRole> roleManager, ILogger<LoginModel> logger, RazorPagesCar.Models.RazorPagesCarContext context)
        {
            _roleManager = roleManager;
            _logger = logger;
            _context = context;
        }
        [BindProperty]
        public ApplicationRole ApplicationRole { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ApplicationRole = await _roleManager.FindByIdAsync(id);

            if (ApplicationRole == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ApplicationRole = await _roleManager.FindByIdAsync(id);
            IdentityResult roleRuslt = await _roleManager.DeleteAsync(ApplicationRole);


            if (roleRuslt.Succeeded)
            {
                // Create an auditrecord object
                var auditrecord = new AuditRecord();
                auditrecord.AuditActionType = "Deleted role";
                auditrecord.DateTimeStamp = DateTime.Now;
                auditrecord.KeyMovieFieldID = 6;
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