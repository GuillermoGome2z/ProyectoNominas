using Microsoft.EntityFrameworkCore;
using ProyectoNominas.Backend.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ProyectoNominas.Backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Seguridad
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<UsuarioRol> UsuarioRoles { get; set; }

        // Recursos Humanos
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Puesto> Puestos { get; set; }

        // Nómina
        public DbSet<Nomina> Nominas { get; set; }
        public DbSet<DetalleNomina> DetallesNomina { get; set; }
        public DbSet<Deduccion> Deducciones { get; set; }
        public DbSet<Bonificacion> Bonificaciones { get; set; }

        // Documentos
        public DbSet<TipoDocumento> TiposDocumento { get; set; }
        public DbSet<DocumentoEmpleado> DocumentosEmpleado { get; set; }

        // Auditoría
        public DbSet<Auditoria> Auditorias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Llave compuesta
            modelBuilder.Entity<UsuarioRol>().HasKey(ur => new { ur.UsuarioId, ur.RolId });
        }
    }
}
