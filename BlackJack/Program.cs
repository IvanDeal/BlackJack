using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Program
    {
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, Welcome to my BlackJack game V1.5.");
            Console.WriteLine("If you would like to play please type (P)lay");
            string userInput = Console.ReadLine();
            string userInputLower = userInput.ToLower();
            if (userInputLower == "p" || userInputLower == "play")
            {
                new BlackJackGame();
            }
        }
    }
}
