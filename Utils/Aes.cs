using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace login.Utils
{
   public  class Aes
    {
        //magicsih/
        private static RijndaelManaged rijndael = new RijndaelManaged();
        private static System.Text.UnicodeEncoding unicodeEncoding = new UnicodeEncoding();

        private const int CHUNK_SIZE = 128;

        private void InitializeRijndael()
        {
            rijndael.Mode = CipherMode.CBC;
            rijndael.Padding = PaddingMode.PKCS7;
        }

        
        
        public Aes(String base64key = "gCjK+DZ/GCYbKIGiAt1qCA==", String base64iv = "47l5QsSe1POo31adQ/u7nQ==")
        {
            InitializeRijndael();

            rijndael.KeySize = CHUNK_SIZE;
            rijndael.BlockSize = CHUNK_SIZE;

            rijndael.Key = Convert.FromBase64String(base64key);
            rijndael.IV = Convert.FromBase64String(base64iv);
            Console.WriteLine("Here bitch");
        }

        public Aes(byte[] key, byte[] iv)
        {
            InitializeRijndael();

            rijndael.Key = key;
            rijndael.IV = iv;
        }

        public string Decrypt(byte[] cipher)
        {
            ICryptoTransform transform = rijndael.CreateDecryptor();
            byte[] decryptedValue = transform.TransformFinalBlock(cipher, 0, cipher.Length);
            return unicodeEncoding.GetString(decryptedValue);
        }

        public string DecryptFromBase64String(string base64cipher)
        {
            return Decrypt(Convert.FromBase64String(base64cipher));
        }

        public byte[] EncryptToByte(string plain)
        {
            ICryptoTransform encryptor = rijndael.CreateEncryptor();
            byte[] cipher = unicodeEncoding.GetBytes(plain);
            byte[] encryptedValue = encryptor.TransformFinalBlock(cipher, 0, cipher.Length);
            return encryptedValue;
        }

        public string EncryptToBase64String(string plain)
        {
            return Convert.ToBase64String(EncryptToByte(plain));
        }

        public string GetKey()
        {
            return Convert.ToBase64String(rijndael.Key);
        }

        public string GetIV()
        {
            return Convert.ToBase64String(rijndael.IV);
        }

        public override string ToString()
        {
            return "KEY:" + GetKey() + Environment.NewLine + "IV:" + GetIV();
        }
    }
}
