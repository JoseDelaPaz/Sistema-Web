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
        public List<EmpleadoVehiculos> getEmp { get; set; }
        public List<AutomovilM> auto { get; set; }

        #region Listado
        public void OnGet()
        {
            //getEmp = _db.empleadosVehiculos
            //    .Include(a => a.empleadoVehiculof)
            //    .Include(a => a.automovilEmpleadof)
            //    .Where(a => a.Remitido == true)
            //    .ToList();

            getEmp = new List<EmpleadoVehiculos>();

            var aux = _db.empleadosVehiculos
                .Include(a => a.empleadoVehiculof)
                .Include(a => a.automovilEmpleadof)
                .Where(a => a.Remitido == true).ToList();
            foreach (var item in aux)
            {
                var existe = _db.entregas
               .FirstOrDefault(a => a.AutomovilID == item.AutomivilID);

                if (existe == null)
                {
                    getEmp.Add(item);
                }
            

            }
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