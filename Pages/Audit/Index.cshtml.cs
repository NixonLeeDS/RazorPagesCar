using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesCar.Models;

using Microsoft.AspNetCore.Authorization;


namespace RazorPagesCar.Pages.Audit
{
    [Authorize(Roles = "Admin")]

    public class IndexModel : PageModel
    {
        private readonly RazorPagesCar.Models.RazorPagesCarContext _context;

        public IndexModel(RazorPagesCar.Models.RazorPagesCarContext context)
        {
            _context = context;
        }

        public IList<AuditRecord> AuditRecord { get;set; }

        public async Task OnGetAsync()
        {
            AuditRecord = await _context.AuditRecords.ToListAsync();
        }
    }
}
