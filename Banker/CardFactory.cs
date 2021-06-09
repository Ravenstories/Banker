using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banker
{
    public class CardFactory
    {
        List<Card> listOfCards = new List<Card>();
        public void CreateCards()
        {
            
            //var randomCardNumber = new Random();
            listOfCards.Add(new DebitCard("Jacob Henriksen", 5000, false));
            listOfCards.Add(new Maestro("Jacob Henriksen", 200, true, "05/26"));
            listOfCards.Add(new VisaElectron("Jacob Henriksen", 78, true, "12/23"));
            listOfCards.Add(new VisaDK("Jacob Henriksen", 96, true, "7/22"));
            listOfCards.Add(new Mastercard("Jacob Henriksen", 45000, true, "8/25"));
        }
        public void PrintListOfCards()
        {
            foreach (var card in listOfCards)
            {
                //Method .ToString have been overwritten in Card to include all the attributes. 
                Console.WriteLine(card.ToString());

                // Calling all the interfaces on that individual card. 
                if (card is INoNegative)
                {
                    ((INoNegative)card).NoCredit();
                }
                if (card is IOldEnough)
                {
                    ((IOldEnough)card).TestAge();
                }
                if (card is IUseLimit)
                {
                    ((IUseLimit)card).SpendLimit();
                }
                if (card is ICredit)
                {
                    ((ICredit)card).CreditLimit();
                }

                Console.WriteLine();

            }

        }
    }
}
