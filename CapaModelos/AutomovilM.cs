using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CapaModelos
{
    public class AutomovilM
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Datos Requerido")]
        [DisplayName("Marca del Vehiculo")]
        public string Marca { get; set; }


        [Required(ErrorMessage = "Datos Requerido")]
        [DisplayName("Tipo de Transmision")]
        public string Tipo_Transmision { get; set; }


        [Required(ErrorMessage = "Datos Requerido")]
        [DisplayName("Descripcion de problema")]
        public string Descripcion_Problema { get; set; }


        [Required(ErrorMessage = "Datos Requerido")]
        [DisplayName("Fecha de Entrada")]
        public DateTime Fecha_Entrada { get; set; }

        [Required(ErrorMessage = "Datos Requerido")]
        [DisplayName("Lugar de Fabricacion")]
        public string Lugar_Fabricacion { get; set; }


        [Required(ErrorMessage = "Datos Requerido")]
        [DisplayName("Color del Vehiculo")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Datos Requerido")]
        [DisplayName("Matricula del Vehiculo")]
        [MaxLength(10), MinLength(10)]
        public string Matricula { get; set; }


        [DisplayName("Dueño del Vehiculo")]
        [Required(ErrorMessage = "Datos Requerido")]
        public int ClienteID { get; set; }


        [Required(ErrorMessage = "Datos Requerido")]
        [DisplayName("Modelo del Vehiculo")]
        public string Modelo { get; set; }

        public virtual List<Entrega> entregas { get; set; }

        [ForeignKey("ClienteID")]
        public virtual ClienteM ClienteF { get; set; }

        public virtual List<EmpleadoVehiculos> GetEmpleados { get; set; }
    }
}
