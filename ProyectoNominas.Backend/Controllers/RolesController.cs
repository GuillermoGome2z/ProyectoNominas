using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoNominas.Backend.Data;
using ProyectoNominas.Backend.Models;

namespace ProyectoNominas.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RolesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Roles
        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var roles = await _context.Roles.ToListAsync();
            return Ok(roles);
        }

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRol(int id)
        {
            var rol = await _context.Roles.FindAsync(id);

            if (rol == null)
                return NotFound();

            return Ok(rol);
        }

        // POST: api/Roles
        [HttpPost]
        public async Task<IActionResult> CrearRol([FromBody] Rol rol)
        {
            _context.Roles.Add(rol);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetRol), new { id = rol.Id }, rol);
        }

        // PUT: api/Roles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarRol(int id, [FromBody] Rol rol)
        {
            if (id != rol.Id)
                return BadRequest();

            _context.Entry(rol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Roles.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarRol(int id)
        {
            var rol = await _context.Roles.FindAsync(id);
            if (rol == null)
                return NotFound();

            _context.Roles.Remove(rol);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
