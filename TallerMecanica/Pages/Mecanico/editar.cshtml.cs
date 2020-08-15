using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapaDatos;
using CapaModelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SQLitePCL;

namespace TallerMecanica.Pages.Mecanico
{
    //[Authorize(Roles = "Administrador"), Authorize(Roles = "Mecanico")]
    public class editarModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public editarModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public EmpleadoVehiculos GetEmpleado { get; set; }

        public string Mensaje { get; set; }
        public void OnGet(int id)
        {
            GetEmpleado = _db.empleadosVehiculos.FirstOrDefault(a=> a.EmpleadoVehiculosID == id);
        }
        public IActionResult OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                var nuevo = _db.empleadosVehiculos.FirstOrDefault(a=> a.EmpleadoVehiculosID == id);
                nuevo.Estado = GetEmpleado.Estado;
                nuevo.Detalle_Reparaciion = GetEmpleado.Detalle_Reparaciion;
                _db.SaveChanges();
                Mensaje = "Datos Agregados";
                return RedirectToPage("Index");
            }
            return Page();
        }

    }
}