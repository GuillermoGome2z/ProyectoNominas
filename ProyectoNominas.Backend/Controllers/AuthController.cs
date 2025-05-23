using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoNominas.Backend.Data;
using ProyectoNominas.Backend.DTOs;
using ProyectoNominas.Backend.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ProyectoNominas.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar(UsuarioRegistroDTO dto)
        {
            if (await _context.Usuarios.AnyAsync(x => x.Correo == dto.Correo))
                return BadRequest(new { mensaje = "El correo ya está registrado." });

            var usuario = new Usuario
            {
                NombreCompleto = dto.NombreCompleto,
                Correo = dto.Correo,
                ClaveHash = BCrypt.Net.BCrypt.HashPassword(dto.Clave)
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Usuario registrado exitosamente." });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UsuarioLoginDTO dto)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.Correo == dto.Correo);
            if (usuario == null || !BCrypt.Net.BCrypt.Verify(dto.Clave, usuario.ClaveHash))
                return Unauthorized(new { mensaje = "Credenciales inválidas." });

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Email, usuario.Correo)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: cred
            );

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }
    }
}
