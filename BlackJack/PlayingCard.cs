using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    public enum CardNameList
    {
        Joker,
        Ace,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack = 10,
        Queen = 10,
        King = 10,
    }
    

    class PlayingCard
    {
        public string cardSuit;
        public string cardName; //Called name but names will mostly be numbers. It's a string to cover face cards
        public int cardValue;
       
        // From PlayingCard parameters: string suit, string name, int scoreValue

    public PlayingCard(CardNameList value, string suit)
        {
            cardName = value.ToString();
            cardSuit = suit;
            cardValue = (int)value;
        }

        public void removeCardFromDeck()
        {

        }

    }
}
