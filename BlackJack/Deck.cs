using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Deck
    {
        Random random = new Random();
        public Dictionary<string, int> cardNamesAndValues = new Dictionary<string, int>();
        public List<PlayingCard> DeckList = new List<PlayingCard>();

        public Deck()
        {
            CreateDeck();
        }

        public void CreateDeck()
        {
            cardNamesAndValues.Add("Ace", 1);
            cardNamesAndValues.Add("Two", 2);
            cardNamesAndValues.Add("Three", 3);
            cardNamesAndValues.Add("Four", 4);
            cardNamesAndValues.Add("Five", 5);
            cardNamesAndValues.Add("Six", 6);
            cardNamesAndValues.Add("Seven", 7);
            cardNamesAndValues.Add("Eight", 8);
            cardNamesAndValues.Add("Nine", 9);
            cardNamesAndValues.Add("Ten", 10);
            cardNamesAndValues.Add("Jack", 10);
            cardNamesAndValues.Add("Queen", 10);
            cardNamesAndValues.Add("King", 10);

            foreach (CardSuitList suit in Enum.GetValues(typeof(CardSuitList)))
            {
                foreach (KeyValuePair<string, int> cardName in cardNamesAndValues)
                {

                    PlayingCard card = new PlayingCard(cardName.Key, suit.ToString(), cardName.Value);
                    DeckList.Add(card);
                };
            }

        }

        public PlayingCard SelectACard(List<PlayingCard> PassedDeckArray)
        {
            PlayingCard selectedCard;

            int selectedCardnumber = random.Next(1, 52);
            selectedCard = PassedDeckArray[selectedCardnumber];

            return selectedCard;
        }



        


    }
}
