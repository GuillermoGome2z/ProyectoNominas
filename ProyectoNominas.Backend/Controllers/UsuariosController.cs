using Microsoft.AspNetCore.Mvc;

namespace ProyectoNominas.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        [HttpGet]
        public IActionResult ObtenerUsuarios()
        {
            return Ok(new { mensaje = "Controlador de Usuarios funcionando correctamente." });
        }
    }
}
