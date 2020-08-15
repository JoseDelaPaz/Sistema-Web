using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapaDatos;
using CapaModelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TallerMecanica.Pages.Inicio
{
    //[Authorize(Roles = "Administrador")]
    public class CrearEmModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public CrearEmModel(ApplicationDbContext db)
        {
            _db = db;
           
        }

        [BindProperty]
        public EmpleadoM empleadoM { get; set; }

        public void OnGet()
        {
            
        }

        public IActionResult OnPost()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                
                }
                _db.Add(empleadoM);
                _db.SaveChanges();
             return RedirectToPage("Index");

            }
            catch (Exception)
            {

                throw;
            }
        
        }



      

       
    }
}