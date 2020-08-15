using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text;

namespace CapaModelos
{
    public class ClienteM
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="Nombre Requerido")]
        [DisplayName("Nombre del Cliente")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Apellido Requerido")]
        [DisplayName("Apellido del Cliente")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "Direccion Requerida")]
        [DisplayName("Direccion del Cliente")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Telefono Requerido")]
        [DisplayName("Telefono del Cliente") ]
        [MaxLength(10),MinLength(10)]
        public string Telefono { get; set; }
        public bool estado { get; set; }
        public List<AutomovilM> automovilC { get; set; }

    }
}
