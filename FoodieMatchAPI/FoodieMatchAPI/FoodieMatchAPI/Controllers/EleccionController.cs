using FoodieMatchAPI.Repository.Implements;
using FoodieMatchAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodieMatchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EleccionController : ControllerBase
    {
        private readonly IEleccionRepository _eleccionRepository;
        private readonly IEleccionQuery _eleccionQuery;
        private readonly ILogger<EleccionController> _logger;

        public EleccionController(IEleccionRepository eleccionRepository, IEleccionQuery eleccionQuery, ILogger<EleccionController> logger)
        {
            _eleccionRepository = eleccionRepository ?? throw new ArgumentNullException(nameof(eleccionRepository));
            _eleccionQuery = eleccionQuery ?? throw new ArgumentNullException(nameof(eleccionQuery));   
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        }


        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            try
            {
                _logger.LogInformation("CONSULTAR TODAS LAS ELECCIONES");
                var rs = await _eleccionQuery.GetAll();
                return Ok(rs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al listar elecciones");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] FoodieMatchAPI.Models.Eleccion eleccion)
        {
            try
            {
                _logger.LogInformation("CREAR NUEVA ELECCION");
                var nueva = await _eleccionRepository.CreateEleccion(eleccion);
                return Ok(nueva);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear eleccion");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] FoodieMatchAPI.Models.Eleccion eleccion)
        {
            try
            {
                _logger.LogInformation("ACTUALIZAR ELECCION");
                var actualizada = await _eleccionRepository.UpdateEleccion(eleccion);
                return Ok(actualizada);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar eleccion");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                _logger.LogInformation("ELIMINAR ELECCION CON ID {Id}", id);
                var eliminada = await _eleccionRepository.DeleteEleccion(id);
                return Ok(eliminada);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar eleccion");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("user/{usuarioId}")]
        public async Task<IActionResult> GetByUsuario(int usuarioId)
        {
            var elecciones = await _eleccionQuery.GetByUsuarioId(usuarioId);
            if (elecciones == null || !elecciones.Any())
                return NotFound();

            return Ok(elecciones);
        }
    }
}
