using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
using System.Text;

namespace CapaModelos
{
    public class EmpleadoVehiculos
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpleadoVehiculosID { get; set; }       
        public string Detalle_Reparaciion { get; set; }
        public string Estado { get; set; }
        public bool Validacion { get; set; }
        public bool Remitido { get; set; }

        [DisplayName("Nombre del Mecanico")]
        public int EmpleadoID { get; set; }

        [DisplayName("Marca del Automovil")]
        public int AutomivilID { get; set; }

        [ForeignKey("EmpleadoID")]
        public EmpleadoM empleadoVehiculof { get; set; }


        [ForeignKey("AutomivilID")]
        public AutomovilM automovilEmpleadof { get; set; }
    }

}
