using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePasswordLibrary
{
    public class PasswordTruncator
    {
        public static string GetTruncatedPassword(byte[] rawEncryption, int passwordMaxLength, string siteName, int pinNumber)
        {
            string stringRawEncyption = Convert.ToBase64String(rawEncryption);
            string truncatedFinishedPassword = TruncatePassword(stringRawEncyption, passwordMaxLength, siteName, pinNumber);
            return truncatedFinishedPassword.ToString();
        }

        private static string TruncatePassword(string stringRawEncyption, int passwordMaxLength, string siteName, int pinNumber)
        {
            StringBuilder sb = new StringBuilder(stringRawEncyption);

            int shiftIndexKey = GenerateShiftKeys.GetShiftKeys(siteName, pinNumber);
            string saltString = GeneratePasswordSalt.GetSalt(siteName, pinNumber);

            for (int i = 0; i < sb.Length; i++)
            {
                if (i == shiftIndexKey - 1) sb.Replace(sb[i], saltString[0]);
                if (i == 5 + shiftIndexKey) sb.Replace(sb[i], saltString[1]);
                if (i == shiftIndexKey + siteName.Length) sb.Replace(sb[i], saltString[2]);
                if (i == shiftIndexKey + 13) sb.Replace(sb[i], saltString[3]);
                if (i == 20 - shiftIndexKey) sb.Replace(sb[i], saltString[4]);
                // Left in for later version expansion
                if (passwordMaxLength > 20 && i == passwordMaxLength - shiftIndexKey) sb.Replace(sb[i], saltString[5]);
                if (passwordMaxLength > 30 && i == passwordMaxLength - shiftIndexKey - 3) sb.Replace(sb[i], saltString[6]);
                if (passwordMaxLength > 35 && i == passwordMaxLength - shiftIndexKey - 2) sb.Replace(sb[i], saltString[7]);
            }

            string output = sb.ToString();
            
            string truncatedFinishedPassword = output.Substring(0, passwordMaxLength);

            return truncatedFinishedPassword;


        }
    }
}
