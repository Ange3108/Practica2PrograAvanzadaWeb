# Pr-ctica-2PrograAvanzadaWeb
En este repositorio está la práctica dos de programación avanzada web

# Información del Proyecto

## 1. Integrantes del grupo

- Angelik Guatemala Camacho
- Javier Mendez Gonzalez
- María José Alvarado Fernandez
- Keisly Angélica Pasos Solano

## 2. Repositorio

Repositorio del proyecto:

https://github.com/Ange3108/Practica2PrograAvanzadaWeb.git


## 3. Especificación básica del proyecto

### a. Arquitectura del proyecto

El proyecto fue desarrollado siguiendo una arquitectura por capas, con el objetivo de separar responsabilidades y facilitar el mantenimiento del código.

La solución está compuesta por los siguientes proyectos:

- **Practica2**
  - Aplicación ASP.NET Core MVC.
  - Contiene la interfaz de usuario, controladores, vistas y configuración general.

- **Practica2.BLL (Business Logic Layer)**
  - Contiene la lógica de negocio.
  - Implementa los servicios de la aplicación.
  - Maneja los DTOs y el mapeo entre entidades y modelos.

- **Practica2.DAL (Data Access Layer)**
  - Responsable del acceso a la base de datos.
  - Contiene las entidades, el DbContext y los repositorios.
  - Implementa el patrón Repository para encapsular las operaciones CRUD.


### b. Libraries o paquetes NuGet utilizados

El proyecto utiliza los siguientes paquetes NuGet:

| Paquete | Función |
|----------|---------|
| AutoMapper | Conversión automática entre entidades y DTOs. |
| Microsoft.EntityFrameworkCore | ORM para el acceso a datos mediante Entity Framework Core. |
| Microsoft.EntityFrameworkCore.SqlServer | Proveedor para trabajar con SQL Server. |
| Microsoft.EntityFrameworkCore.Relational | Funcionalidades relacionales de Entity Framework Core. |
| Microsoft.EntityFrameworkCore.Design | Herramientas para migraciones y diseño de la base de datos. |



### c. Principios SOLID y patrones de diseño utilizados

#### Principios SOLID

Durante el desarrollo del proyecto se aplicaron los siguientes principios:

- **S (Single Responsibility Principle):**
  Cada clase posee una única responsabilidad. Los controladores administran las solicitudes, los servicios contienen la lógica de negocio y los repositorios realizan el acceso a datos.

- **D (Dependency Inversion Principle):**
  Se utilizan interfaces para desacoplar la lógica de negocio de la capa de acceso a datos mediante inyección de dependencias.

---

#### Patrones de diseño

El proyecto implementa los siguientes patrones:

- **Repository Pattern**
  - Encapsula el acceso a la base de datos.
  - Facilita el mantenimiento y las pruebas del sistema.

- **Service Layer Pattern**
  - Centraliza la lógica de negocio.
  - Mantiene separados los controladores del acceso directo a los repositorios.

- **Dependency Injection**
  - Utilizada por ASP.NET Core para resolver automáticamente las dependencias entre servicios y repositorios.

- **DTO (Data Transfer Object)**
  - Empleado para transportar información entre capas evitando exponer directamente las entidades de la base de datos.

- **AutoMapper**
  - Automatiza la conversión entre entidades y DTOs, reduciendo código repetitivo.
