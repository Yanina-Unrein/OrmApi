using Microsoft.AspNetCore.Mvc;
using OrmAPI.Modelo;
using OrmAPI.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrmAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly INorthwindRepository _repository;

        public ProductosController(INorthwindRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("ObtenerProductosConCategoria")]
        public async Task<ActionResult<List<object>>> GetWithCategory()
            => Ok(await _repository.ObtenerProductosConCategoria());

        [HttpGet("ObtenerProductosQueContienen")]
        public async Task<ActionResult<List<Products>>> GetByName([FromQuery] string palabra)
            => Ok(await _repository.ObtenerProductosQueContienen(palabra));
    }
}
