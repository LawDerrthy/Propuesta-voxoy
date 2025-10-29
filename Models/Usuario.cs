using System;

namespace InventarioApp.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Activo { get; set; }

        public Usuario()
        {
            FechaRegistro = DateTime.Now;
            Activo = true;
        }
    }
}

