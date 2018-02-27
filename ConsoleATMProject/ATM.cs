using ConsoleATMProject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var account = new Account();

            Console.WriteLine();
            Console.Write("Enter first name: ");
            account.FirstName = Console.ReadLine();

            Console.Write("Enter last name: ");
            account.LastName = Console.ReadLine();

            var random = new Random();
            string s = string.Empty;
            for (int i = 0; i < 10; i++) { 
                s = String.Concat(s, random.Next(10).ToString());
            }
            account.AccountNumber = s;
            Console.Write("\nYour account number is: " + account.AccountNumber +
                          "\nPlease create a 4 digit pin number: ");

            Console.Write("Enter a 4 digit pin: ");
            account.Pin = Console.ReadLine();

            Console.Write("\nWould you like this to be an executive account? " +
                          "\nWith an executive account, you can withdraw up to $2,000 per day. " +
                          "\nMust maintain a balance of $10,000 on an executive account. " +
                          "\nEnter y for YES or n for NO: ");

            char answer = Char.ToLower(Console.ReadLine()[0]);
            while (answer != 'y' || answer != 'n')            
            {
                Console.Write("Invalid character. Enter y or n: ");
                answer = Char.ToLower(Console.ReadLine()[0]);
            }
            account.Executive = (answer == 'y');

            Console.Write("Enter initial balance: ");

            if (float.Parse(Console.ReadLine()) >= 0)
            {
                account.Balance = Double.Parse(Console.ReadLine());
            }
            else
            {
                account.Balance = 0.0;
            }

            try
            {
                //Appending data to the .csv file
                string myDirectory = "C:\\Users\\abstr\\Documents\\C#\\Group Project\\ConsoleATMProject\\ConsoleATMProject"; //the path in Alex's computer
                string fileName = myDirectory + "\\accounts.csv";

                string clientDetails = account.FirstName + "." + account.LastName + "," + account.AccountNumber + "," + account.Pin + "," + account.Executive + "," + account.Balance;

                //TODO: The file cannot be accessed while application is running.Need some work around.
                File.AppendAllText(fileName, clientDetails);
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





