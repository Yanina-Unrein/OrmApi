using Microsoft.AspNetCore.Mvc;
using OrmAPI.Modelo;
using OrmAPI.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrmAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NorthwindController : ControllerBase
    {
        private readonly INorthwindRepository _repository;

        public NorthwindController(INorthwindRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("TodosLosEmpleados")]
        public async Task<ActionResult<List<Employee>>> GetAll()
        {
            var empleados = await _repository.ObtenerTodosLosEmpleados();
            return Ok(empleados);
        }

        [HttpGet("CantidadEmpleados")]
        public async Task<ActionResult<int>> ObtenerlaCantidadDeEmpleados()
        {
            var cantidad = await _repository.ObtenerlaCantidadDeEmpleados();
            return Ok(cantidad);
        }
    }
}
