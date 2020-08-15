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

namespace TallerMecanica.Pages.ServivioCliente
{
    public class VehiculoModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public VehiculoModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]

        [TempData]
        public string Mensaje { get; set; }

        [TempData]
        public string MensajeError { get; set; }
        public List<AutomovilM> automovil { get; set; }

        #region Listado
        public async Task<IActionResult> OnGet()
        {
            automovil = await _db.automiviles.Include("ClienteF").ToListAsync();
            return Page();     
        }
        #endregion

        #region Eliminar
        public IActionResult OnPostDelete(int ID)
        {

            try
            {
                var automovil = _db.automiviles.Find(ID);
                if (automovil == null)
                {
                    return NotFound();
                }
                _db.Remove(automovil);
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