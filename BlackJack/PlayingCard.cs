using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class PlayingCard
    {
        public string cardSuit;
        public string cardName; //Called name but names will mostly be numbers. It's a stirng to cover face cards
        public int cardValue;

        public PlayingCard(string suit, string name, int scoreValue)
        {
            cardSuit = suit;
            cardName = name;
            cardValue = scoreValue;
        }


        public void removeCardFromDeck()
        {

        }

        public int GetCardValue(string cardName)
        {
            int cardValue = 0;

            switch (cardName)
            {
                case "Ace of Hearts":
                case "Ace of Clubs":
                case "Ace of Diamonds":
                case "Ace of Spades":
                    cardValue = 1;
                    break;
                case "Two of Hearts":
                case "Two of Clubs":
                case "Two of Diamonds":
                case "Two of Spades":
                    cardValue = 2;
                    break;
                case "Three of Hearts":
                case "Three of Clubs":
                case "Three of Diamonds":
                case "Three of Spades":
                    cardValue = 3;
                    break;
                case "Four of Hearts":
                case "Four of Clubs":
                case "Four of Diamonds":
                case "Four of Spades":
                    cardValue = 4;
                    break;
                case "Five of Hearts":
                case "Five of Clubs":
                case "Five of Diamonds":
                case "Five of Spades":
                    cardValue = 5;
                    break;
                case "Six of Hearts":
                case "Six of Clubs":
                case "Six of Diamonds":
                case "Six of Spades":
                    cardValue = 6;
                    break;
                case "Seven of Hearts":
                case "Seven of Clubs":
                case "Seven of Diamonds":
                case "Seven of Spades":
                    cardValue = 7;
                    break;
                case "Eight of Hearts":
                case "Eight of Clubs":
                case "Eight of Diamonds":
                case "Eight of Spades":
                    cardValue = 8;
                    break;
                case "Nine of Hearts":
                case "Nine of Clubs":
                case "Nine of Diamonds":
                case "Nine of Spades":
                    cardValue = 9;
                    break;
                case "Ten of Hearts":
                case "Ten of Clubs":
                case "Ten of Diamonds":
                case "Ten of Spades":
                    cardValue = 10;
                    break;
                case "Jack of Hearts":
                case "Jack of Clubs":
                case "Jack of Diamonds":
                case "Jack of Spades":
                    cardValue = 10;
                    break;
                case "Queen of Hearts":
                case "Queen of Clubs":
                case "Queen of Diamonds":
                case "Queen of Spades":
                    cardValue = 10;
                    break;
                case "King of Hearts":
                case "King of Clubs":
                case "King of Diamonds":
                case "King of Spades":
                    cardValue = 10;
                    break;
            }
            return cardValue;
        }

    }
}
