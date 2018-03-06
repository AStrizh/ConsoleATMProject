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
            int selection = 0;
            while(selection < 1 || selection > 3)
            {
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("Please make your selection");
                Console.WriteLine();
                Console.WriteLine(" 1) Access Account");
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
                    case 3:
                        break;
                    default:
                        Console.WriteLine("Selection not understood please try again");
                        break;
                }
            }
        }

        public void AccountMenu()
        {
            Account account = AccountVerification();

            if (account != null)
            {
                string greeting = $"Welcome {account.FirstName}!";
                string executiveGreeting = "Thank you for being part of our Executive rewards program!";

                Console.WriteLine(greeting);
                if (account.Executive)
                    Console.WriteLine(executiveGreeting);

                int selection = 0;
                while (selection < 1 || selection > 4)
                {
                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                    Console.WriteLine("What would you like to do today?");
                    Console.WriteLine();
                    Console.WriteLine(" 1) Check Balance");
                    Console.Write(" 2) Withdraw");
                    Console.WriteLine($" [Current withdrawl max is set to {ATM.GetMaximumWithdrawl(account):C}]");
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
                        case 4:
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
                        Account newAccount = ATM.CreateAccount();
                        accountDictionary.Add(newAccount.AccountNumber, newAccount);
                        Console.WriteLine("Your account was successfully created!");
                        Console.WriteLine("Press any key to return to main menu...");
                        Console.ReadKey();
                        Console.Clear();
                        MainMenu();
                        break;
                    case 2:
                        Console.Clear();
                        MainMenu();
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
            Console.Clear();
            return userAccount;
        }
    }
}