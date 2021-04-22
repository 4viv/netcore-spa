# ASP .Net Core SPA

Los pasos para levantar el proyecto ASP.NET Core

    Cambiar la cadena de conexión del Core.Api por la de su base de datos.

    Hacer un REBUILD al proyecto para restaurar los paquetes del NuGet.

    Ejecutar la migración seleccionado el proyecto Core.Api como principal y en la consola del NuGet el proyecto persistence como principal.

    El comando es update-database

Los pasos para levantar el proyecto SPA

    Cambiar el puerto donde se ejecuta el proyecto SPA, por defecto configurar que apunte al 7000. Si por algún motivo usan otro puerto no se olviden actualizar dicho puerto en el appsetting donde esta el ApiUrl.

    Posicionarse en la carpeta app del proyecto y ejecutar el comando npm install o yarn install.

    Levantar el proyecto ejecutando npm run serve o yarn serve.

    Levantar el proyecto de visual studio.
