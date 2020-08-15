using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CapaModelos
{
    public class EmpleadoM
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Datos Requerido")]
        [DisplayName("Nombre del Empleado")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Datos Requerido")]
        [DisplayName("Apellido del Empleado")]
        public string Apellido { get; set; }


        [Required(ErrorMessage = "Datos Requerido")]
        [DisplayName("Sexo del Empleado")]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "Datos Requerido")]
        [DisplayName("Telefono del Empleado")]
        [Phone]
        [MaxLength(10), MinLength(10)]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "Datos Requerido")]
        [DisplayName("Direccion del Empleado")]
        public string Direccion { get; set; }

        [Required(ErrorMessage = "Datos Requerido")]
        [DisplayName("Correo del Empleado")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "Datos Requerido")]
        [DisplayName("Marca del Vehiculo Habilitado")]
        public string marca_vehiculo { get; set; }


        [Required(ErrorMessage = "Datos Requerido")]
        [DisplayName("Contraseña del Empleado")]
        public string Contrasena { get; set; }

        [Required(ErrorMessage = "Datos Requerido")]
        [DisplayName("Roles del Empleado")]
        public string Roles { get; set; }

        public virtual List<EmpleadoVehiculos> GetEmpleados { get; set; }

        //public virtual EmpleadoVehiculos GetEmpleadoVehi { get; set; }

        //public static EmpleadoM FirstOrDefault(Func<object, bool> p)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
