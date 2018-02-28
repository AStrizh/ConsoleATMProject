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
            while(selection < 1 || selection > 3)
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

        public void AccountMenu()
        {
            /* 
             Options are:
             1) Check Balance
             2) Withdraw
             3) Deposit
             4) Log out
             */

            //This should probably just pass Account objects to the ATM class

            /*
              Question, if account object is modified without a refrence to the dictionary will the object
              in the dictionary change.
              More specifically, if we pass an Account object to the ATM class will we be passing a
              pointer to the Account or a copy of the Account.
              If it is a copy, then some of this will need to be reworked so that changes in the account
              are reflected throughout the system.                
            */
            Account account = AccountVerification();

            if (account != null)
            {
                int selection = 0;
                while (selection < 1 || selection > 4)
                {
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("What would you like to do today?");
                    Console.WriteLine();
                    Console.WriteLine(" 1) Check Balance");
                    Console.WriteLine(" 2) Withdraw");
                    Console.WriteLine(" 3) Deposit");
                    Console.WriteLine(" 4) Log Out");

                    selection = int.Parse(Console.ReadLine());

                    switch (selection)
                    {
                        case 1:
                            ATM.CheckBalance(account);
                            break;
                        case 2:
                            ATM.Withdraw(account);
                            break;
                        case 3:
                            ATM.Deposit(account);
                            break;
                        default:
                            Console.WriteLine("Selection not understood please try again");
                            break;
                    }
                }
            }
            MainMenu();
        }

        public void CreateAccount()
        {
            /* 
            Do we need a Create Account menu?
            Maybe it should just run through the Account Creation steps
             */

            int selection = 0;
            while(selection < 1 || selection > 2)
            {
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("Do you want to create a new account with us?");
                Console.WriteLine();
                Console.WriteLine(" 1) Start Account Creation");
                Console.WriteLine(" 2) Main Menu");

                selection = int.Parse(Console.ReadLine());

                switch (selection)
                {
                    case 1:
                        AccountMenu(); //Call CreateAccount at ATM class
                        break;
                    default:
                        Console.WriteLine("Selection not understood please try again");
                        break;
                }
            }
        }

        private Account AccountVerification()
        {
            Account userAccount = null;
            Account tempAccountRefrence = null;

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Enter your account number");
            string accountNumber = Console.ReadLine();

            bool foundAccount = false;
            int attemptFind = 0;
            while (!foundAccount && attemptFind < 3)
            {
                if ( accountDictionary.ContainsKey(accountNumber) )
                {
                    tempAccountRefrence = accountDictionary[accountNumber];
                    foundAccount = true;
                }
                else
                {
                    attemptFind++;
                    Console.WriteLine("That account does not exist. Please try again.");
                    Console.WriteLine($"You have {3-attemptFind} more attempt(s)");
                    accountNumber = Console.ReadLine();
                }
            }

            if (foundAccount)
            {
                Console.WriteLine("Enter your pin number for verification");
                string pin = Console.ReadLine();

                bool success = false;
                int attemptVerify = 0;
                while (!success && attemptVerify < 3)
                {
                    if (string.Compare(tempAccountRefrence.Pin,pin) == 0)
                    {
                        userAccount = tempAccountRefrence;
                        success = true;
                    }
                    else
                    {
                        attemptVerify++;
                        Console.WriteLine("The Pin is incorrect. Please try again.");
                        Console.WriteLine($"You have {3 - attemptVerify} more attempt(s)");
                        pin = Console.ReadLine();
                    }
                }
            }



            return userAccount;
        }
    }
}
