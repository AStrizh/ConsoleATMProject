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
        //ATM daily allotment. How to use it? Singleton probably best.
        int cashInATM; 

        private static ATM instance;

        private ATM()
        {
            cashInATM = 10000;
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


        public static void CreateAccount()
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
                              "\nWith an executive account, you can withdraw up to $2,000 per day. " +
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
                balance = Double.Parse(Console.ReadLine());
            }
            account.Balance = balance;

            //Say youre done
        }

        //This method probably should be in the main method and gets called after everything else is done
        public static void AccountToFile(Account account)
        {
            try
            {
                //Appending data to the .csv file
                //string myDirectory = Directory.GetCurrentDirectory();        //Path for final project build
                string myDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                string fileName = myDirectory + "\\accounts.csv";
                File.AppendAllText(fileName, account.ToString());
            }

            catch (IOException e)
            {
                Console.WriteLine(e.ToString());
            }
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
        }

        //TODO: Needs to account for maximum available funds
        public static void Withdraw(Account myAccount)
        {
            string greeting = $"Welcome {myAccount.FirstName}!";
            string executiveGreeting = "Thank you for being part of our Executive rewards program!";

            Console.WriteLine(greeting);
            if (myAccount.Executive)
                Console.WriteLine(executiveGreeting);

            Console.WriteLine("How much would you like to withdraw?");

            int selection = 0;
            while (selection < 1 || selection > 4)
            {
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("Please make your selection");
                Console.WriteLine();
                Console.WriteLine(" 1) $40");
                Console.WriteLine(" 2) $60");
                Console.WriteLine(" 3) $100");
                Console.WriteLine(" 4) Other Amount");
                Console.WriteLine(" 5) Exit");

                selection = int.Parse(Console.ReadLine());
                switch (selection)
                {
                    case 1:
                        if (myAccount.Balance >=40)
                            myAccount.Balance = myAccount.Balance-40;
                        else
                            Console.WriteLine("We're sorry. You dont now have enough funds on your account");
                        break;
                    case 2:
                        if (myAccount.Balance >= 60)
                            myAccount.Balance = myAccount.Balance - 60;
                        else
                            Console.WriteLine("We're sorry. You dont now have enough funds on your account");
                        break;
                    case 3:
                        if (myAccount.Balance >= 100)
                            myAccount.Balance = myAccount.Balance - 100;
                        else
                            Console.WriteLine("We're sorry. You dont now have enough funds on your account");
                        break;
                    case 4:
                        int withdraw = WithdrawAmount();
                        if (myAccount.Balance >= withdraw)
                        {
                            myAccount.Balance = myAccount.Balance - withdraw;
                            Instance.Cash = Instance.Cash - withdraw;
                            Console.Clear();
                            Console.WriteLine($"{withdraw}:C was deducted from your account.");
                            Console.WriteLine("Please take your cash and have a Wonderful day!");
                        }                            
                        else
                            Console.WriteLine("We're sorry. You dont now have enough funds on your account");
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("Selection not understood please try again");
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
            Console.WriteLine($"\nYour current balance is: {myAccount.Balance:C}");
            Console.WriteLine();
            Console.WriteLine("Press any key to log out when you are ready!");
            Console.ReadKey();
        }
    }
}