using System.Security.Cryptography;
using System.IO;
using System.Text;
using SimplePasswordLibrary;



bool isFinished = false;

do
{ 
    var consoleUIDisplay = new ConsoleUIDisplay();
    var startEncryption = new StartEncryption(consoleUIDisplay);
    var inputValidation = new InputValidation();
    var userInputServices = new UserInputServices(startEncryption, inputValidation);

    PasswordModel passwordModel = new PasswordModel
    {
        seedPassword = userInputServices.GetSeedPassword(),
        myKey = userInputServices.GetMyKey(),
        pinNumber = userInputServices.GetPinNumber(),
        siteName = userInputServices.GetSiteName()
    };

    var finishedPassword = startEncryption.GetFinalPassword(passwordModel);

    consoleUIDisplay.DisplayFinishedPassword(finishedPassword, passwordModel.siteName);

    Console.WriteLine();
    Console.WriteLine("Would you like to run the program again? (y/n)");
    string runAgain = Console.ReadLine();

    _ = runAgain.ToLower() == "y" ? isFinished = false : isFinished = true;

} while (isFinished == false);


// Refactor this into better DI.
// Do I need to clear memory and variables? 





