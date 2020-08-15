using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapaDatos;
using CapaModelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TallerMecanica.Pages.Mecanico
{
    public class DetallesModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public DetallesModel(ApplicationDbContext db)
        {
            _db = db;    
        }
        public AutomovilM AutomovilM { get; set; }
        public async Task<IActionResult> OnGet(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }

            AutomovilM = await _db.automiviles
                .Include(e => e.ClienteF).FirstOrDefaultAsync(m => m.ID == ID);
            return Page();

        }
    }
}