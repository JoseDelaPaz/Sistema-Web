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

namespace TallerMecanica.Pages.ServicioCliente.recibido
{
    public class ListadoModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public ListadoModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Entrega> entrega { get; set; }
        public List<AutomovilM> automovilMs { get; set; }
        public void OnGet()
        {
            entrega = _db.entregas
                .Include(a=> a.automovilF)
                .Include(a=> a.automovilF.ClienteF)
                .ToList();
        }
    }
}