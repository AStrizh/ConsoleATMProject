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
        public List<Account> Accounts { get; set; }

        public void Atm()
        {
            Accounts = new List<Account>();
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
                s = String.Concat(s, random.Next(10).ToString());
            }
            return s;
        }


       
        public static void Deposit(Account myAccount)
        {

        }

        public static void Withdraw(Account myAccount)
        {

        }

        public static void CheckBalance(Account myAccount)
        {
            string greeting = $"Welcome {myAccount.FirstName}!";
            string executiveGreeting = "Thank you for being part of our Executive rewards program!";

            Console.WriteLine(greeting);
            if (myAccount.Executive)
                Console.WriteLine(executiveGreeting);

            Console.WriteLine($"\nYour current balance is: {myAccount.Balance:C}");

            Console.WriteLine();
            Console.WriteLine("Press any key to log out when you are ready!");
            Console.ReadKey();

        }

    }
}





