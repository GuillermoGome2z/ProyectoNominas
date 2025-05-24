﻿using System.Text.Json.Serialization;

namespace ProyectoNominas.Backend.Models
{
    public class Rol
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        [JsonIgnore] // ✅ Evita ciclos infinitos o errores de serialización
        public ICollection<UsuarioRol> UsuarioRoles { get; set; } = new List<UsuarioRol>();
    }
}
