namespace ProyectoNominas.Backend.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string NumeroIdentificacion { get; set; } = string.Empty;
        public EstadoLaboral Estado { get; set; }
        public decimal SalarioBase { get; set; }
        public int CargoId { get; set; }
        public Cargo? Cargo { get; set; }
        public int DepartamentoId { get; set; }
        public Departamento? Departamento { get; set; }
        public List<InformacionAcademica> InformacionAcademica { get; set; } = new();
        public List<Documento> Documentos { get; set; } = new();
    }
}
