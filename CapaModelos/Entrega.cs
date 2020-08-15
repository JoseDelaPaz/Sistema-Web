using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Text;

namespace CapaModelos
{
   public class Entrega
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Datos Obligatorio")]
        [DisplayName("Fecha de Entrega")]
        public DateTime Fecha_Entrega { get; set; }

        [Required(ErrorMessage = "Datos Obligatorio")]
        [DisplayName("Comentario de Entrega")]
        public string Detalles { get; set; }
        public int AutomovilID { get; set; }

        [Required(ErrorMessage = "Datos Obligatorio")]
        public string estado { get; set; }

        [Required(ErrorMessage = "Datos Obligatorio")]
        public float precio { get; set; }

        [ForeignKey("AutomovilID")]
        public virtual AutomovilM automovilF { get; set; }
        ////public virtual ClienteM GetCliente { get; set; }

    }
}
