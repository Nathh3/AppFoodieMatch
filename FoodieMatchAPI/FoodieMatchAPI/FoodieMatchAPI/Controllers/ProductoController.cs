using FoodieMatchAPI.Repository.Implements;
using FoodieMatchAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodieMatchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IProductoQuery _productoQuery;
        private readonly ILogger<ProductoController> _logger;

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
