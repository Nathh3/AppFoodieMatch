using FoodieMatchAPI.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FoodieMatchAPI.Controllers
{
    /// <summary>
    /// Controlador encargado de gestionar las operaciones relacionadas con los usuarios
    /// dentro de la API de FoodieMatch. 
    /// Permite listar, crear, actualizar y eliminar usuarios.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioQuery _usuarioQuery;
        private readonly ILogger<UsuarioController> _logger;

        /// <summary>
        /// Constructor del controlador de usuarios.
        /// Inicializa las dependencias necesarias para el manejo de las operaciones CRUD.
        /// </summary>
        /// <param name="usuarioRepository">Repositorio encargado de las operaciones de escritura sobre los usuarios.</param>
        /// <param name="usuarioQuery">Componente encargado de las consultas (lecturas) a la base de datos relacionadas con usuarios.</param>
        /// <param name="logger">Interfaz de logging para registrar información y errores durante la ejecución.</param>
        public UsuarioController(IUsuarioRepository usuarioRepository, IUsuarioQuery usuarioQuery, ILogger<UsuarioController> logger)
        {
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
            _usuarioQuery = usuarioQuery ?? throw new ArgumentNullException(nameof(usuarioQuery));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        /// <summary>
        /// Obtiene el listado completo de usuarios registrados en el sistema.
        /// </summary>
        /// <remarks>
        /// Código de estado de respuesta:
        /// - 200 OK: La consulta se realizó correctamente.
        /// - 500 Internal Server Error: Ocurrió un error inesperado en el servidor.
        /// </remarks>
        /// <returns>Retorna una lista con todos los usuarios registrados.</returns>
        /// 
        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            try
            {
                _logger.LogInformation("CONSULTAR TODOS LOS USUARIOS");
                var rs = await _usuarioQuery.GetAll();
                _logger.LogTrace(rs.ToString());
                return Ok(rs);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al listar usuarios");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        /// <summary>
        /// Crea un nuevo usuario en el sistema.
        /// </summary>
        /// <remarks>
        /// Código de estado de respuesta:
        /// - 201 Created: Usuario creado exitosamente.
        /// - 400 Bad Request: Los datos enviados no son válidos.
        /// - 500 Internal Server Error: Error al intentar crear el usuario.
        /// </remarks>
        /// <param name="usuario">Objeto que contiene la información del nuevo usuario a registrar.</param>
        /// <returns>Retorna el usuario creado.</returns>

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] FoodieMatchAPI.Models.Usuario usuario)
        {
            try
            {
                _logger.LogInformation("CREAR NUEVO USUARIO");
                var nuevo = await _usuarioRepository.CreateUser(usuario);
                return Ok(nuevo);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear usuario");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        /// <summary>
        /// Actualiza la información de un usuario existente.
        /// </summary>
        /// <remarks>
        /// Código de estado de respuesta:
        /// - 200 OK: Usuario actualizado correctamente.
        /// - 400 Bad Request: Los datos enviados son inválidos.
        /// - 404 Not Found: El usuario no fue encontrado.
        /// - 500 Internal Server Error: Error al actualizar el usuario.
        /// </remarks>
        /// <param name="usuario">Objeto con la información actualizada del usuario.</param>
        /// <returns>Retorna el usuario actualizado.</returns>
        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] FoodieMatchAPI.Models.Usuario usuario)
        {
            try
            {
                _logger.LogInformation("ACTUALIZAR USUARIO");
                var actualizado = await _usuarioRepository.UpdateUser(usuario);
                return Ok(actualizado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar usuario");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        /// <summary>
        /// Elimina un usuario por su identificador.
        /// </summary>
        /// <remarks>
        /// Código de estado de respuesta:
        /// - 200 OK: Usuario eliminado correctamente.
        /// - 404 Not Found: No se encontró el usuario a eliminar.
        /// - 500 Internal Server Error: Error interno al eliminar el usuario.
        /// </remarks>
        /// <param name="id">Identificador único del usuario.</param>
        /// <returns>Retorna una confirmación de la eliminación.</returns>



        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                _logger.LogInformation("ELIMINAR USUARIO CON ID {Id}", id);
                var eliminado = await _usuarioRepository.DeleteUser(id);
                return Ok(eliminado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar usuario");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }

}
