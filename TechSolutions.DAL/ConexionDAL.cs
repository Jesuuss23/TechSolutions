// --- Archivo: ConexionDAL.cs ---
// --- Proyecto: TechSolutions.DAL ---

// Estos 'usings' son necesarios
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace TechSolutions.DAL
{
    /// <summary>
    /// Implementación del PATRÓN SINGLETON para gestionar la cadena de conexión.
    /// Esto asegura que solo exista UNA instancia de esta clase
    /// y que la cadena de conexión se lea del App.config una sola vez.
    /// </summary>
    public class ConexionDAL
    {
        // 1. Variable estática privada para guardar la única instancia
        private static readonly ConexionDAL _instancia = new ConexionDAL();

        // 2. Variable privada para almacenar la cadena de conexión
        private readonly string _cadenaConexion;

        // 3. Constructor PRIVADO: Esto evita que se creen instancias
        //    con 'new ConexionDAL()' desde fuera de la clase.
        private ConexionDAL()
        {
            // Lee la cadena de conexión desde el App.config
            _cadenaConexion = ConfigurationManager.ConnectionStrings["TechSolutionsConnection"].ConnectionString;
        }

        // 4. Propiedad estática PÚBLICA para acceder a la única instancia
        //    Esta es la forma de usar el Singleton: ConexionDAL.Instancia
        public static ConexionDAL Instancia
        {
            get { return _instancia; }
        }

        // 5. Método público que entrega una NUEVA conexión 
        //    configurada con la cadena de conexión.
        public SqlConnection GetConexion()
        {
            // Devuelve un nuevo objeto SqlConnection
            // La capa de negocio (BLL) o los métodos de esta DAL
            // serán responsables de abrirla y cerrarla (usando 'using').
            return new SqlConnection(_cadenaConexion);
        }
    }
}