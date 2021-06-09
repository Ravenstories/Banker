using System;
using System.Collections.Generic;

namespace Banker
{
    class Program
    {
        // Hej Camilla! Jeg har prøvet at lave nogle kodekommentare, er de okay? Feedback ønskes.  
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! \n");
            
            //Creating cards and add them to a list and then print all the cards. 
            CardFactory cardFactory = new CardFactory();
            cardFactory.CreateCards();
            cardFactory.PrintListOfCards();

            Console.ReadKey();
        }
    }
}
