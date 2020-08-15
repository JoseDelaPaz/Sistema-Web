using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapaDatos;
using CapaModelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TallerMecanica.Pages.Inicio
{
    //[Microsoft.AspNetCore.Authorization.Authorize(Roles = "Administrador")]
    public class DetalleModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public DetalleModel(ApplicationDbContext db)
        {
            _db = db;

        }
        public EmpleadoM EmpleadoMs { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EmpleadoMs = await _db.empleado
                .FirstOrDefaultAsync(m => m.ID == id);
            return Page();
        }
    }
}