using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ConsoleATMProject;

namespace ConsoleATMProject
{
    class Launcher
    {
        static void Main(string[] args)
        {
            
            //string myDirectory = Directory.GetCurrentDirectory();        //Path for final project build
            string myDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;  //Path to get out of bin folder
            string fileName = myDirectory + "\\accounts.csv";

            Dictionary<string, Account> myDictionary = AccountsMapCreator.CreateMap(fileName);

            MenuManager myMenuManager = new MenuManager(myDictionary);
            myMenuManager.MainMenu();

            //This block will be removed once it is confirmed it is useless
            /*
            Console.WriteLine("\nDo you want to check accounts?");
            char answer1 = Char.ToLower(Console.ReadLine()[0]);
            while (answer1 != 'y' && answer1 != 'n')
            {
                Console.WriteLine("Invalid character. Enter y or n: ");
                answer1 = Char.ToLower(Console.ReadLine()[0]);
            }
            if(answer1 == 'y')
                CheckAccount(myDictionary);

            Console.WriteLine("\nWould you like to create a new account? "+
                              "\nEnter y for YES or n for NO: ");

            char answer2 = Char.ToLower(Console.ReadLine()[0]);
            while (answer2 != 'y' && answer2 != 'n')
            {
                Console.WriteLine("Invalid character. Enter y or n: ");
                answer2 = Char.ToLower(Console.ReadLine()[0]);
            }

            if (answer2 == 'y')
                ATM.CreateAccount();
            */

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            PrintDictionary(myDictionary);
        }

        public static void PrintDictionary(Dictionary<string, Account> myDictionary)
        {
            //Appending data to the .csv file
            //string myDirectory = Directory.GetCurrentDirectory();        //Path for final project build
            string myDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = myDirectory + "\\newaccounts.csv";

            using (StreamWriter writetext = new StreamWriter(fileName))
            {
                foreach (var entry in myDictionary)
                {
                    writetext.WriteLine(entry.Value);
                }
            }
        }
    }
}