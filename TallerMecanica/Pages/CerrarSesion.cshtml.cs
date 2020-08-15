using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TallerMecanica.Pages
{
    public class Index1Model : PageModel
    {
        public void OnGet()
        {
        }
        public IActionResult Onpost()
        {

            HttpContext.SignOutAsync().GetAwaiter().GetResult();
            return RedirectToPage("Index");
        }

    }
}
