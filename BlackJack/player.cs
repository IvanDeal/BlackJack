﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    class Player
    {
        string firstCard;
        string secondCard;
        string thirdCard;
        string fourthCard;
        string fifthCard;

        public int firstCardValue;
        public int secondCardValue;
        public int thirdCardValue;
        public int fourthCardValue;
        public int fifthCardValue;

        public Player()
        {
            clearPlayerTotals();
        }

        public void PlayerTwist()
        {

        }

        public void PlayerStick()
        {

        }

        public void ExitGame()
        {
            Environment.Exit(0);
        }

        public void SelectACard()
        {

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

    }
}