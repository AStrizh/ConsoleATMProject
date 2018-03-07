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
            
            //string myDirectory = Directory.GetCurrentDirectory();        //Path for Release build
            string myDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;  //Path to get out of bin folder
            string fileName = myDirectory + "\\accounts.csv";

            Dictionary<string, Account> myDictionary = AccountsMapCreator.CreateMap(fileName);

            MenuManager myMenuManager = new MenuManager(myDictionary);
            myMenuManager.MainMenu();


            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            PrintDictionary(myDictionary);
        }

        public static void PrintDictionary(Dictionary<string, Account> myDictionary)
        {
            //string myDirectory = Directory.GetCurrentDirectory();        //Path for Release project build
            string myDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string fileName = myDirectory + "\\newaccounts.csv";          //Testing name Release simply overwrites accounts.csv 

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