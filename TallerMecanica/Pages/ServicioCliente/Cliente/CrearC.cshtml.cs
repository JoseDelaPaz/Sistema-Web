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
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TallerMecanica.Pages.Cliente
{

   
    public class CrearCModel : PageModel
    {
        [TempData]
        public string MensajeError { get; set; }

        private readonly ApplicationDbContext _db;
        public CrearCModel(ApplicationDbContext db)
        {
            _db = db; 
        }
       
        [BindProperty]
        public ClienteM clientes { get; set; }

        [TempData]
        public string Mensaje { get; set; }
        public void OnGet()
        {
         
        }
         public IActionResult Onpost()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                _db.Add(clientes);
                _db.SaveChanges();
                Mensaje = "Datos Guardados ";
                return RedirectToPage("Index");
            }
            catch (Exception)
            {

                MensajeError = "Error Al Guardar";
                return Page();
            }
           
        }
    }
}