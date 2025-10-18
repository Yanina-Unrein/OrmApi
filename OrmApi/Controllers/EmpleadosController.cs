using Microsoft.AspNetCore.Mvc;
using OrmAPI.Modelo;
using OrmAPI.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrmAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly INorthwindRepository _repository;

        public EmpleadosController(INorthwindRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("TodosLosEmpleados")]
        public async Task<ActionResult<List<Employee>>> GetAll()
            => Ok(await _repository.ObtenerTodosLosEmpleados());

        [HttpGet("CantidadEmpleados")]
        public async Task<ActionResult<int>> GetCount()
            => Ok(await _repository.ObtenerlaCantidadDeEmpleados());

        [HttpGet("EmpleadoPorID")]
        public async Task<ActionResult<Employee>> GetById([FromQuery] int empleadoID)
        {
            var empleado = await _repository.ObtenerEmpleadoPorID(empleadoID);
            return empleado is null ? NotFound() : Ok(empleado);
        }

        [HttpGet("EmpleadosPorNombre")]
        public async Task<ActionResult<Employee>> GetByName([FromQuery] string nombreEmpleado)
        {
            var empleado = await _repository.ObtenerEmpleadoPorNombre(nombreEmpleado);
            return empleado is null ? NotFound() : Ok(empleado);
        }

        [HttpGet("IDempleadoPorTitulo")]
        public async Task<ActionResult<Employee>> GetByTitle([FromQuery] string titulo)
        {
            var empleado = await _repository.ObtenerEmpleadoPorTitulo(titulo);
            return empleado is null ? NotFound() : Ok(empleado);
        }

        [HttpGet("EmpleadoPorPais")]
        public async Task<ActionResult<Employee>> GetByCountry([FromQuery] string country)
        {
            var empleado = await _repository.ObtenerEmpleadoPorPais(country);
            return empleado is null ? NotFound() : Ok(empleado);
        }

        [HttpGet("TodosLosEmpleadosPorPais")]
        public async Task<ActionResult<List<Employee>>> GetAllByCountry([FromQuery] string country)
            => Ok(await _repository.ObtenerTodosLosEmpleadosPorPais(country));

        [HttpGet("ElEmpleadoMasGrande")]
        public async Task<ActionResult<Employee>> GetOldest()
        {
            var empleado = await _repository.ObtenerEmpleadoMasGrande();
            return empleado is null ? NotFound() : Ok(empleado);
        }

        [HttpGet("CantidadEmpleadosPorTitulos")]
        public async Task<ActionResult<List<object>>> GetCountByTitle()
            => Ok(await _repository.ObtenerCantidadEmpleadosPorTitulos());
    }
}
