// --- Archivo: Venta.cs ---
// --- Proyecto: TechSolutions.Entidades ---

using System.Collections.Generic; // Necesario para List<>

namespace TechSolutions.Entidades
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public int IdCliente { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }

        // Esta es la propiedad clave para la transacción
        // Representa el "carrito de compras"
        public List<DetalleVenta> Detalles { get; set; }

        public Venta()
        {
            // Inicializamos la lista en el constructor
            // para evitar errores de referencia nula
            Detalles = new List<DetalleVenta>();
        }
    }
}