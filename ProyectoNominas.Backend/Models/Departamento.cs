﻿namespace ProyectoNominas.Backend.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<Empleado> Empleados { get; set; }
    }
}
