using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoNominas.Backend.Data;
using ProyectoNominas.Backend.Models;

namespace ProyectoNominas.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DepartamentosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Departamentos
        [HttpGet]
        public async Task<IActionResult> GetDepartamentos()
        {
            var departamentos = await _context.Departamentos.ToListAsync();
            return Ok(departamentos);
        }

        // GET: api/Departamentos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartamento(int id)
        {
            var departamento = await _context.Departamentos.FindAsync(id);

            if (departamento == null)
                return NotFound();

            return Ok(departamento);
        }

        // POST: api/Departamentos
        [HttpPost]
        public async Task<IActionResult> CrearDepartamento([FromBody] Departamento departamento)
        {
            _context.Departamentos.Add(departamento);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDepartamento), new { id = departamento.Id }, departamento);
        }

        // PUT: api/Departamentos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarDepartamento(int id, [FromBody] Departamento departamento)
        {
            if (id != departamento.Id)
                return BadRequest();

            _context.Entry(departamento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Departamentos.Any(d => d.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Departamentos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarDepartamento(int id)
        {
            var departamento = await _context.Departamentos.FindAsync(id);
            if (departamento == null)
                return NotFound();

            _context.Departamentos.Remove(departamento);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
