using FoodieMatchAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodieMatchAPI.Controllers
{
    /// <summary>
    /// Controlador encargado de gestionar las operaciones relacionadas con las elecciones de usuarios
    /// dentro de la API de FoodieMatch.
    /// Permite listar, crear, actualizar, eliminar y consultar elecciones de productos por usuario.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EleccionController : ControllerBase
    {
        private readonly IEleccionRepository _eleccionRepository;
        private readonly IEleccionQuery _eleccionQuery;
        private readonly ILogger<EleccionController> _logger;

        /// <summary>
        /// Constructor del controlador de elecciones.
        /// Inicializa las dependencias necesarias para el manejo de las operaciones CRUD de elecciones.
        /// </summary>
        /// <param name="eleccionRepository">Repositorio encargado de las operaciones de escritura sobre las elecciones.</param>
        /// <param name="eleccionQuery">Componente encargado de las consultas (lecturas) a la base de datos relacionadas con elecciones.</param>
        /// <param name="logger">Interfaz de logging para registrar información y errores durante la ejecución.</param>
        
        public EleccionController(IEleccionRepository eleccionRepository, IEleccionQuery eleccionQuery, ILogger<EleccionController> logger)
        {
            _eleccionRepository = eleccionRepository ?? throw new ArgumentNullException(nameof(eleccionRepository));
            _eleccionQuery = eleccionQuery ?? throw new ArgumentNullException(nameof(eleccionQuery));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));

        }
        /// <summary>
        /// Obtiene el listado completo de elecciones registradas en el sistema.
        /// </summary>
        /// <remarks>
        /// Código de estado de respuesta:
        /// - 200 OK: La consulta se realizó correctamente.
        /// - 500 Internal Server Error: Ocurrió un error inesperado en el servidor.
        /// </remarks>
        /// <returns>Retorna una lista con todas las elecciones registradas.</returns

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
        /// <summary>
        /// Crea una nueva elección en el sistema.
        /// </summary>
        /// <remarks>
        /// Código de estado de respuesta:
        /// - 200 OK: Elección creada exitosamente.
        /// - 400 Bad Request: Los datos enviados no son válidos.
        /// - 500 Internal Server Error: Error al intentar crear la elección.
        /// </remarks>
        /// <param name="eleccion">Objeto que contiene la información de la nueva elección a registrar.</param>
        /// <returns>Retorna la elección creada.</returns>
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

        /// <summary>
        /// Actualiza la información de una elección existente.
        /// </summary>
        /// <remarks>
        /// Código de estado de respuesta:
        /// - 200 OK: Elección actualizada correctamente.
        /// - 400 Bad Request: Los datos enviados son inválidos.
        /// - 404 Not Found: La elección no fue encontrada.
        /// - 500 Internal Server Error: Error al actualizar la elección.
        /// </remarks>
        /// <param name="eleccion">Objeto con la información actualizada de la elección.</param>
        /// <returns>Retorna la elección actualizada.</returns>
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

        /// <summary>
        /// Elimina una elección por su identificador.
        /// </summary>
        /// <remarks>
        /// Código de estado de respuesta:
        /// - 200 OK: Elección eliminada correctamente.
        /// - 404 Not Found: No se encontró la elección a eliminar.
        /// - 500 Internal Server Error: Error interno al eliminar la elección.
        /// </remarks>
        /// <param name="id">Identificador único de la elección.</param>
        /// <returns>Retorna una confirmación de la eliminación.</returns>

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
        /// <summary>
        /// Obtiene todas las elecciones realizadas por un usuario específico.
        /// </summary>
        /// <remarks>
        /// Código de estado de respuesta:
        /// - 200 OK: Consulta realizada correctamente.
        /// - 404 Not Found: No se encontraron elecciones para el usuario especificado.
        /// - 500 Internal Server Error: Error interno al realizar la consulta.
        /// </remarks>
        /// <param name="usuarioId">Identificador único del usuario.</param>
        /// <returns>Retorna la lista de elecciones del usuario.</returns>
        /// 
        /// 
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
