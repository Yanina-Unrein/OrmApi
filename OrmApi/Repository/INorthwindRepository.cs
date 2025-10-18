using OrmAPI.Modelo;

namespace OrmAPI.Repository
{
    public interface INorthwindRepository
    {
        Task<List<Employee>> ObtenerTodosLosEmpleados();
        Task<int> ObtenerlaCantidadDeEmpleados();
        Task<Employee?> ObtenerEmpleadoPorID(int empleadoID);
        Task<Employee?> ObtenerEmpleadoPorNombre(string nombreEmpleado);
        Task<Employee?> ObtenerEmpleadoPorTitulo(string titulo);
        Task<Employee?> ObtenerEmpleadoPorPais(string country);
        Task<List<Employee>> ObtenerTodosLosEmpleadosPorPais(string country);
        Task<Employee?> ObtenerEmpleadoMasGrande();
        Task<List<object>> ObtenerCantidadEmpleadosPorTitulos();

        // Productos
        Task<List<object>> ObtenerProductosConCategoria();
        Task<List<Products>> ObtenerProductosQueContienen(string palabra);
    }
}
