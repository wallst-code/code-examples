using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePasswordLibrary
{
   static class GenerateShiftKeys
    {
        public static int GetShiftKeys(string siteName, int pinNumber)
        {
            int shiftKey;
            return shiftKey = GenerateShiftKey(siteName, pinNumber);
        }

        private static int GenerateShiftKey(string siteName, int pinNumber)
        {
            int pinNumberShift = 0;
            int output = 0;

            if (pinNumber > 1 && pinNumber <= 500) pinNumberShift = 1;
            if (pinNumber > 500 && pinNumber <= 1000) pinNumberShift = 2;
            if (pinNumber > 1000 && pinNumber <= 3000) pinNumberShift = 4;
            if (pinNumber > 3000) pinNumberShift = 0;

            if (siteName.Length <= 5) return output = 1 + pinNumberShift;
            if (siteName.Length > 5 && siteName.Length <= 10) return output = 3 + pinNumberShift;
            if (siteName.Length > 10 && siteName.Length <= 15) return output = 4 + pinNumberShift;
            if (siteName.Length > 15) return output = 5 + pinNumberShift;

            return output;
        }     
    }
}
