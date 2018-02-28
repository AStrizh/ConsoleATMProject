using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleATMProject
{
    class AccountsMapCreator
    {


        public static Dictionary<string, Account> CreateMap(string filename)
        {
            StreamReader file = new StreamReader(filename);

            Dictionary<string, Account> dictionary = new Dictionary<string, Account>();
            string line = file.ReadLine();
            string[] accountData;

            while ((line = file.ReadLine()) != null)
            {

                accountData = line.Split(',');
                dictionary.Add(accountData[1], ArrayToAccount(accountData));
            }
            file.Close();
            return dictionary;
        }

        public static Dictionary<string, Account> CreateNewMap(string fileResource)
        {
            string[] accounts = fileResource.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            Dictionary<string, Account> dictionary = new Dictionary<string, Account>();

            string[] accountData;
            bool firstrow = true;
            foreach (string line in accounts)
            {
                if (!firstrow)
                {
                    Console.WriteLine(line);
                    accountData = line.Split(',');
                    dictionary.Add(accountData[1], ArrayToAccount(accountData));
                }
                else
                    firstrow = false;
            }

            return dictionary;
        }

        public static Account ArrayToAccount(String[] accountData)
        {
            Account account = new Account();

            string[] name = accountData[0].Split('.');
            account.FirstName = name[0];
            account.LastName = name[1];
            account.AccountNumber = accountData[1];
            account.Pin = accountData[2];
            account.Executive = (String.Compare(accountData[3], "y") == 0);
            account.Balance = Double.Parse(accountData[4]);

            return account;
        }

    }


}
