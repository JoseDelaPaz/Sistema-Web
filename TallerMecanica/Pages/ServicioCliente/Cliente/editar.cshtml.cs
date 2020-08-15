using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapaDatos;
using CapaModelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace TallerMecanica.Pages.Cliente
{
   
    public class EditarModel : PageModel
    {
        private readonly ApplicationDbContext _db;


        public EditarModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public ClienteM Clientes { get; set; }

        [TempData]
        public string Mensaje { get; set; }

        #region Listado
        public void OnGet(int ID)
        {
            Clientes = _db.clientes.Find(ID);
        }
        #endregion


        #region Actualizar
        public IActionResult OnPost(int id)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    var nuevocliente = _db.clientes.Find(id);
                    nuevocliente.Nombre = Clientes.Nombre;
                    nuevocliente.Apellido = Clientes.Apellido;
                    nuevocliente.Direccion = Clientes.Direccion;
                    nuevocliente.Telefono = Clientes.Telefono;

                    _db.SaveChanges();
                    Mensaje = "Datos Actualizado";
                    return RedirectToPage("Index");
                }
            }
            catch (Exception)
            {
              

                throw;
            }
            return RedirectToPage();

        }
        #endregion 
    }
}