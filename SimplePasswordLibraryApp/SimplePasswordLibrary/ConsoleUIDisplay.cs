using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePasswordLibrary
{
    public class ConsoleUIDisplay : IConsoleUIDisplay
    {        
        public void DisplayFinishedPassword(string finishedPassword, string siteName)
        {
            Console.Clear();
            Console.WriteLine("***********************************");
            Console.WriteLine($"Your Password is: {finishedPassword}");
            Console.WriteLine($"For: {siteName}");
            Console.WriteLine("***********************************");
        }    
    }
}
