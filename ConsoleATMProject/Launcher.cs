﻿using System;
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
        }



        static void CheckAccount(Dictionary<string, Account> myDictionary)
        {
            Console.WriteLine("\nEnter the account number you are interested in: ");
            string accountNumber = Console.ReadLine();

            // See whether Dictionary contains this string.
            if (myDictionary.ContainsKey(accountNumber))
            {
                Account thisAccount = myDictionary[accountNumber];

                string name = thisAccount.FirstName + " " + thisAccount.LastName;

                Console.WriteLine("\nThe name on the account is: " + name);
                Console.WriteLine($"\nThe balance is: {thisAccount.Balance:C}" );

                if (thisAccount.Executive)
                {
                    Console.WriteLine("\nThis is an Executive account!");
                }
                else
                {
                    Console.WriteLine("\nYou are a poor shmuck!");
                }

                Console.WriteLine("\nYour pin number is: " + thisAccount.Pin + " Dont tell anybody!");
            }
            else
                Console.WriteLine("\nThat account number doesnt exist");
        }
    }
}
