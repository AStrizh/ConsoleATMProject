using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleATMProject;

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

            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < 10; i++) { 
                s = String.Concat(s, random.Next(10).ToString());
            }
            account.AccountNumber = s;
            Console.WriteLine("\nYour account number is: " + account.AccountNumber +
                          "\nPlease create a 4 digit pin number: ");

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

            try
            {
                //Appending data to the .csv file
                string myDirectory = "C:\\Users\\abstr\\Documents\\C#\\Group Project\\ConsoleATMProject\\ConsoleATMProject"; //the path in Alex's computer
                string fileName = myDirectory + "\\accounts.csv";

                //TODO: The file cannot be accessed while application is running. Need some work around.
                //File.AppendAllText(fileName, clientDetails);

                Console.WriteLine(account.ToString());
            }

            catch (IOException e)
            {
                Console.Write(e.ToString());
            }


        }

        /*
        public void Deposit()
        {

        }

        public void Withdraw()
        {

        }

        public void checkBalance()
        {

        }
        */
    }
}





