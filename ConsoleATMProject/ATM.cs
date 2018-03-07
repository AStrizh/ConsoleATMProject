using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleATMProject;
using System.Resources;

namespace ConsoleATMProject
{
    class ATM
    {
       int cashInATM;
       const int LOW = 1;
       const int NORMAL = 2;
       const int EMPTY = 0;

        private static ATM instance;

        private ATM()
        {
            cashInATM = 10000;
        }

        public int GetStatus()
        {
            int currentCash = Instance.Cash;

            if (currentCash == 0)
                return EMPTY;
            else if (currentCash < 1000)
                return LOW;
            else
                return NORMAL;
        } 

        public int Cash
        {
            get { return cashInATM; }
            set { cashInATM = value; }
        }

        public static ATM Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ATM();
                }
                return instance;
            }
        }



        public static Account CreateAccount()
        {
            Account account = new Account();

            Console.WriteLine();
            Console.WriteLine("Enter first name: ");
            account.FirstName = Console.ReadLine();

            Console.WriteLine("Enter last name: ");
            account.LastName = Console.ReadLine();

            account.AccountNumber = GenerateAccountNumber();
            Console.WriteLine("Your account number is: " + account.AccountNumber);
            Console.WriteLine("Please create a 4 digit pin number: ");
            account.Pin = Console.ReadLine();

            Console.WriteLine("\nWould you like this to be an executive account? " +
                              "\nWith an executive account, you can withdraw up to $1,000 per day. " +
                              "\nMust maintain a balance of $10,000 on an executive account. " +
                              "\n" +
                              "\nEnter y for YES or n for NO: ");

            char answer = Char.ToLower(Console.ReadLine()[0]);
            while (answer != 'y' && answer != 'n')            
            {
                Console.WriteLine("Invalid character. Enter y or n: ");
                answer = Char.ToLower(Console.ReadLine()[0]);
            }
            account.Executive = (answer == 'y');

            Console.WriteLine("Enter initial balance: ");

            double balance = Double.Parse( Console.ReadLine() );
            while( !(balance >= 100) )
            {
                Console.WriteLine("Invalid amount. Try again:"+
                                  "\nMinimum amount is $100");
                balance = int.Parse(Console.ReadLine());
            }
            account.Balance = balance;

            return account;
        }

        public static string GenerateAccountNumber()
        {
            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < 10; i++)
            {
                s = string.Concat(s, random.Next(10).ToString());
            }
            return s;
        }
       
        public static void Deposit(Account myAccount)
        {
            Console.WriteLine("How much would you like to deposit?");
            int deposit = int.Parse(Console.ReadLine());

            myAccount.Balance = myAccount.Balance + deposit;

            Console.WriteLine($"\nThe deposited amount: {deposit:C} will be added to your account.");
            Console.WriteLine("Press any key to return to main menu...");
            Console.ReadKey();
            Console.Clear();

        }

        public static void Withdraw(Account myAccount)
        {
            Console.WriteLine("How much would you like to withdraw?");

            int currentMaximum = GetMaximumWithdrawl(myAccount);
            Console.WriteLine($"Current withdrawl max is set to {currentMaximum:C}");

            int selection = 0;
            while (selection < 1 || selection > 5)
            {
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("Please make your selection");
                Console.WriteLine();
                Console.WriteLine(" 1) $20");
                Console.WriteLine(" 2) $60");
                Console.WriteLine(" 3) $100");
                Console.WriteLine(" 4) Other Amount");
                Console.WriteLine(" 5) Exit");

                selection = int.Parse(Console.ReadLine());
                switch (selection)
                {   
                    case 1:
                        if (myAccount.Balance >= 20 && currentMaximum >= 20)
                        {
                            myAccount.Balance = myAccount.Balance-20;
                            Instance.Cash = Instance.Cash - 20;
                            Console.WriteLine($"{20:C} was deducted from your account.");
                            Console.WriteLine("Please take your cash and have a Wonderful day!");
                            Console.WriteLine("\nPress any key to return to main menu...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("\nWe're sorry, you can't withdraw that amount.");
                            Withdraw(myAccount);
                        }
                        break;
                    case 2:
                        if (myAccount.Balance >= 60 && currentMaximum >= 60)
                        {
                            myAccount.Balance = myAccount.Balance - 60;
                            Instance.Cash = Instance.Cash - 60;
                            Console.WriteLine($"{60:C} was deducted from your account.");
                            Console.WriteLine("Please take your cash and have a Wonderful day!");
                            Console.WriteLine("\nPress any key to return to main menu...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("\nWe're sorry, you can't withdraw that amount.");
                            Withdraw(myAccount);
                        }
                        break;
                    case 3:
                        if (myAccount.Balance >= 100 && currentMaximum >= 100)
                        {
                            myAccount.Balance = myAccount.Balance - 100;
                            Instance.Cash = Instance.Cash - 100;
                            Console.WriteLine($"{100:C} was deducted from your account.");
                            Console.WriteLine("Please take your cash and have a Wonderful day!");
                            Console.WriteLine("\nPress any key to return to main menu...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("\nWe're sorry, you can't withdraw that amount.");
                            Withdraw(myAccount);
                        }
                        break;
                    case 4:
                        int withdraw = WithdrawAmount();
                        if (myAccount.Balance >= withdraw && currentMaximum >= withdraw)
                        {
                            myAccount.Balance = myAccount.Balance - withdraw;
                            Instance.Cash = Instance.Cash - withdraw;
                            Console.WriteLine($"{withdraw:C} was deducted from your account.");
                            Console.WriteLine("Please take your cash and have a Wonderful day!");
                            Console.WriteLine("\nPress any key to return to main menu...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("\nWe're sorry, you can't withdraw that amount.");
                            Withdraw(myAccount);
                        }
                        break;
                    case 5:
                        Console.WriteLine("\nPress any key to return to main menu...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Selection not understood please try again");
                        Withdraw(myAccount);
                        break;
                }
            }
        }

        private static int WithdrawAmount()
        {
            Console.WriteLine("Withdrawal amount must be a multiple of $20.");
            int amount = int.Parse(Console.ReadLine());

            while (amount!=0 && (amount%20)!=0)
            {
                Console.WriteLine("That amount is invalid. Please enter a multiple of $20, or enter 0 to exit.");
                amount = int.Parse(Console.ReadLine());
            }
            return amount;
        }

        public static void CheckBalance(Account myAccount)
        {
            Console.WriteLine($"Your current balance is: {myAccount.Balance:C}");
            Console.WriteLine();
            Console.WriteLine("Press any key to log out when you are ready!");
            Console.ReadKey();
            Console.Clear();
        }

        public static int GetMaximumWithdrawl(Account myAccount)
        {
            int maximum; 

            switch (Instance.GetStatus())
            {
                case 0:
                    maximum = 0;
                    break;
                case 1:
                    maximum = 20;
                    break;
                case 2:
                    if (myAccount.Executive)
                        maximum = 1000;
                    else
                        maximum = 200;
                    break;
                default:
                    maximum = 0;
                    break;    
            }
            return maximum;
        }
    }
}