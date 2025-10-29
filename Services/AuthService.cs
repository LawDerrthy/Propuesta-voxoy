using System;
using System.Collections.Generic;
using System.Linq;
using InventarioApp.Models;

namespace InventarioApp.Services
{
    public class AuthService
    {
        private static List<Usuario> _usuarios = new List<Usuario>();
        private static int _ultimoId = 0;
        private static Dictionary<string, string> _codigosVerificacion = new Dictionary<string, string>();

        public bool RegistrarUsuario(string email, string contraseña)
        {
            // Verificar si el usuario ya existe
            if (_usuarios.Any(u => u.Email == email))
            {
                return false;
            }

            // Crear nuevo usuario
            var nuevoUsuario = new Usuario
            {
                Id = ++_ultimoId,
                Email = email,
                Contraseña = contraseña, // En una aplicación real, esto debería estar encriptado
                NombreCompleto = email.Split('@')[0], // Usar parte del email como nombre
                NombreUsuario = email.Split('@')[0],
                Activo = false // No activo hasta verificar email
            };

            _usuarios.Add(nuevoUsuario);
            return true;
        }

        public string GenerarCodigoVerificacion(string email)
        {
            var random = new Random();
            var codigo = random.Next(100000, 999999).ToString();
            _codigosVerificacion[email] = codigo;
            
            // En una aplicación real, aquí se enviaría el email
            // Por ahora solo lo mostramos en consola para testing
            Console.WriteLine($"Código de verificación para {email}: {codigo}");
            
            return codigo;
        }

        public bool VerificarCodigo(string email, string codigo)
        {
            if (_codigosVerificacion.ContainsKey(email) && _codigosVerificacion[email] == codigo)
            {
                // Activar usuario
                var usuario = _usuarios.FirstOrDefault(u => u.Email == email);
                if (usuario != null)
                {
                    usuario.Activo = true;
                    _codigosVerificacion.Remove(email);
                    return true;
                }
            }
            return false;
        }

        public Usuario IniciarSesion(string email, string contraseña)
        {
            return _usuarios.FirstOrDefault(u => 
                u.Email == email && 
                u.Contraseña == contraseña && 
                u.Activo);
        }

        public bool ValidarEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}

