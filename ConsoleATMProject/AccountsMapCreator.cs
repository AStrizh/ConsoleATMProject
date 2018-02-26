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

        public static Dictionary<string, string[]> CreateMap(string filename)
        {
            StreamReader file = new StreamReader(filename);

            Dictionary<string, string[]> dictionary = new Dictionary<string, string[]>();
            string line = file.ReadLine();
            string[] accountData;

            while ((line = file.ReadLine()) != null)
            {
                
                accountData = line.Split(',');
                dictionary.Add(accountData[1], accountData);

                //string result = string.Join("    ", accountData);
                //Console.WriteLine(result);
            }

            return dictionary;

        }

    }
}
