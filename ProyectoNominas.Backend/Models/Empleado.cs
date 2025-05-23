namespace ProyectoNominas.Backend.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public string DPI { get; set; }
        public string NIT { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaContratacion { get; set; }

        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }

        public int PuestoId { get; set; }
        public Puesto Puesto { get; set; }

        public ICollection<DocumentoEmpleado> Documentos { get; set; }
        public ICollection<DetalleNomina> DetallesNomina { get; set; }
    }
}

