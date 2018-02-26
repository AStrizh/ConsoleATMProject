using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleATMProjct
{
    class ATM
    {
        public List<Account> Accounts { get; set; }

        public Atm()
        {
            Accounts = new List<Account>();
        }

        public void CreateAccount()
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
            Console.Write("Your account number is: " + account.AccountNumber);

            //Alex needs to add Pin() and Executive() methods in th Account class
            Console.Write("Enter a 4 digit pin: ");
            account.Pin = Console.ReadLine();

            Console.Write("Would you like this to be an executive account? With an executive account, you can withdraw up to $2,000 per day. Enter y for YES and n for NO: ");
            account.Executive = Console.ReadLine()

            Console.Write("Enter initial balance: ");
            if (float.Parse(Console.ReadLine()) >= 0)
            {
                account.Balance = Double.Parse(Console.ReadLine());
            }
            else
            {
                account.Balance = 0.0;
            }
            
            //Appending data to the .csv file
            static string myDirectory = "C:\\Users\\abstr\\Documents\\C#\\Group Project\\ConsoleATMProject\\ConsoleATMProject"; //the path in Alex's computer
            string fileName = myDirectory + "\\accounts.csv";

            string clientDetails = account.FirstName + "," + account.LastName + "," + account.AccountNumber + "," + account.Pin + "," + account.Executive + "," + account.Balance;
   
            File.AppendAllText(fileName, clientDetails);

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





