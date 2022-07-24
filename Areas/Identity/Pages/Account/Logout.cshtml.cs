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



namespace RazorPagesCar.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;
        private readonly RazorPagesCar.Models.RazorPagesCarContext _context;


        public LogoutModel(SignInManager<ApplicationUser> signInManager, ILogger<LogoutModel> logger, RazorPagesCar.Models.RazorPagesCarContext context)
        {
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
        }

        public void OnGet()
        {
        }





        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            await _signInManager.SignOutAsync();

            var uid = await _signInManager.UserManager.GetEmailAsync(
                await _signInManager.UserManager.GetUserAsync(this.User));

            var auditrecord = new AuditRecord();
            auditrecord.AuditActionType = "Logout";
            auditrecord.DateTimeStamp = DateTime.Now;
            auditrecord.KeyMovieFieldID = 1;
            auditrecord.Username = uid;
            _context.AuditRecords.Add(auditrecord);
            await _context.SaveChangesAsync();


            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToPage();
            }
        }
    }
}
