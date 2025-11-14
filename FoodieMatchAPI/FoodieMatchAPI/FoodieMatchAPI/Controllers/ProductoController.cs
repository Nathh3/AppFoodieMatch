using FoodieMatchAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodieMatchAPI.Controllers
{
    /// <summary>
    /// Controlador encargado de gestionar las operaciones relacionadas con los productos
    /// dentro de la API de FoodieMatch. 
    /// Permite listar, crear, actualizar y eliminar productos.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IProductoQuery _productoQuery;
        private readonly ILogger<ProductoController> _logger;
        /// <summary>
        /// Constructor del controlador de productos.
        /// Inicializa las dependencias necesarias para el manejo de las operaciones CRUD.
        /// </summary>
        /// <param name="productoRepository">Repositorio encargado de las operaciones de escritura sobre los productos.</param>
        /// <param name="productoQuery">Componente encargado de las consultas (lecturas) a la base de datos relacionadas con productos.</param>
        /// <param name="logger">Interfaz de logging para registrar información y errores durante la ejecución.</param>
        public ProductoController(IProductoRepository productoRepository, IProductoQuery productoQuery, ILogger<ProductoController> logger)
        {
            _productoRepository = productoRepository ?? throw new ArgumentNullException(nameof(productoRepository));
            _productoQuery = productoQuery ?? throw new ArgumentNullException(nameof(productoQuery));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            try
            {
                _logger.LogInformation("CONSULTAR TODOS LOS PRODUCTOS");
                var rs = await _productoQuery.GetAll();
                return Ok(rs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al listar productos");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Obtiene el listado completo de productos existentes en el sistema.
        /// </summary>
        /// <remarks>
        /// Código de estado de respuesta:
        /// - 200 OK: La consulta se realizó correctamente.
        /// - 500 Internal Server Error: Ocurrió un error inesperado en el servidor.
        /// </remarks>
        /// <returns>Retorna una lista con todos los productos registrados.</returns>
        /// 
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] FoodieMatchAPI.Models.Producto producto)
        {
            try
            {
                _logger.LogInformation("CREAR NUEVO PRODUCTO");
                var nuevo = await _productoRepository.CreateProduct(producto);
                return Ok(nuevo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear producto");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        /// <summary>
        /// Actualiza la información de un producto existente.
        /// </summary>
        /// <remarks>
        /// Código de estado de respuesta:
        /// - 200 OK: Producto actualizado correctamente.
        /// - 400 Bad Request: Los datos enviados son inválidos.
        /// - 404 Not Found: El producto no fue encontrado.
        /// - 500 Internal Server Error: Error al actualizar el producto.
        /// </remarks>
        /// <param name="producto">Objeto con la información actualizada del producto.</param>
        /// <returns>Retorna el producto actualizado.</returns>
        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] FoodieMatchAPI.Models.Producto producto)
        {
            try
            {
                _logger.LogInformation("ACTUALIZAR PRODUCTO");
                var actualizado = await _productoRepository.UpdateProduct(producto);
                return Ok(actualizado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar producto");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        /// <summary>
        /// Elimina un producto por su identificador.
        /// </summary>
        /// <remarks>
        /// Código de estado de respuesta:
        /// - 200 OK: Producto eliminado correctamente.
        /// - 404 Not Found: No se encontró el producto a eliminar.
        /// - 500 Internal Server Error: Error interno al eliminar el producto.
        /// </remarks>
        /// <param name="id">Identificador único del producto.</param>
        /// <returns>Retorna una confirmación de la eliminación.</returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                _logger.LogInformation("ELIMINAR PRODUCTO CON ID {Id}", id);
                var eliminado = await _productoRepository.DeleteProduct(id);
                return Ok(eliminado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar producto");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
