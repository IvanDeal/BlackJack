using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public enum CardSuitList
    {
        Hearts,
        Diamonds,
        Spades,
        Clubs
    }

    class PlayingCard
    {
        public string cardSuit;
        public string cardName;
        public int cardValue;

    public PlayingCard(string name, string suit, int value)
        {
            cardName = name;
            cardSuit = suit;
            cardValue = value;
        }

        public void removeCardFromDeck()
        {

        }
    }
}
