using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePasswordLibrary
{
    public static class GeneratePasswordSalt
    {
        private static readonly string saltValues = @"`~!@#$%^&*()_+-={\}][:;'<>.?/|\~!@#$%^&*()_+-={*\}]$%^[:;'<>.?/|\@#$%^&*[:;'<";

        public static string GetSalt(string siteName, int pinNumber)
        {
            string saltString = GenerateSalt(siteName, pinNumber);
            return saltString;
        }

        private static string GenerateSalt(string siteName, int pinNumber)
        {
            string stringPinNumber = pinNumber.ToString();
            int stringPinLength = stringPinNumber.Length;
            int siteNameLength = siteName.Length;
            int saltMultiplier = 0;

            if (siteNameLength <= 10)
            {
                saltMultiplier = 5;
            }
            else if (siteNameLength > 10)
            {
                saltMultiplier = 3;
            }

            int num1 = stringPinLength + saltMultiplier;
            int num2 = stringPinLength + siteNameLength;
            int num3 = stringPinLength * 3 + saltMultiplier;
            int num4 = stringPinLength * saltMultiplier;
            int num5 = num3 - saltMultiplier;
            int num6 = num1 + num2;
            int num7 = (num2 + num3) - 7;
            int num8 = num4 -3;

            int[] saltArray = { num1, num2, num3, num4, num5, num6, num7, num8 };
            string saltString = "";

            for (int i = 0; i < saltArray.Length; i++)
            {
                saltString += saltValues[saltArray[i]];
            }            

            return saltString;
        }
    }
}
