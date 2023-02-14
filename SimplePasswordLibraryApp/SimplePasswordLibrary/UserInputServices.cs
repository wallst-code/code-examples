using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePasswordLibrary
{
    public class UserInputServices
    {
        private readonly IStartEncryption _startEncryption;
        private readonly IInputValidation _inputValidation;

        public UserInputServices(IStartEncryption startEncryption, IInputValidation inputValidation)
        {
            _startEncryption = startEncryption;
            _inputValidation = inputValidation;
        }

        public string GetSeedPassword()
        {
            Console.WriteLine("Please enter your seed password (min 10 characters): ");
            var seedPassword = Console.ReadLine();

            do
            {
                if (_inputValidation.ValidateSeedPassword(seedPassword))
                {
                    Console.WriteLine("Error: Password must be a minimum of 10 characters. Please try again.");
                    Console.WriteLine("Please enter your seed password: ");
                    seedPassword = Console.ReadLine();
                }
            } while (_inputValidation.ValidateSeedPassword(seedPassword));

            return seedPassword;
        }

        public string GetMyKey()
        {
            Console.WriteLine("Please enter your 16 character Key: ");
            string myKey = Console.ReadLine();

            do
            {
                if (_inputValidation.ValidateMyKey(myKey))
                {
                    Console.WriteLine("Error: Your Key must be 16 characters in length. Please try again.");

                    Console.WriteLine("Please enter your 16 character Key: ");
                    myKey = Console.ReadLine();
                }

            } while (_inputValidation.ValidateMyKey(myKey));

            return myKey;
        }

        public int GetPinNumber()
        {
            Console.WriteLine("Please enter your 4-digit Pin Number: ");
            string stringPinNumber = Console.ReadLine();

            do
            {
                if (_inputValidation.ValidatePinNumber(stringPinNumber))
                {
                    Console.WriteLine("Error: Your Pin Number must be exactly 4-digits in length. Please try again.");

                    Console.WriteLine("Please enter your 4-digit Pin Number: ");
                    stringPinNumber = Console.ReadLine();
                }

            } while (_inputValidation.ValidatePinNumber(stringPinNumber));           
            return ConvertStringPinNumber(stringPinNumber);
        }

        private int ConvertStringPinNumber(string? stringPinNumber)
        {
            bool isNumber = int.TryParse(stringPinNumber, out int output);

            if (isNumber == false)
            {
                Console.WriteLine("Error -- please renenter your 4-digit Pin Number using only number digits and NOT letter or symbols.");
                GetPinNumber();
            }

            return output;
        }
        public string GetSiteName()
        {
            Console.WriteLine("Next, you will need to enter the store or service name for this password. Example: Amazon.com or amazon. This information will help you know what the password is for and it is required.");
            Console.WriteLine("Please enter the store name or service name (ex. amazon.com) that relates to this password: ");
            string input = Console.ReadLine();
        
            if (_inputValidation.ValidateSiteName(input))
            {
                GetSiteName();
            }
            else if (input.Length < 3)
            {
                Console.WriteLine("Error: please provide a site name that is 3+ characters in length. Try entering it again.");
                GetSiteName();
            }
            else if (input.Length > 15)
            {
                string oldInput = input;
                string newInput = oldInput.Substring(0, 15);
                input = newInput.ToUpper();
            }
            else
            {
                input = input.ToUpper();
            }

            return input;
        }        
    }
}