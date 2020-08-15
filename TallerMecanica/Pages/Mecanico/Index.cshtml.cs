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

namespace TallerMecanica.Pages.Inicio.Usuarios
{
    
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]

        public List<EmpleadoVehiculos> GetEmp { get; set; }

        [BindProperty]
        public string Mensaje { get; set; }

        public List<EmpleadoM> empleados { get; set; }

        
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        #region Traer listado de asignaciones
        public IActionResult OnGet(int id, string estado = "No_Repado")
        {
            var aux = User.Identity.Name;
            var usuario = GetEmpleado();
            if (usuario != null)
            {
                var nombre = usuario.Nombre;
                id = usuario.ID;
                if (nombre == aux)
                {

                    GetEmp = _db.empleadosVehiculos
               .Include(a => a.empleadoVehiculof)
               .Include(a => a.automovilEmpleadof)
                  .Where(a => a.EmpleadoID == id && a.Estado != estado).ToList();
                    return Page();
                }
            }
            return Page();

        }

        public EmpleadoM GetEmpleado()
        {
            string nombre = User.Identity.Name;
            empleados = _db.empleado.ToList();
            return empleados.Where(a => a.Nombre == nombre).FirstOrDefault();
        }
        #endregion



        #region Eliminar 
        public IActionResult OnPostDelete(int ID)
        {
            try
            {
                var delete = _db.empleadosVehiculos.FirstOrDefault(a => a.EmpleadoVehiculosID == ID);
                if (delete == null)
                {
                    return Page();
                }
                _db.Remove(delete);
                _db.SaveChanges();
                Mensaje = "Datos Eliminados";
                return RedirectToPage("Index");

            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion
    }
}