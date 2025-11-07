// --- Archivo: UsuarioDAL.cs ---
// --- Proyecto: TechSolutions.DAL ---

// Estos son los 'usings' que necesitamos
using Microsoft.Data.SqlClient;
using System.Data;
using TechSolutions.Entidades; // ¡Importante! Para usar la clase 'Usuario'

namespace TechSolutions.DAL
{
    public class UsuarioDAL
    {
        /// <summary>
        /// Valida las credenciales de un usuario contra la base de datos
        /// usando el Stored Procedure 'sp_LoginUsuario'.
        /// </summary>
        /// <param name="nombreUsuario">El nombre de usuario.</param>
        /// <param name="passwordHash">El HASH (SHA-512) de la contraseña.</param>
        /// <returns>Un objeto Usuario si es exitoso, o null si falla.</returns>
        public Usuario Login(string nombreUsuario, byte[] passwordHash)
        {
            Usuario usuarioLogueado = null;

            // Obtenemos la conexión desde nuestro Singleton
            // 'using' asegura que la conexión se cierre al final
            using (SqlConnection conexion = ConexionDAL.Instancia.GetConexion())
            {
                // 1. Crear el comando y especificar que es un SP
                using (SqlCommand comando = new SqlCommand("sp_LoginUsuario", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    // 2. Añadir los parámetros que espera el SP
                    comando.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                    comando.Parameters.AddWithValue("@PasswordHash", passwordHash);

                    try
                    {
                        // 3. Abrir la conexión
                        conexion.Open();

                        // 4. Ejecutar el comando y obtener un lector
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            // 5. ¿El lector encontró un registro?
                            if (reader.Read())
                            {
                                // 6. Sí, creamos el objeto Usuario con los datos
                                usuarioLogueado = new Usuario
                                {
                                    IdUsuario = reader.GetInt32("IdUsuario"),
                                    NombreUsuario = reader.GetString("NombreUsuario"),
                                    NombreRol = reader.GetString("NombreRol")
                                    // Nota: Tu SP 'sp_LoginUsuario' debe devolver estas 3 columnas
                                };
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        // Aquí podrías registrar el error en un log si quisieras
                        // Por ahora, solo lo lanzamos para que la BLL lo vea
                        throw new Exception("Error en la base de datos al intentar loguear: " + ex.Message);
                    }
                }
            } // La conexión se cierra automáticamente aquí

            // 7. Devolver el usuario (o null si el login falló)
            return usuarioLogueado;
        }
    }
}