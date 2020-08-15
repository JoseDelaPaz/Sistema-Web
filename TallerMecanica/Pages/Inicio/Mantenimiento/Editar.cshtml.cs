using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapaDatos;
using CapaModelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace TallerMecanica.Pages.Inicio.Mantenimiento
{
    //[Authorize]
    public class EditarModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditarModel(ApplicationDbContext db)
        {
            _db = db;

        }

        [BindProperty]
        public EmpleadoM empleadoM { get; set; }

        [TempData]
        public string Mensaje { get; set; }

        [TempData]
        public string MensajeError { get; set; }

        #region Listado
        public async Task OnGet(int id)
        {
            empleadoM =  await _db.empleado.FindAsync(id);

        }
        #endregion

        public IActionResult OnPost(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var nuevo = _db.empleado.FirstOrDefault(a => a.ID == id);
                    nuevo.Nombre = empleadoM.Nombre;
                    nuevo.Apellido = empleadoM.Apellido;
                    nuevo.Sexo = empleadoM.Sexo;
                    nuevo.Telefono = empleadoM.Telefono;
                    nuevo.Direccion = empleadoM.Direccion;
                    nuevo.Correo = empleadoM.Correo;
                    nuevo.marca_vehiculo = empleadoM.marca_vehiculo;
                    nuevo.Contrasena = empleadoM.Contrasena;
                    nuevo.Roles = empleadoM.Roles;
                    _db.SaveChanges();
                    Mensaje = "Datos Actualizado";
                    return RedirectToPage("Index");

                }

                MensajeError = "Error Al Actualizar";

            }
            catch (Exception)
            {

                throw;
            }

            return Page();
        
        }
    }
}