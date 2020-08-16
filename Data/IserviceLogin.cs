using CapaModelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaDatos
{
    public class IserviceLogin
    {
        List<EmpleadoM> empleadoMs;
        public IserviceLogin()
        {
            empleadoMs = new List<EmpleadoM>();

            empleadoMs.Add(new EmpleadoM
            {
                ID = 100,
                Nombre = "Juan",
                Apellido = "Vargas",
                Sexo = "Masculino",
                Telefono = "8094325432",
                Direccion = "Azua",
                marca_vehiculo = "Toyota",
                Correo = "admin@gmail.com",
                Contrasena = "12345",
                Roles = "Administrador"
                
            });
        }
        public EmpleadoM GetUsuario(string login, string password)
        {
            return empleadoMs.FirstOrDefault(u => u.Correo == login && u.Contrasena == password);
        }


    }
}
