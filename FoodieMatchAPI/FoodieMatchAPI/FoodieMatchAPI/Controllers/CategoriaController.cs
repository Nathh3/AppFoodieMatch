using FoodieMatchAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodieMatchAPI.Controllers
{
    /// <summary>
    /// Controlador encargado de gestionar las operaciones relacionadas con las categorías
    /// dentro de la API de FoodieMatch. 
    /// Permite listar, crear, actualizar y eliminar categorías.
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly ICategoriaQuery _categoriaQuery;
        private readonly ILogger<CategoriaController> _logger;


        /// <summary>
        /// Constructor del controlador de categorías.
        /// Inicializa las dependencias necesarias para el manejo de las operaciones CRUD.
        /// </summary>
        /// <param name="categoriaRepository">Repositorio encargado de las operaciones de escritura.</param>
        /// <param name="categoriaQuery">Componente encargado de las consultas (lecturas) a la base de datos.</param>
        /// <param name="logger">Interfaz de logging para registrar información y errores.</param>
        public CategoriaController(ICategoriaRepository categoriaRepository, ICategoriaQuery categoriaQuery, ILogger<CategoriaController> logger)
        {
            _categoriaRepository = categoriaRepository ?? throw new ArgumentNullException(nameof(categoriaRepository));
            _categoriaQuery = categoriaQuery ?? throw new ArgumentNullException(nameof(categoriaQuery));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Obtiene el listado completo de categorías existentes.
        /// </summary>
        /// <remarks>
        /// Código de estado de respuesta:
        /// - 200 OK: La consulta se realizó correctamente.
        /// - 500 Internal Server Error: Ocurrió un error inesperado en el servidor.
        /// </remarks>
        /// <returns>Retorna una lista con todas las categorías registradas.</returns>

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            try
            {
                _logger.LogInformation("CONSULTAR TODAS LAS CATEGORÍAS");
                var rs = await _categoriaQuery.GetAll();
                return Ok(rs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al listar categorías");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Crea una nueva categoría en el sistema.
        /// </summary>
        /// <remarks>
        /// Código de estado de respuesta:
        /// - 201 Created: Categoría creada exitosamente.
        /// - 400 Bad Request: Los datos enviados no son válidos.
        /// - 500 Internal Server Error: Error al intentar crear la categoría.
        /// </remarks>
        /// <param name="categoria">Objeto que contiene la información de la nueva categoría.</param>
        /// <returns>Retorna la categoría creada.</returns>

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] FoodieMatchAPI.Models.Categoria categoria)
        {
            try
            {
                _logger.LogInformation("CREAR NUEVA CATEGORÍA");
                var nueva = await _categoriaRepository.CreateCategory(categoria);
                return Ok(nueva);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear categoría");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Actualiza la información de una categoría existente.
        /// </summary>
        /// <remarks>
        /// Código de estado de respuesta:
        /// - 200 OK: Categoría actualizada correctamente.
        /// - 400 Bad Request: Los datos son inválidos.
        /// - 404 Not Found: La categoría no fue encontrada.
        /// - 500 Internal Server Error: Error al actualizar la categoría.
        /// </remarks>
        /// <param name="categoria">Objeto con la información actualizada de la categoría.</param>
        /// <returns>Retorna la categoría actualizada.</returns>
        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] FoodieMatchAPI.Models.Categoria categoria)
        {
            try
            {
                _logger.LogInformation("ACTUALIZAR CATEGORÍA");
                var actualizada = await _categoriaRepository.UpdateCategory(categoria);
                return Ok(actualizada);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar categoría");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        /// <summary>
        /// Elimina una categoría por su identificador.
        /// </summary>
        /// <remarks>
        /// Código de estado de respuesta:
        /// - 200 OK: Categoría eliminada correctamente.
        /// - 404 Not Found: No se encontró la categoría a eliminar.
        /// - 500 Internal Server Error: Error interno al eliminar la categoría.
        /// </remarks>
        /// <param name="id">Identificador único de la categoría.</param>
        /// <returns>Retorna una confirmación de la eliminación.</returns>
        // ✅ DELETE: api/Categoria/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                _logger.LogInformation("ELIMINAR CATEGORÍA CON ID {Id}", id);
                var eliminada = await _categoriaRepository.DeleteCategory(id);
                return Ok(eliminada);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar categoría");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }



}
