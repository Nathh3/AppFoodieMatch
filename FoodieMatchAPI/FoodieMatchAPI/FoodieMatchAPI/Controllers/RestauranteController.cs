using FoodieMatchAPI.Repository.Implements;
using FoodieMatchAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodieMatchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestauranteController : ControllerBase
    {
        private readonly IRestauranteRepository _restauranteRepository;
        private readonly IRestauranteQuery _restauranteQuery;
        private readonly ILogger<RestauranteController> _logger;

        public RestauranteController(IRestauranteRepository restauranteRepository, IRestauranteQuery restauranteQuery, ILogger<RestauranteController> logger)
        {
            _restauranteRepository = restauranteRepository ?? throw new ArgumentNullException(nameof(restauranteRepository));
            _restauranteQuery = restauranteQuery ?? throw new ArgumentNullException(nameof(restauranteQuery));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            try
            {
                _logger.LogInformation("CONSULTAR TODOS LOS RESTAURANTES");
                var rs = await _restauranteQuery.GetAll();
                _logger.LogTrace(rs.ToString());
                return Ok(rs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al listar restaurantes");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] FoodieMatchAPI.Models.Restaurante restaurante)
        {
            try
            {
                _logger.LogInformation("CREAR NUEVO RESTAURANTE");
                var nuevo = await _restauranteRepository.CreateRestaurant(restaurante);
                return Ok(nuevo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear restaurante");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] FoodieMatchAPI.Models.Restaurante restaurante)
        {
            try
            {
                _logger.LogInformation("ACTUALIZAR RESTAURANTE");
                var actualizado = await _restauranteRepository.UpdateRestaurant(restaurante);
                return Ok(actualizado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar restaurante");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                _logger.LogInformation("ELIMINAR RESTAURANTE CON ID {Id}", id);
                var eliminado = await _restauranteRepository.DeleteRestaurante(id);
                return Ok(eliminado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar restaurante");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
