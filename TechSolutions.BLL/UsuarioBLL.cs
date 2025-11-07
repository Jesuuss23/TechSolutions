// --- Archivo: UsuarioBLL.cs ---
// --- Proyecto: TechSolutions.BLL ---

// Necesitamos 'usings' para las otras dos capas y para la seguridad
using TechSolutions.DAL;
using TechSolutions.Entidades;
using System.Security.Cryptography; // Para la clase SHA512

namespace TechSolutions.BLL
{
    public class UsuarioBLL
    {
        // Creamos una instancia de nuestra DAL de Usuario.
        // La BLL le dará órdenes a esta instancia.
        private readonly UsuarioDAL _usuarioDAL = new UsuarioDAL();

        /// <summary>
        /// Lógica de negocio para validar un usuario.
        /// </summary>
        /// <param name="nombreUsuario">El nombre de usuario en texto plano.</param>
        /// <param name="password">La contraseña en texto plano.</param>
        /// <returns>Un objeto Usuario si es exitoso, o null si falla.</returns>
        public Usuario Login(string nombreUsuario, string password)
        {
            // --- INICIO DE LA LÓGICA DE NEGOCIO ---

            // Regla 1: Validar entradas
            if (string.IsNullOrEmpty(nombreUsuario) || string.IsNullOrEmpty(password))
            {
                // No tiene sentido ir a la BD si los campos están vacíos.
                return null;
            }

            // Regla 2: Convertir la contraseña a Hash (SHA-512)
            // Aquí usamos la clase 'SeguridadHelper' que creamos antes.
            byte[] passwordHash = SeguridadHelper.GenerarHashSHA512(password);

            // --- FIN DE LA LÓGICA DE NEGOCIO ---

            // 3. Llamar a la Capa de Datos (DAL)
            // La BLL no sabe CÓMO se loguea, solo le dice a la DAL:
            // "Toma estas credenciales hasheadas y valídalas".
            Usuario usuario = _usuarioDAL.Login(nombreUsuario, passwordHash);

            // 4. Devolver el resultado a la Capa de Presentación
            return usuario;
        }

        // Aquí podrías añadir más lógicas de negocio, como:
        // public void CrearUsuario(Usuario nuevoUsuario) { ... }
        // public void CambiarPassword(int idUsuario, string nuevaPassword) { ... }
    }
}