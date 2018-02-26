using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleATMProject
{
    class Account
    {

        private string firstName;
        private string lastName;
        private string accountNumber;
        private double balance;
        private string pin;
        private Boolean executive;


        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value; 
            }

        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }

        }

        public string AccountNumber
        {
            get
            {
                return accountNumber;
            }
            set
            {
                accountNumber = value;
            }

        }

        public double Balance
        {
            get
            {
                return balance;
            }
            set
            {
                balance = value;
            }

        }

        public string Pin
        {
            get
            {
                return pin;
            }
            set
            {
                pin = value;
            }

        }
        public Boolean Executive
        {
            get
            {
                return executive;
            }
            set
            {
                executive = value;
            }

        }

    }
}
