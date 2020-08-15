using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapaDatos;
using CapaModelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TallerMecanica.Pages.Inicio.Asignacion
{
    public class EditarModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditarModel(ApplicationDbContext db)
        {
            _db = db; 
        }

        [TempData]
        public string Mensaje { get; set; }

        [BindProperty]
        public EmpleadoVehiculos getEmpleadoVehiculos { get; set; }

        public List<AutomovilM> auto { get; set; }
        public List<EmpleadoM> empleadoMs { get; set; }
        public void OnGet(int id ,string rol = "Mecanico")
        {
            getEmpleadoVehiculos = _db.empleadosVehiculos.FirstOrDefault(a => a.EmpleadoVehiculosID == id);
            empleadoMs = _db.empleado.Where(a => a.Roles == rol).ToList();
            auto = _db.automiviles.ToList();
        }


        public IActionResult OnPost(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var nuevo = _db.empleadosVehiculos.FirstOrDefault(a => a.EmpleadoVehiculosID == id);
                    nuevo.EmpleadoID = getEmpleadoVehiculos.EmpleadoID;
                    nuevo.Estado = getEmpleadoVehiculos.Estado;
                    nuevo.Detalle_Reparaciion = getEmpleadoVehiculos.Detalle_Reparaciion;
                    _db.SaveChanges();
                    Mensaje = "Datos actualizado";
                    return RedirectToPage("Index");
                }
            }
            catch (Exception)
            {

                throw;
            }
            return Page();
           
        }
    }
}