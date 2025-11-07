// --- Este archivo va en TechSolutions.BLL ---

using System.Security.Cryptography;
using System.Text;

namespace TechSolutions.BLL
{
    public static class SeguridadHelper
    {
        /// <summary>
        /// Genera un hash SHA-512 a partir de un string de entrada (contraseña).
        /// </summary>
        /// <param name="texto">La contraseña en texto plano.</param>
        /// <returns>Un array de bytes (byte[]) con el hash SHA-512 (64 bytes).</returns>
        public static byte[] GenerarHashSHA512(string texto)
        {
            if (string.IsNullOrEmpty(texto))
            {
                // Devolvemos un array vacío si la entrada es nula o vacía
                // Tu lógica de negocio debería validar esto antes de llamar al método
                return new byte[0];
            }

            using (SHA512 sha512 = SHA512.Create())
            {
                // Convertir el string de la contraseña a un array de bytes
                byte[] bytesEntrada = Encoding.UTF8.GetBytes(texto);

                // Calcular el hash
                byte[] bytesHash = sha512.ComputeHash(bytesEntrada);

                // Devolver el hash (64 bytes)
                return bytesHash;
            }
        }
    }
}