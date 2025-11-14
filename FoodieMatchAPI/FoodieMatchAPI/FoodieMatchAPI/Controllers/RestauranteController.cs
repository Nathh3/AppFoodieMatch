using FoodieMatchAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodieMatchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestauranteController : ControllerBase
    {
        // <summary>
        /// Controlador encargado de gestionar las operaciones relacionadas con los restaurantes
        /// dentro de la API de FoodieMatch. 
        /// Permite listar, crear, actualizar y eliminar restaurantes.
        /// </summary>
        private readonly IRestauranteRepository _restauranteRepository;
        private readonly IRestauranteQuery _restauranteQuery;
        private readonly ILogger<RestauranteController> _logger;

        /// <summary>
        /// Constructor del controlador de restaurantes.
        /// Inicializa las dependencias necesarias para el manejo de las operaciones CRUD.
        /// </summary>
        /// <param name="restauranteRepository">Repositorio encargado de las operaciones de escritura sobre los restaurantes.</param>
        /// <param name="restauranteQuery">Componente encargado de las consultas (lecturas) a la base de datos relacionadas con restaurantes.</param>
        /// <param name="logger">Interfaz de logging para registrar información y errores durante la ejecución.</param>

        public RestauranteController(IRestauranteRepository restauranteRepository, IRestauranteQuery restauranteQuery, ILogger<RestauranteController> logger)
        {
            _restauranteRepository = restauranteRepository ?? throw new ArgumentNullException(nameof(restauranteRepository));
            _restauranteQuery = restauranteQuery ?? throw new ArgumentNullException(nameof(restauranteQuery));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        /// <summary>
        /// Obtiene el listado completo de restaurantes registrados en el sistema.
        /// </summary>
        /// <remarks>
        /// Código de estado de respuesta:
        /// - 200 OK: La consulta se realizó correctamente.
        /// - 500 Internal Server Error: Ocurrió un error inesperado en el servidor.
        /// </remarks>
        /// <returns>Retorna una lista con todos los restaurantes registrados.</returns>
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

        /// <summary>
        /// Crea un nuevo restaurante en el sistema.
        /// </summary>
        /// <remarks>
        /// Código de estado de respuesta:
        /// - 201 Created: Restaurante creado exitosamente.
        /// - 400 Bad Request: Los datos enviados no son válidos.
        /// - 500 Internal Server Error: Error al intentar crear el restaurante.
        /// </remarks>
        /// <param name="restaurante">Objeto que contiene la información del nuevo restaurante a registrar.</param>
        /// <returns>Retorna el restaurante creado.</returns>

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

        /// <summary>
        /// Actualiza la información de un restaurante existente.
        /// </summary>
        /// <remarks>
        /// Código de estado de respuesta:
        /// - 200 OK: Restaurante actualizado correctamente.
        /// - 400 Bad Request: Los datos enviados son inválidos.
        /// - 404 Not Found: El restaurante no fue encontrado.
        /// - 500 Internal Server Error: Error al actualizar el restaurante.
        /// </remarks>
        /// <param name="restaurante">Objeto con la información actualizada del restaurante.</param>
        /// <returns>Retorna el restaurante actualizado.</returns>

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

        /// <summary>
        /// Elimina un restaurante por su identificador.
        /// </summary>
        /// <remarks>
        /// Código de estado de respuesta:
        /// - 200 OK: Restaurante eliminado correctamente.
        /// - 404 Not Found: No se encontró el restaurante a eliminar.
        /// - 500 Internal Server Error: Error interno al eliminar el restaurante.
        /// </remarks>
        /// <param name="id">Identificador único del restaurante.</param>
        /// <returns>Retorna una confirmación de la eliminación.</returns>

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
