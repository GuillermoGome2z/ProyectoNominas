namespace ProyectoNominas.Backend.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string ContrasenaHash { get; set; } = string.Empty;
        public bool EstaActivo { get; set; } = true;
        public List<UsuarioRol> UsuarioRoles { get; set; } = new();
    }
}
