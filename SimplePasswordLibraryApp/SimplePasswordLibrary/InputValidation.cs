using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePasswordLibrary
{
    public interface IInputValidation
    {
        bool ValidateSeedPassword(string? rawSeedPassword);
        bool ValidateMyKey(string? input);
        bool ValidatePinNumber(string? input);
        bool ValidateSiteName(string? input);
    }
    public class InputValidation : IInputValidation
    {
        public bool ValidateSeedPassword(string? rawSeedPassword)
        {
            return rawSeedPassword.Length < 10 || rawSeedPassword == null;
        }
        public bool ValidateMyKey(string? myKey)
        {
            return myKey.Length < 16 || myKey.Length > 16;
        }

        public bool ValidatePinNumber(string? stringPinNumber)
        {
            return stringPinNumber.Length < 4 || stringPinNumber.Length > 4;                      
        }
        public bool ValidateSiteName(string? input)
        {
            return input == null || input == "";           
        }
    }   
}
