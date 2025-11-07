using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechSolutions.Entidades
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Email { get; set; }
        // Nota: NO incluimos el PasswordHash aquí.
        // Las entidades deben representar datos seguros para mover por la app.
        // El hash solo se usa para validar, no se almacena en la entidad.

        public int IdRol { get; set; }
        public string NombreRol { get; set; } // Útil para mostrar en la UI
        public bool Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime? UltimoAcceso { get; set; } // '?' permite valores nulos
    }
}