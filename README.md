# 🧩 Northwind API REST – Programa FullStack repositorio Backed ejercicio Final OrmApi

API REST desarrollada en **ASP.NET Core** que permite consultar información de **empleados y productos** de la empresa, utilizando la base de datos **Northwind** y el patrón **Repositorio** con **Entity Framework Core**.

Incluye soporte para **Swagger** para visualizar y probar los endpoints.

---

## 🚀 Tecnologías utilizadas

- **ASP.NET Core 8**
- **Entity Framework Core**
- **SQL Server (Base de datos Northwind)**
- **Swagger / Swashbuckle**
- **Inyección de dependencias (DI)**
- **LINQ / Consultas asíncronas**

---

## 🧠 Estructura del proyecto

OrmAPI/   
├── Controllers/   
│ ├── EmpleadosController.cs   
│ └── ProductosController.cs   
├── Data/   
│ └── DataContext.cs   
├── Modelo/   
│ ├── Employee.cs   
│ ├── Products.cs   
│ └── Categories.cs   
├── Repository/   
│ ├── INorthwindRepository.cs   
│ └── NorthwindRepository.cs   
├── appsettings.json   
└── Program.cs   
---

## 📘 Endpoints disponibles
### Empleados (api/Empleados)
Método	Endpoint	Descripción   
- GET	/api/Empleados/TodosLosEmpleados	Devuelve todos los empleados.   
- GET	/api/Empleados/CantidadEmpleados	Devuelve la cantidad total de empleados.   
- GET	/api/Empleados/EmpleadoPorID?empleadoID=5	Devuelve el empleado con el ID especificado.   
- GET	/api/Empleados/EmpleadosPorNombre?nombreEmpleado=Andrew	Devuelve el empleado cuyo nombre coincida.   
- GET	/api/Empleados/IDempleadoPorTitulo?titulo=Manager	Devuelve el empleado que ocupa el título indicado.   
- GET	/api/Empleados/EmpleadoPorPais?country=USA	Devuelve un empleado que viva en el país indicado.   
- GET	/api/Empleados/TodosLosEmpleadosPorPais?country=UK	Devuelve todos los empleados de un país.   
- GET	/api/Empleados/ElEmpleadoMasGrande	Devuelve el empleado de mayor edad.   
GET	/api/Empleados/CantidadEmpleadosPorTitulos	Devuelve la cantidad de empleados agrupados por título.   

## 📦 Productos (api/Productos)   
Método	Endpoint	Descripción   
- GET	/api/Productos/ObtenerProductosConCategoria	Devuelve productos con su categoría.   
- GET	/api/Productos/ObtenerProductosQueContienen?palabra=choco	Devuelve productos cuyo nombre contiene la palabra indicada.   
