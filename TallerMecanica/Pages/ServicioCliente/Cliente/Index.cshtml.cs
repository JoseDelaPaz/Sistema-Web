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

namespace TallerMecanica.Pages.Cliente
{
  
    public class IndexModel : PageModel 
    {
        [TempData]
        public string Mensaje { get; set; }

        [TempData]
        public string MensajeError { get; set; }

        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }


        [BindProperty]
        public List<ClienteM> Cliente { get; set; }

        #region Listado
        public async Task<IActionResult> OnGet()
        {
           Cliente = await _db.clientes.ToListAsync();
            return Page();

        }

        #endregion



        #region Eliminar 
        public IActionResult OnPostDelete(int ID)
        {
            try
            {
               var Cliente = _db.clientes.Find(ID);
                if (Cliente == null)
                {
                    return NotFound();
                }

                _db.clientes.Remove(Cliente);
                _db.SaveChanges();
                Mensaje = "Datos Eliminado";
                return RedirectToPage("Index");


            }
            catch (Exception ex)
            {
                MensajeError = "Erro al eliminar" +  ex;
                return Page();
                
            }
        }
        #endregion
    }
}