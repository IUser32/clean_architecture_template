# Introducción

Este es un proyecto plantilla utilizando el enfoque clean architecture. Este es un proyecto simple que implementa las siguientes tecnologias:
- MediatR
- EntityFramework
- .NET 8

Tambien sigue las buenas prácticas de

- Principios SOLID
- Clean Architecture
- Repositorios
- Unidad de Trabajo

# Persistencia

Se está utilizando un enfoque Database-First en EntityFramework. Se crea la base de datos primero y ese código se genera en el visual studio.

Existe un archivo llamado `DB.SQL`, se debe de crear en base de datos para que funcione.

## Comandos importantes para la persistencia de datos. *(OPCIONAL)*

Desde el proyecto de Persistencia, se debe de ejecutar los siguientes comandos: *No utilizar por ahora.*

- dotnet tool install --global dotnet-ef
- dotnet add package Microsoft.EntityFrameworkCore.SqlServer
- dotnet add package Microsoft.EntityFrameworkCore.Design

Estos comandos son importantes para instalar las herramientas de EntityFramework para generar el modelo de datos.
Para confirmar que todo se ha instalado bien utilizar el siguiente comando.
- dotnet ef --version

Para generar el modelo de manera automatica podemos utilizar: (No se está utilizando en este proyecto, todo se genera manual.)
- dotnet ef dbcontext scaffold "Server=localhost;Database=CleanArchitectureTemplateDB;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Entities -c ApplicationDbContext -f 

