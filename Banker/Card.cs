using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banker
{
    public class Card : Account
    {
        private string cardNumber;
        private string issued;
        private bool international;
        private string expireDate;

        public string CardNumber
        {
            get { return cardNumber; }
            set { cardNumber = value; }
        }
        public string Issued
        {
            get { return issued; }
            set { issued = value; }
        }
        public bool International
        {
            get { return international; }
            set { international = value; }
        }
        public string ExpireDate
        {
            get { return expireDate; }
            set { expireDate = value; }
        }

        // Random Generator for creating cards
        System.Random rand = new System.Random();

        // I have included an overload constructor so the other cards than debit can use the expire date attribute. 
        public Card(string name, int balance, bool international) : base(name, balance)
        {
            CardNumber = cardNumber;
            International = international;
            
        }
        public Card(string name, int balance, bool international, string expireDate) : base(name, balance)
        {
            CardNumber = cardNumber;
            International = international;
            ExpireDate = expireDate; 
        }


        // Methods for creating random numbers for accounts and cards
        public void CreateCardNumber(string prefix, int digitLength)
        {

            string cardNumber = prefix;
            for (int i = 0; i < digitLength; i++)
            {
                cardNumber += rand.Next(0, 9).ToString();
            }
            CardNumber = cardNumber;
        }

        public void CreateAccountNumber(string prefix, int digitLength)
        {
            string accountNumber = prefix;
            for (int i = 0; i < digitLength; i++)
            {
                accountNumber += rand.Next(0, 9).ToString();
            }
            AccountNumber = accountNumber;
        }
        public void CreateIssuedDate()
        {
            string month = rand.Next(1, 13).ToString();
            int year = rand.Next(18, 21);
            
            issued = month + "/" + year.ToString();
            Issued = issued;

            //Expire date is the date of when issued + 5 years. I could create a method that could override if needed by the indivdual card. 
            ExpireDate = month + "/" + (year + 5).ToString();
        }
        public override string ToString()
        {
            string objectAttributes = "Name: " + this.Name + "\n";
            objectAttributes += "Account Number: " + this.AccountNumber + "\n";
            objectAttributes += "Card Number: " + this.CardNumber + "\n";
            objectAttributes += "Card Balance " + this.Balance + "\n";
            objectAttributes += "Issued: " + this.Issued + "\n";
            objectAttributes += "Can be used international: " + this.International;
            if (ExpireDate != null)
            {
                objectAttributes += "\nExpire Date: " + this.ExpireDate;

            }
            return objectAttributes;
        }
    }

    // All the cards should be moved into individual pages, but kept here for simplicity... GO SOLID!
    class DebitCard : Card, INoNegative
    {
        public DebitCard(string name, int balance, bool international) : base(name, balance, international)
        {
            Name = name;
            CreateCardNumber("3520", 10); 
            Balance = balance; // Could implement a random number
            CreateCardNumber("2400", 12);
            CreateIssuedDate(); //random month + year
            International = false;
            
        }
        bool INoNegative.NoCredit()
        {
            //To Check and return false if the transaction exceeds the account balance. 
            Console.WriteLine("This is a debit card with no credit");

            if (Balance < 0 )
            {
                return false;
            }
            return true;
        }

        
    }
    class Maestro : Card, INoNegative, IOldEnough
    {
        public Maestro(string name, int balance, bool international, string expireDate) : base(name, balance, international, expireDate)
        {
            Name = name;
            CreateAccountNumber("3520", 10);
            Balance = balance; // Could implement a random number
            CreateCardNumber("5018", 14); // + 12 random numbers. Posible prefixes 5018, 5020, 5038, 5893, 6304, 6759, 6761, 6762, 6763
            CreateIssuedDate(); //random month + year
            International = international;
            ExpireDate = expireDate; 
        }

        bool INoNegative.NoCredit()
        {
            //To Check and return false if the transaction exceeds the account balance. 
            Console.WriteLine("This is a debit card with no credit");

            if (Balance < 0)
            {
                return false;
            }
            return true;
        }

        bool IOldEnough.TestAge()
        {
            //To Check and return false if the transaction exceeds the account balance. 
            Console.WriteLine("There is a age restriction of 18 on this card");

            if (Age < 19)
            {
                Console.WriteLine("The person isn't old enough");
                return false; 
            }
            return true;
        }

    }
    class VisaElectron : Card, INoNegative, IUseLimit, IOldEnough
    {
        public VisaElectron(string name, int balance, bool international, string expireDate) : base(name, balance, international, expireDate)
        {
            Name = name;
            CreateAccountNumber("3520", 10);
            Balance = balance; // Could implement a random number
            CreateCardNumber("4026", 10);  // + 12 random numbers. Posible Prefixes 4026,417500, 4508, 4844, 4913, 4917
            CreateIssuedDate(); //random month + year
            International = international;
            ExpireDate = expireDate;
        }

        bool INoNegative.NoCredit()
        {
            //To Check and return false if the transaction exceeds the account balance. 
            Console.WriteLine("This is a card with no credit");

            if (Balance < 0)
            {
                return false;
            }
            return true;
        }
        bool IOldEnough.TestAge()
        {
            //To Check and return false if the transaction exceeds the account balance. 
            Console.WriteLine("There is a age restriction of 15 on this card");

            if (Age < 16)
            {
                Console.WriteLine("The person isn't old enough");
                return false;
            }
            return true;
        }
        bool IUseLimit.SpendLimit()
        {
            Console.WriteLine("This card can use 10.000,- every month");
            if (Balance == Balance - 10000)
            {
                return false;
            }
            return true;
        }

    }
    class VisaDK : Card, IUseLimit, ICredit, IOldEnough
    {
        public VisaDK(string name, int balance, bool international, string expireDate) : base(name, balance, international, expireDate)
        {
            Name = name;
            CreateAccountNumber("3520", 10);
            Balance = balance; // Could implement a random number
            CreateCardNumber("4", 13); // + 15 random numbers
            CreateIssuedDate(); //random month + year
            International = international;
            ExpireDate = expireDate;
        }

        bool IOldEnough.TestAge()
        {
            //To Check and return false if the transaction exceeds the account balance. 
            Console.WriteLine("There is a age restriction of 18 on this card");

            if (Age < 19)
            {
                Console.WriteLine("The person isn't old enough");
                return false;
            }
            return true;
        }
        bool IUseLimit.SpendLimit()
        {
            Console.WriteLine("This card can use 25.000,- every month");
            if (Balance == Balance - 25000)
            {
                return false;
            }
            return true;
        }
        bool ICredit.CreditLimit()
        {
            Console.WriteLine("This card have a credit of up to 20.000,-");

            if (Balance == - 20000)
            {
                return false;
            }
            return true;
        }

    }
    class Mastercard : Card, IUseLimit, ICredit
    {
        public Mastercard(string name, int balance, bool international, string expireDate) : base(name, balance, international, expireDate)
        {
            Name = name;
            CreateAccountNumber("3520", 10);
            Balance = balance; // Could implement a random number
            CreateCardNumber("51", 12); ; // + 12 random numbers. Posible Prefixes 51, 52, 53, 54, 55.
            CreateIssuedDate(); //random month + year
            International = international;
            ExpireDate = expireDate; 
        }
        bool IUseLimit.SpendLimit()
        {
            Console.WriteLine("This card can use up 5000,- a day and up to 30.000,- every month");
            if (Balance == Balance - 30000)
            {
                return false;
            }
            return true;
        }
        bool ICredit.CreditLimit()
        {
            Console.WriteLine("This card have a credit of up to 40.000,-");

            if (Balance == -40000)
            {
                return false;
            }
            return true;
        }
    }

    // Interfaces with signitures. They consist mostly of pseudo code and will return som text to check connection. 
    interface INoNegative
    {
        bool NoCredit();
       
    }
    interface IUseLimit
    {
        bool SpendLimit();
    }
    interface ICredit
    {
        bool CreditLimit();
    }
    interface IOldEnough
    {
        bool TestAge();
    }
}
