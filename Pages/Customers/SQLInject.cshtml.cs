using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesCar.Models;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesCar.Pages.Customers
{
    public class SQLInjectModel : PageModel
    {
        private readonly RazorPagesCar.Models.RazorPagesCarContext _context;

        public SQLInjectModel(RazorPagesCar.Models.RazorPagesCarContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get; set; }
        public string SQLmessage { get; set; }

        //[RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Entered Text contain Invalid characters")]
        public string SearchString { get; set; }

        public async Task OnGetAsync(String SearchString)
        {

            //SQLmessage = "Select * From Customers Where Name Like '%" + SearchString + "%'";
            // Customer = await _context.Customers.FromSqlRaw(SQLmessage).ToListAsync();
            //TempData["message"] = "Entered SQL :" + SQLmessage;


            if (String.IsNullOrEmpty(SearchString))
                SearchString = "%";
            else
                SearchString = "%" + SearchString + "%";

            string query = "SELECT * FROM Customers WHERE Name like {0}";
            Customer = await _context.Customers.FromSqlRaw(query, SearchString).ToListAsync();

            TempData["message"] = "Entered SQL : " + "SELECT * FROM Customers Where Name Like " + " " + SearchString;




        }

        public async Task<IActionResult> OnPostAsync(String SearchString)
        {
            return RedirectToPage("./Index");
        }
    }

}
