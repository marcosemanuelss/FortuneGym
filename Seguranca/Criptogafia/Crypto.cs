using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Globalization;
using System.Configuration;
using System.Text.RegularExpressions;

namespace SIC.Seguranca
{
    /// <summary>
    /// Cryptographic utility class for encryption and decryption of string values.
    /// </summary>
    public static class Crypto
    {
        // Arbitrary key and iv vector. 
        // You will want to generate (and protect) your own Key and Iv when using encryption.
        private readonly static string actionKey;
        private readonly static string actionIv;

        private static TripleDESCryptoServiceProvider des3;

        /// <summary>
        /// Default constructor. Initializes the DES3 encryption provider. 
        /// </summary>
        static Crypto()
        {
            if (ConfigurationManager.AppSettings["actionKey"] == null)
            {
                throw new ConfigurationErrorsException("chave não encontrada. actionKey");
            }

            if (ConfigurationManager.AppSettings["actionIv"] == null)
            {
                throw new ConfigurationErrorsException("chave não encontrada. actionIv");
            }

            actionKey = ConfigurationManager.AppSettings["actionKey"].ToString();
            actionIv = ConfigurationManager.AppSettings["actionIv"].ToString();
            des3 = new TripleDESCryptoServiceProvider();
            des3.Mode = CipherMode.CBC;
        }

        /// <summary>
        /// Generates a 24 byte Hex key.
        /// </summary>
        /// <returns>Generated Hex key.</returns>
        public static string GenerateKey()
        {
            // Length is 24
            des3.GenerateKey();
            return BytesToHex(des3.Key);
        }

        /// <summary>
        /// Generates an 8 byte Hex IV (Initialization Vector).
        /// </summary>
        /// <returns>Initialization vector.</returns>
        public static string GenerateIV()
        {
            // Length = 8
            des3.GenerateIV();
            return BytesToHex(des3.IV);
        }

        /// <summary>
        /// Converts a hex string to a byte array.
        /// </summary>
        /// <param name="hex">Hex string.</param>
        /// <returns>Byte array.</returns>
        private static byte[] HexToBytes(string hex)
        {
            byte[] bytes = new byte[hex.Length / 2];
            for (int i = 0; i < hex.Length / 2; i++)
            {
                string code = hex.Substring(i * 2, 2);
                bytes[i] = byte.Parse(code, NumberStyles.HexNumber);
            }
            return bytes;
        }

        /// <summary>
        /// Converts a byte array to a hex string.
        /// </summary>
        /// <param name="bytes">Byte array.</param>
        /// <returns>Converted hex string</returns>
        private static string BytesToHex(byte[] bytes)
        {
            var hex = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
                hex.AppendFormat("{0:X2}", bytes[i]);
            return hex.ToString();
        }

        /// <summary>
        /// Encrypts a memory string (i.e. variable).
        /// </summary>
        /// <param name="data">String to be encrypted.</param>
        /// <param name="key">Encryption key.</param>
        /// <param name="iv">Encryption initialization vector.</param>
        /// <returns>Encrypted string.</returns>
        public static string Encrypt(string data, string key, string iv)
        {
            byte[] bdata = Encoding.ASCII.GetBytes(data);
            byte[] bkey = HexToBytes(key);
            byte[] biv = HexToBytes(iv);

            var stream = new MemoryStream();
            var encStream = new CryptoStream(stream, 
                des3.CreateEncryptor(bkey,biv), CryptoStreamMode.Write);

            encStream.Write(bdata, 0, bdata.Length);
            encStream.FlushFinalBlock();
            encStream.Close();

            return BytesToHex(stream.ToArray());
        }

        /// <summary>
        /// Decrypts a memory string (i.e. variable).
        /// </summary>
        /// <param name="data">String to be decrypted.</param>
        /// <param name="key">Original encryption key.</param>
        /// <param name="iv">Original initialization vector.</param>
        /// <returns>Decrypted string.</returns>
        public static string Decrypt(string data, string key, string iv)
        {
            byte[] bdata = HexToBytes(data);
            byte[] bkey = HexToBytes(key);
            byte[] biv = HexToBytes(iv);

            var stream = new MemoryStream();
            var encStream = new CryptoStream(stream, 
                des3.CreateDecryptor(bkey, biv), CryptoStreamMode.Write);

            encStream.Write(bdata, 0, bdata.Length);
            encStream.FlushFinalBlock();
            encStream.Close();

            return Encoding.ASCII.GetString(stream.ToArray());
        }

        /// <summary>
        /// Standard encrypt method for Patterns in Action.
        /// Uses the predefined key and iv.
        /// </summary>
        /// <param name="data">String to be encrypted.</param>
        /// <returns>Encrypted string</returns>
        public static string ActionEncrypt(string data)
        {
            return Encrypt(data, actionKey, actionIv);
        }

        /// <summary>
        /// Standard decrypt method for Patterns in Action.
        /// Uses the predefined key and iv.
        /// </summary>
        /// <param name="data">String to be decrypted.</param>
        /// <returns>Decrypted string.</returns>
        public static string ActionDecrypt(string data)
        {
            return Decrypt(data, actionKey, actionIv);
        }

        public static bool SenhaForte(string senha)
        {
            int tamanhoMaximo = 8;
            int tamanhoMinimo = 6;
            int qtdeMinimoLetras = 1;
            int qtdeMinimoNumeros = 1;
            int qtdeCaracteresEspeciais = 1;
 
            // Letras
            Regex regQtdeMinimoLetras = new Regex("[a-zA-Z]");
 
            // Números
            Regex regQtdeNumeros = new Regex("[0-9]");
 
            // Caracteres especiais
            Regex regQtdeCaracteresEspeciais = new Regex("[^a-zA-Z0-9]");
 
            // Tamanho minimo e máximo
            if (senha.Length < tamanhoMinimo || senha.Length > tamanhoMaximo) 
                return false;
 
            // Verificando caracteres maiusculos
            if (regQtdeMinimoLetras.Matches(senha).Count < qtdeMinimoLetras) 
                return false;
 
            // Verificando numeros
            if (regQtdeNumeros.Matches(senha).Count < qtdeMinimoNumeros) 
                return false;
 
            // Verificando os diferentes
            if (regQtdeCaracteresEspeciais.Matches(senha).Count < qtdeCaracteresEspeciais) 
                return false;
 
            return true;


        }

    }
}



