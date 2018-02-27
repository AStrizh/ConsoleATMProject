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
            //TODO: Figure out how to use working directory rather than hardcoded path
            string myDirectory = "C:\\Users\\abstr\\Documents\\C#\\Group Project\\ConsoleATMProject\\ConsoleATMProject";
            Dictionary<string, string[]> myDictionary = AccountsMapCreator.CreateMap(myDirectory +"\\accounts.csv");

            Console.WriteLine("\nEnter the account number you are interested in: ");
            string accountNumber = Console.ReadLine();

            // See whether Dictionary contains this string.
            if (myDictionary.ContainsKey(accountNumber))
            {
                string[] value = myDictionary[accountNumber];
                string name = string.Join(" ", value[0].Split('.'));

                Console.WriteLine("\nThe name on the account is: " + name);
                Console.WriteLine("\nThe balance is: $" + value[4]);

                if(String.Compare(value[3], "y") == 0)
                {
                    Console.WriteLine("\nThis is an Executive account!");
                }
                else
                {
                    Console.WriteLine("\nYou are a poor shmuck!");
                }

                Console.WriteLine("\nYour pin number is: " + value[2] + " Dont tell anybody!");
            }
            else
                Console.WriteLine("\nThat account number doesnt exist");


            Console.WriteLine("\nWould you like to create a new account? "+
                              "\nEnter y for YES or n for NO: ");

            string answer = Console.ReadLine().ToLower();
            bool newAccount = String.Compare(answer, "y") == 0 ||
                              String.Compare(answer, "yes") == 0;

            if (newAccount)
                ATM.CreateAccount();

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
