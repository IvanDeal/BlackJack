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

    }
}
