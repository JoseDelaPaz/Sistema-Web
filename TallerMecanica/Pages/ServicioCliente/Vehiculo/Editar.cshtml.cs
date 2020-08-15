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

namespace TallerMecanica.Pages.ServicioCliente.Vehiculo
{

    public class EditarModel : PageModel
    {
        [TempData]
        public string mensaje { get; set; }

        [TempData]
        public string MensajeError { get; set; }

        private readonly ApplicationDbContext _db;
        public EditarModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public AutomovilM automovil { get; set; }

        [BindProperty]
        public IEnumerable<ClienteM> Cliente { get; set; }

        //---Metodo para llenar los datos del select---

        public void OnGet(int ID)
        {
            automovil = _db.automiviles.Find(ID);

            //Lista Para llenar selext de cliente
            Cliente =  _db.clientes.ToList();

        }

        public IActionResult OnPost(int ID)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var nuevoAuto = _db.automiviles.FirstOrDefault(a=> a.ID == ID);
                    nuevoAuto.Marca = automovil.Marca;
                    nuevoAuto.Modelo = automovil.Modelo;
                    nuevoAuto.Lugar_Fabricacion = automovil.Lugar_Fabricacion;
                    nuevoAuto.ClienteID = automovil.ClienteID;
                    nuevoAuto.Tipo_Transmision = automovil.Tipo_Transmision;
                    nuevoAuto.Color = automovil.Color;
                    nuevoAuto.Descripcion_Problema = automovil.Descripcion_Problema;
                    nuevoAuto.Matricula = automovil.Matricula;
                    _db.SaveChanges();
                    mensaje = "Datos Actualizado ";
                    return RedirectToPage("Vehiculo");

                }
            }
            catch (Exception )
            {

                return Page();
            }

            MensajeError = "Error al actualizar " ;
            return RedirectToPage("Vehiculo");
        }

       
    }
}