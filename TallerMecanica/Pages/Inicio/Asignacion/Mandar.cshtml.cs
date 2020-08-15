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

namespace TallerMecanica.Pages.Inicio.CasosVehiculos
{
    public class MandarModel : PageModel
    {
        [TempData]
        public string Mensaje { get; set; }

        private readonly ApplicationDbContext _db;
        public MandarModel(ApplicationDbContext db)
        {
            _db = db;
        }
  
        [BindProperty]
        public EmpleadoVehiculos GetEmpleadoVehiculos { get; set; }
        public List<EmpleadoM> empleadoMs { get; set; }
        public List<AutomovilM> auto { get; set; }


        #region Detalle
        public void OnGet(int id)
        {
            GetEmpleadoVehiculos = _db.empleadosVehiculos.FirstOrDefault(a=> a.EmpleadoVehiculosID == id);

            empleadoMs = _db.empleado.ToList();
            auto = _db.automiviles.ToList();

        }
        #endregion

        public IActionResult Onpost(int ? id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var nuevo = _db.empleadosVehiculos.FirstOrDefault(a => a.EmpleadoVehiculosID == id);
                    nuevo.Remitido = GetEmpleadoVehiculos.Remitido;               
                    //_db.Add(GetEmpleadoVehiculos);
                    _db.SaveChanges();
                    Mensaje = "Datos remitido a servicio al cliente";
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