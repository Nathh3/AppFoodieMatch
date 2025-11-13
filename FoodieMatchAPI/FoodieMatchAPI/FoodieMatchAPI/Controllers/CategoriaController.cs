using FoodieMatchAPI.Repository.Implements;
using FoodieMatchAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FoodieMatchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly ICategoriaQuery _categoriaQuery;
        private readonly ILogger<CategoriaController> _logger;

    public CategoriaController(ICategoriaRepository categoriaRepository, ICategoriaQuery categoriaQuery, ILogger<CategoriaController> logger)
        {
            _categoriaRepository = categoriaRepository ?? throw new ArgumentNullException(nameof(categoriaRepository));
            _categoriaQuery = categoriaQuery ?? throw new ArgumentNullException(nameof(categoriaQuery));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


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
