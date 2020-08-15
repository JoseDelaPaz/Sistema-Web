using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using CapaDatos;
using CapaModelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace TallerMecanica.Pages.ServicioCliente.Vehiculo
{


    public class FormularioVehiculoModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public FormularioVehiculoModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<ClienteM> Cliente { get; set; }
        [TempData]
        public string Mensaje { get; set; }

        [TempData]
        public string MensajeError { get; set; }

        //---Metodo para llenar los datos del select---
        public void OnGet()
        {

            Cliente = new List<ClienteM>();

            var aux = _db.clientes.ToList();
            foreach (var item in aux)
            {
                var existe = _db.automiviles.
                    Where(a => a.ClienteID == item.ID).FirstOrDefault();
                if (existe == null)
                {
                    Cliente.Add(item);
                }
            }

        }


        [BindProperty]
        public AutomovilM automovil { get; set; }
        //--Metodo Para guardar---
        public IActionResult OnPost()
        {
            try
            {
                
                if (!ModelState.IsValid)
                {
                    MensajeError = "Error al guardar ";
                    return Page();
                }
                automovil.Fecha_Entrada = DateTime.Now;
                _db.Add(automovil);
                _db.SaveChanges();
                Mensaje = "Datos Guardado";
               return RedirectToPage("Vehiculo");
            }
            catch (Exception )
            {
                MensajeError = "Error al Guardar";
                return Page();

            }
        }
    } 
} 