using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace SimplePasswordLibrary
{
    public class StartEncryption : IStartEncryption
    {
        private static readonly byte[] _IV = { 14, 0, 39, 7, 123, 75, 3, 232, 23, 30, 65, 99, 13, 56, 9, 205 };
        private readonly int _passwordMaxLength = 44;


        private IConsoleUIDisplay _consoleDisplay;

        public StartEncryption(IConsoleUIDisplay consoleUIDisplay)
        {
            _consoleDisplay = consoleUIDisplay;
        }

        public string GetFinalPassword(PasswordModel passwordModel)
        {           
            byte[] iV = _IV;
            byte[] key = Encoding.UTF8.GetBytes(passwordModel.myKey);
            string newPassword = passwordModel.seedPassword + passwordModel.siteName;

            using (Aes myAes = Aes.Create())
            {
                byte[] rawEncryption = EncryptStringToBytes_Aes(newPassword, key, iV);
                string truncatedPassword = PasswordTruncator.GetTruncatedPassword(rawEncryption, _passwordMaxLength, passwordModel.siteName, passwordModel.pinNumber);

                return truncatedPassword;                
            }                                
        }

        private byte[] EncryptStringToBytes_Aes(string newPassword, byte[] key, byte[] IV)
        {
            //Check arguments.
            if (newPassword == null || newPassword.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;
            
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(newPassword);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }
    }
}
