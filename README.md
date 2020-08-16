# Sistema-Web
Sistema para taller de mecanica en asp.net core

El taller xyz Necesita tener el control de los automoviles que recibe en taller de servicio. 
Para ello ha contratado a su compania para desarrollar una herramienta de software que le permita realizar esta tarea.
Atencion al usuario neceista llevar un registro de los automoviles ingresados al taller, en que fecha se recibieron, la descripcion del problema por parte del cliente, la marca, color, tipo de transmision, lugar de fabricacion del vehiculo etc. 
El jefe de mecanica necesita registrar cada mecanico con sus datos basicos y la marca de vehiculos que esta habilitado para trabajar. 
El jefe de mecanica requiere poder asignar vehiculos a los mecanicos disponibles para ser reparados. 
Los vehiculos solo pueden ser asignados a mecanicos que sepan trabajar la marca del vehiculo a asignar.
Un mecanico no puede tener asignados mas de 3 vehiculos. Los mecanicos deben poder ver de los vehiculos que tienen asignados especifiar como fueron reparados. 
En caso de que el vehiculo no puede ser reparado, debe especificarse el motivo.
Cuando el mecanido especifique como reparo el vehiculo o el motivo por el cual no puedo repararlo, el jefe de mecanica debe ver el caso y puede: Remitirlo a otro mecanico o remitirlo a atencion al cliente para ser devuelto.
Se debe registrar la entrega del vehiculo al propietari@, colocando la fecha, hora y algun comentario adicional. 
El jefe de mecanica y/o atencion al cliente deben poder generar un reporte de los vehiculos recibidos, reparados, no reparados y/o pendientes.
El rol de administrador tiene acceso a todas las vistas, el rol del mecánico solo tiene acceso a su lista de asignaciones y el rol de servicio al cliente tiene acceso al registro de cliente, automóviles y las entregas de vehículos. 
