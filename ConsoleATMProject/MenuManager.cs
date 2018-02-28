using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleATMProject
{
    class MenuManager
    {
        Dictionary<string, Account> accountDictionary;

        public MenuManager( Dictionary<string, Account> myDictionary )
        {
            accountDictionary = myDictionary;
        }

        public void MainMenu()
        {
            /* 
             Options are:
             1) Log In/Check Account
             2) Create new Account
             3) System Shut Down 
             */

            int selection = 0;
            while(selection != 3)
            {
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("Please Make a selection");
                Console.WriteLine();
                Console.WriteLine(" 1) Check Account");
                Console.WriteLine(" 2) Create new Account");
                Console.WriteLine(" 3) System Shutdown");

                selection = int.Parse(Console.ReadLine());

                switch (selection)
                {
                    case 1:
                        AccountMenu();
                        break;
                    case 2:
                        CreateAccount();
                        break;
                    default:
                        Console.WriteLine("Selection not understood please try again");
                        break;
                }
            }

        }

        public static void AccountMenu()
        {
            /* 
             Options are:
             1) Check Balance
             2) Withdraw
             3) Deposit
             4) Log out
             */
            Console.WriteLine("The Account menu will be here");
        }

        public static void CreateAccount()
        {
            /* 
            Do we need a Create Account menu?
            Maybe it should just run through the Account Creation steps
             */
        }
    }
}
