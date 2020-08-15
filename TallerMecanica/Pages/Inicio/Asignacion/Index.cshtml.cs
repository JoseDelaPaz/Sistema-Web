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

namespace TallerMecanica.Pages.Inicio.Asignacion
{
    
    public class IndexModel : PageModel
    {
        
        private readonly ApplicationDbContext _db;
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }


        [TempData]
        public string Mensaje { get; set; }

        [TempData]
        public string MensajeError { get; set; }

        #region Listado
        public List<EmpleadoVehiculos> getEmp { get; set; }
        public void OnGet()
        {
              getEmp = _db.empleadosVehiculos
                .Include(a => a.empleadoVehiculof)
                .Include(a => a.automovilEmpleadof).ToList();

           
        }
        #endregion

        #region Eliminar datos

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