using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleATMProjct
{
    class ATM
    {
        
        public Atm()
        {
            
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


            Console.Write("Enter a 4 digit pin: ");
            while (Console.ReadLine().Length != 4)
            {
                Console.Write("Pin must be 4 digits long. Enter again: ");
            }
            account.Pin = Console.ReadLine();


            Console.Write("Would you like this to be an executive account? With an executive account, " +
                "you can withdraw up to $2,000 per day. Enter y for YES and n for NO: ");

            while(Console.ReadLine() != 'y' || Console.ReadLine() != 'n')
            {
                Console.Write("Invalid character. Enter y or n: ");
            }
            account.Executive = Console.ReadLine();


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
            try
            {
                string myDirectory = "C:\\Users\\abstr\\Documents\\C#\\Group Project\\ConsoleATMProject\\ConsoleATMProject"; //the path in Alex's computer
                string fileName = myDirectory + "\\accounts.csv";

                string clientDetails = account.FirstName + "," + account.LastName + "," + account.AccountNumber + "," + account.Pin + "," + account.Executive + "," + account.Balance;

                File.AppendAllText(fileName, clientDetails);
            }
            catch (IOException e)
            {
                UI.AlertUserSomehow(e.ToString());
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





