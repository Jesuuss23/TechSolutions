// --- Archivo: DetalleVenta.cs ---
// --- Proyecto: TechSolutions.Entidades ---

namespace TechSolutions.Entidades
{
    public class DetalleVenta
    {
        public int IdDetalle { get; set; }
        public int IdVenta { get; set; } // Relación con la cabecera
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; } // El SP lo calcula, pero es bueno tenerlo

        // Propiedades adicionales útiles (opcional pero recomendado)
        public string NombreProducto { get; set; }
    }
}