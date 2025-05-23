namespace ProyectoNominas.Backend.Models
{
    public class Rol
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public List<UsuarioRol> UsuarioRoles { get; set; } = new();
    }
}
