﻿using System.Text.Json.Serialization;

namespace ProyectoNominas.Backend.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; } = null!;
        public string DPI { get; set; } = null!;
        public string NIT { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public DateTime FechaContratacion { get; set; }

        // Relaciones con clave foránea
        public int DepartamentoId { get; set; }

        [JsonIgnore] // No se requiere en POST ni PUT
        public Departamento? Departamento { get; set; }

        public int PuestoId { get; set; }

        [JsonIgnore] // No se requiere en POST ni PUT
        public Puesto? Puesto { get; set; }

        // Relaciones de colección
        [JsonIgnore]
        public ICollection<DocumentoEmpleado>? Documentos { get; set; }

        [JsonIgnore]
        public ICollection<DetalleNomina>? DetallesNomina { get; set; }
    }
}

