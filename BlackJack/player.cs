using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Player
    {

        public int firstCardValue;
        public int secondCardValue;
        public int thirdCardValue;
        public int fourthCardValue;
        public int fifthCardValue;

        public Player()
        {
            clearPlayerTotals();
        }

        public void PlayerTwist(string userInput)
        {
            Console.WriteLine("The dealer hands you a card.");
        }

        public void PlayerStick(string userInput)
        {
            Console.WriteLine("You stick.....was that wise?");
        }

        public void ExitGame()
        {
            Environment.Exit(0);
        }

        public void SelectACard()
        {

        }

        public void DealerIsBust()
        {
            Console.WriteLine("The dealer is bust. You win.");
            Console.WriteLine("Press any key to replay");
            Console.ReadLine();
        }

        public void DealerWinsWithHigherTotal()
        {
            Console.WriteLine("I'm sorry, the dealer's total is higher and has won.");
            Console.WriteLine("Press any key to replay");
            Console.ReadLine();
        }

        public void DealerEqualsPlayerScore()
        {
            Console.WriteLine("i'm sorry, the dealer has matched your score and has won.");
            Console.WriteLine("Press any key to replay");
            Console.ReadLine();
        }


        public void clearPlayerTotals()
        {
            firstCardValue = 0;
            secondCardValue = 0;
            thirdCardValue = 0;
            fourthCardValue = 0;
            fifthCardValue = 0;
        }

        public int addCards(int firstCardValue, int secondCardValue, int thirdCardValue, int fourthCardValue, int fifthCardValue)
        {
            int cardTotal = 0;

            cardTotal = firstCardValue + secondCardValue + thirdCardValue + fourthCardValue + fifthCardValue;

            return cardTotal;
        }

        public bool DoesPlayerBeatDealer(int playerCardTotal, int dealerCardTotal)
        {
            if (playerCardTotal > dealerCardTotal)
            {

                return true;
            } 
            else if (playerCardTotal == dealerCardTotal)
            {
                Console.WriteLine("i'm sorry, the dealer has matched your score and has won.");
                Console.WriteLine("Press any key to replay");
                Console.ReadLine();
                return false;
            }
            else if (playerCardTotal < dealerCardTotal)
            {
                Console.WriteLine("I'm sorry, the dealer's total is higher and has won.");
                Console.WriteLine("Press any key to replay");
                Console.ReadLine();
                return false;
            }

            return false;
        }

        public bool CheckWhetherBust(int cardTotal)
        {
            bool IsPlayerBust;

            if (cardTotal > 21)
            {
                IsPlayerBust = true;
            } 
            else
            {
                IsPlayerBust = false;
            }

            return IsPlayerBust;
        }
    }
}
