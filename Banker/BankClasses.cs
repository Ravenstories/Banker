using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banker
{
    public class User
    {
        private string name;
        private int age;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public User(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public User(string name)
        {
            Name = name;
        }


    }
    public class Account : User
    {
        private string accountNumber;
        private int balance;


        public string AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }
        public int Balance
        {
            get { return balance; }
            set { balance = value; }
        }

        public Account(string name, int balance) :base(name)
        {
            Balance = balance;
        }

    }
    
}
