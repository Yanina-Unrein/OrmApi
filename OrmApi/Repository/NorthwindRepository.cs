using Microsoft.EntityFrameworkCore;
using OrmAPI.Data;
using OrmAPI.Modelo;

namespace OrmAPI.Repository
{
    public class NorthwindRepository : INorthwindRepository
    {
        private readonly DataContext _context;
        public NorthwindRepository(DataContext context)
        {
           this._context = context;
        }
        // 1️⃣ Empleados
        public async Task<List<Employee>> ObtenerTodosLosEmpleados() =>
            await _context.Employees.ToListAsync();

        public async Task<int> ObtenerlaCantidadDeEmpleados() =>
            await _context.Employees.CountAsync();

        public async Task<Employee?> ObtenerEmpleadoPorID(int empleadoID) =>
            await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeID == empleadoID);

        public async Task<Employee?> ObtenerEmpleadoPorNombre(string nombreEmpleado) =>
            await _context.Employees.FirstOrDefaultAsync(e => e.FirstName.Contains(nombreEmpleado));

        public async Task<Employee?> ObtenerEmpleadoPorTitulo(string titulo) =>
            await _context.Employees.FirstOrDefaultAsync(e => e.Title.Contains(titulo));

        public async Task<Employee?> ObtenerEmpleadoPorPais(string country) =>
            await _context.Employees.FirstOrDefaultAsync(e => e.Country == country);

        public async Task<List<Employee>> ObtenerTodosLosEmpleadosPorPais(string country) =>
            await _context.Employees.Where(e => e.Country == country).ToListAsync();

        public async Task<Employee?> ObtenerEmpleadoMasGrande() =>
            await _context.Employees.OrderBy(e => e.BirthDate).FirstOrDefaultAsync();

        public async Task<List<object>> ObtenerCantidadEmpleadosPorTitulos()
        {
            return await _context.Employees
                .GroupBy(e => e.Title)
                .Select(g => new { Titulo = g.Key, Cantidad = g.Count() })
                .Cast<object>()
                .ToListAsync();
        }

        // 2️⃣ Productos
        public async Task<List<object>> ObtenerProductosConCategoria()
        {
            return await _context.Products
                .Join(_context.Categories,
                      p => p.CategoryID,
                      c => c.CategoryID,
                      (p, c) => new { p.ProductName, c.CategoryName })
                .Cast<object>()
                .ToListAsync();
        }

        public async Task<List<Products>> ObtenerProductosQueContienen(string palabra)
        {
            return await _context.Products
                .Where(p => p.ProductName.Contains(palabra))
                .ToListAsync();
        }
    }
}
