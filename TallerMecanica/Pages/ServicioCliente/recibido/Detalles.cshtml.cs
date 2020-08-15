using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapaDatos;
using CapaModelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TallerMecanica.Pages.ServicioCliente.recibido
{


    public class DetallesModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public DetallesModel(ApplicationDbContext db)
        {
             _context = db;       
        }

        public EmpleadoVehiculos EmpleadoVehiculos { get; set; }
        public async Task<IActionResult> OnGet(int? ID)
        {
            if (ID == null)
            {
                return NotFound();
            }

            EmpleadoVehiculos = await _context.empleadosVehiculos
                .Include(e => e.automovilEmpleadof)
                .Include(a=> a.empleadoVehiculof)
                .FirstOrDefaultAsync(m => m.EmpleadoVehiculosID == ID);
            return Page();

        }
    }
}