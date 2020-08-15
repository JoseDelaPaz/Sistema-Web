using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using CapaDatos;
using CapaModelos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Schema;

namespace TallerMecanica.Pages.Inicio
{
   
    public class AsignacionModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public AsignacionModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<EmpleadoM> empleadoMs { get; set; }

        [TempData]
        public string Mensaje { get; set; }

        [TempData]
        public string MensajeError { get; set; }
        public List<AutomovilM> auto { get; set; }

        [BindProperty]
        public EmpleadoVehiculos postEmpleadp { get; set; }
        public List<EmpleadoVehiculos>lista{get; set; }

        #region listado
        public void OnGet(string rol = "Mecanico")
        {
            empleadoMs = _db.empleado.Where(a => a.Roles == rol).ToList();

            // metodo para no mostrar los vehiculos seleccionados
            auto = new List<AutomovilM>();
            var aux = _db.automiviles.ToList();
            foreach (var item in aux)
            {
                var existe = _db.empleadosVehiculos.Where(e => e.AutomivilID == item.ID).FirstOrDefault();

                if (existe == null)
                {
                    auto.Add(item);
                }
            }
        }
        #endregion

        #region  Validacion de datos 
        public IActionResult Onpost()
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return Page();
                }


                // metodo para no asingar mas de 3 auto a un empleado
               var empleadoExiste = _db.empleado.ToList();
                foreach (var item in empleadoExiste)
                {
                    var Contador = _db.empleadosVehiculos.Where(a => a.Validacion == false && a.EmpleadoID == item.ID).Count();
                    if (Contador >= 3)
                    {
                        MensajeError = "No se Puede Asignar Mas de 3 Vehiculo";
                        return RedirectToPage("Index");
                    }
            }


                //Metodo para validar la marca de vehiculo qu esta habilitado el empleado 
            var usuario = GetEmpleadoM(postEmpleadp.EmpleadoID);
                var aux = GetAutomovil(postEmpleadp.AutomivilID);
                if (usuario != null)
                {

                    var MarcaEmpleado = usuario.marca_vehiculo;
                    var marcaVehiculo = aux.Marca;

                    // validar el empleado y la marca del vehiculo
                    if (MarcaEmpleado == marcaVehiculo)
                    {
                        _db.Add(postEmpleadp);
                        _db.SaveChanges();
                        Mensaje = "Datos Asignados";
                        return RedirectToPage("Index");


                    }
                    MensajeError = "Él empleado " + usuario.Nombre + " no está autorizado para trabajar esta marca de vehiculo " + aux.Marca;
                    return RedirectToPage("Index");

                }

                return Page();
            }
            catch (Exception)
            {

                throw;
            }

 
        }

        public EmpleadoM GetEmpleadoM(int id) {

            empleadoMs = _db.empleado.ToList();
            return empleadoMs.Where(a => a.ID == id).FirstOrDefault(); 
        }
        public AutomovilM GetAutomovil(int id)
        {

            auto = _db.automiviles.ToList();
            return auto.Where(a => a.ID == id).FirstOrDefault();
        }

        #endregion
    }
}
