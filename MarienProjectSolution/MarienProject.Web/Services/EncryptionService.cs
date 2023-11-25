using System.Security.Cryptography;
using System.Text;

namespace MarienProject.Web.Services
{
    public class EncryptionService
    {
        private readonly string _encryptionKey;

        public EncryptionService(string encryptionKey)
        {
            _encryptionKey = encryptionKey;
        }
        /// <summary>
        /// Cifra el dato proporcionado utilizando el algoritmo de cifrado AES.
        /// </summary>
        /// <param name="data">El dato a cifrar.</param>
        /// <returns>El dato cifrado en formato Base64.</returns>
        public string Encrypt(string data)
        {
            // Crea una instancia del algoritmo de cifrado simétrico avanzado (AES)
            using (Aes aesAlg = Aes.Create())
            {
                // Establece la clave de cifrado para el algoritmo AES
                aesAlg.Key = Encoding.UTF8.GetBytes(_encryptionKey);

                // Puedes generar un Vector de Inicialización (IV) único para cada dato
                aesAlg.IV = new byte[16];

                // Crea un transformador de cifrado para realizar la operación de cifrado
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Crea un flujo de memoria para contener el resultado cifrado
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    // Crea un flujo de cifrado para escribir los datos cifrados en el flujo de memoria
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        // Crea un escritor para escribir en el flujo de cifrado
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            // Escribe los datos en el flujo de cifrado
                            swEncrypt.Write(data);
                        }
                    }

                    // Convierte el resultado cifrado a formato Base64 y lo retorna
                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        /// <summary>
        /// Descifra el dato cifrado proporcionado utilizando el algoritmo de cifrado AES.
        /// </summary>
        /// <param name="encryptedData">El dato cifrado en formato Base64.</param>
        /// <returns>El dato descifrado.</returns>
        public string Decrypt(string encryptedData)
        {
            // Crea una instancia del algoritmo de cifrado simétrico avanzado (AES)
            using (Aes aesAlg = Aes.Create())
            {
                // Establece la clave de cifrado para el algoritmo AES
                aesAlg.Key = Encoding.UTF8.GetBytes(_encryptionKey);

                // Puedes obtener el Vector de Inicialización (IV) desde los datos cifrados
                aesAlg.IV = new byte[16]; // En este ejemplo, se establece un IV predeterminado

                // Crea un transformador de cifrado para realizar la operación de descifrado
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Convierte el dato cifrado (en formato Base64) de vuelta a un array de bytes
                byte[] encryptedBytes = Convert.FromBase64String(encryptedData);

                // Crea un flujo de memoria para contener el resultado descifrado
                using (MemoryStream msDecrypt = new MemoryStream(encryptedBytes))
                {
                    // Crea un flujo de cifrado para leer los datos cifrados del flujo de memoria
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        // Crea un lector para leer desde el flujo de cifrado
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Lee los datos descifrados desde el flujo de cifrado y los retorna
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
