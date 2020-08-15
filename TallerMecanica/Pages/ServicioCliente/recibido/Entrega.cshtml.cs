using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using CapaDatos;
using CapaModelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TallerMecanica.Pages.ServicioCliente.recibido
{

   
    public class EntregaModel : PageModel
    {

        private readonly ApplicationDbContext _db;
        public EntregaModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [TempData]
        public string Mensaje { get; set; }

        [BindProperty]
        public Entrega entrega { get; set; }

        [BindProperty]
        public EmpleadoVehiculos GetEmpleado { get; set; }
        public List<AutomovilM> auto { get; set; }
        public List<ClienteM> clientes { get; set; }
        public void OnGet(int id, string estado ="No_Repadado")
        {
            GetEmpleado = _db.empleadosVehiculos.FirstOrDefault(a => a.EmpleadoVehiculosID == id);
            auto = _db.automiviles.ToList();
            clientes = _db.clientes.ToList();

        }

        public IActionResult Onpost()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                entrega.Fecha_Entrega = DateTime.Now;
                _db.Add(entrega);
                _db.SaveChanges();
                Mensaje = "Entrega Realisada ";
                return RedirectToPage("Listado");
            }
            catch (Exception)
            {

                return Page();
            }

        }
    }
}