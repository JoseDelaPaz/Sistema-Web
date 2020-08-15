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

namespace TallerMecanica.Pages.Vistas
{
    //[Authorize(Roles = "Administrador")]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [TempData]
        public string MensajeError { get; set; }
        public IList<EmpleadoM> empleados { get; set; }

        [TempData]
        public string Mensaje { get; set; }

        #region Listado
        public async Task OnGet( )
        {
            empleados = await _db.empleado
                .ToListAsync();

        }
        #endregion

        #region Eliminar
        public IActionResult Delete(int id)
        {
            try
            {
                var dele = _db.empleado.Find(id);
                if (dele == null)
                { return Page(); }
                _db.Remove(dele);
                _db.SaveChanges();
                Mensaje = "Datos Eliminados";
                return RedirectToPage("Vehiculo");
            }
            catch (Exception)
            {

                throw;
            }
           
        }
        #endregion
    }
}
