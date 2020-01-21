﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    /*
     Version 1.5 of my Blackjack game. Base project complete. Things to imoprove/add/change in future versions
     1) Move objects into classes for easier management and tidyness
     2) Add visuals/graphics
     3) Game loop
     4) Add currency to wager?
     5) Extended blackjack rules such as splits and having a blackjack and an ace
     6) Ace is currently only worth 1, need to add option for 11
     7) I think there are also rules about minimum numbers to stick on.....16 maybe? Need to find those.
     8) Multiple players?
     9) Clean up inputs
     */

    class BlackJackGame
    {
        public Dictionary<string, int> cardNamesAndValues = new Dictionary<string, int>();

        public int playerCardTotal;
        public PlayingCard playerFirstCard;
        public PlayingCard playerSecondCard;
        public PlayingCard playerThirdCard;
        public PlayingCard playerFourthCard;
        public PlayingCard playerFifthCard;

        public PlayingCard dealerFirstCard;
        public PlayingCard dealerSecondCard;
        public PlayingCard dealerThirdCard;
        public PlayingCard dealerFourthCard;
        public PlayingCard dealerFifthCard;

        //public PlayingCard selectedCard;

        public int dealerCardTotal;

        public int selectedCardArraySlotRow = 0;

        Random random = new Random();

        public List<PlayingCard> DeckList = new List<PlayingCard>();
        public List<PlayingCard> PlayerHand = new List<PlayingCard>();
        public List<PlayingCard> DealerHand = new List<PlayingCard>();

        public BlackJackGame()
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

            while (true)
            {

                Player player = new Player();
                Player dealer = new Player();

                foreach (CardSuitList suit in Enum.GetValues(typeof(CardSuitList)))
                {
                    foreach (KeyValuePair<string, int> cardName in cardNamesAndValues)
                    {
                        
                        PlayingCard card = new PlayingCard(cardName.Key, suit.ToString(), cardName.Value);
                        DeckList.Add(card);
                    };
                }
                
                playerFirstCard = selectACard(DeckList);
                player.firstCardValue = playerFirstCard.cardValue;
                
                /*
                selectedCard = selectACard(DeckList);
                PlayerHand.Add(selectedCard);

                selectedCard = selectACard(DeckList);
                PlayerHand.Add(selectedCard);
                playerCardTotal = player.addHand(PlayerHand);

                playerCardTotal = player.addHand(PlayerHand);
                Console.WriteLine(playerCardTotal);*/
                
                playerSecondCard = selectACard(DeckList);
                player.secondCardValue = playerSecondCard.cardValue;
                playerCardTotal = player.addCards(player.firstCardValue, player.secondCardValue, player.thirdCardValue, player.fourthCardValue, player.fifthCardValue);
                
                //Console.WriteLine(playerCardTotal);

                dealerFirstCard = selectACard(DeckList);
                dealer.firstCardValue = dealerFirstCard.cardValue;
                dealerSecondCard = selectACard(DeckList);
                dealer.secondCardValue = dealerSecondCard.cardValue;
                dealerCardTotal = dealer.addCards(dealer.firstCardValue, dealer.secondCardValue, dealer.thirdCardValue, dealer.fourthCardValue, dealer.fifthCardValue);

                Console.WriteLine("Your first card is the: " + playerFirstCard.cardName + " of " + playerFirstCard.cardSuit + ". Which is worth: " + player.firstCardValue);
                Console.WriteLine("Your second card is the: " + playerSecondCard.cardName + " of " + playerSecondCard.cardSuit + ". Which is worth: " + player.secondCardValue);
                Console.WriteLine("Your current total is: " + playerCardTotal);
                Console.WriteLine("Would you like to (S)tick or (T)wist?");
                string userInput = Console.ReadLine();
                string userInputLower = userInput.ToLower();
                //PlayerInput round 1
                if (userInputLower == "s" || userInputLower == "stick")
                {
                    Console.WriteLine("The dealer's first card is the: " + dealerFirstCard.cardName + " of " + dealerFirstCard.cardSuit + ". Which is worth: " + dealer.firstCardValue);
                    Console.WriteLine("The dealer's second card is the: " + dealerSecondCard.cardName + " of " + dealerSecondCard.cardSuit + ". which is worth: " + dealer.secondCardValue);
                    Console.WriteLine("The dealer's total score is: " + dealerCardTotal);
                    if (playerCardTotal < dealerCardTotal)
                    {
                        player.DealerWinsWithHigherTotal();
                    }
                    else if (playerCardTotal == dealerCardTotal)
                    {
                        player.DealerEqualsPlayerScore();
                    }
                    else if (playerCardTotal > dealerCardTotal)
                    {
                        Console.WriteLine("The Dealer Twists.");
                        dealerThirdCard = selectACard(DeckList);
                        dealer.thirdCardValue = dealerThirdCard.cardValue;
                        dealerCardTotal = dealer.addCards(dealer.firstCardValue, dealer.secondCardValue, dealer.thirdCardValue, dealer.fourthCardValue, dealer.fifthCardValue);
                        Console.WriteLine("The dealer got a " + dealerThirdCard.cardName + " of " + dealerThirdCard.cardSuit + ". Their total is now " + dealerCardTotal);
                        if (dealer.CheckWhetherBust(dealerCardTotal))
                        {
                            player.DealerIsBust();
                        }
                        else if (dealerCardTotal == playerCardTotal)
                        {
                            player.DealerEqualsPlayerScore();
                        }
                        else if (dealerCardTotal > playerCardTotal)
                        {
                            player.DealerWinsWithHigherTotal();
                        }
                        else if (dealerCardTotal < playerCardTotal)
                        {
                            Console.WriteLine("The dealer twists.");
                            dealerFourthCard = selectACard(DeckList);
                            dealer.fourthCardValue = dealerFourthCard.cardValue;
                            dealerCardTotal = dealer.addCards(dealer.firstCardValue, dealer.secondCardValue, dealer.thirdCardValue, dealer.fourthCardValue, dealer.fifthCardValue);
                            Console.WriteLine("The dealer got a " + dealerFourthCard.cardName + " of " + dealerFourthCard.cardSuit + ". Their total is now " + dealerCardTotal);
                            if (dealerCardTotal > 21)
                            {
                                player.DealerIsBust();
                            }
                            else if (dealerCardTotal == playerCardTotal)
                            {
                                player.DealerEqualsPlayerScore();
                            }
                            else if (dealerCardTotal > playerCardTotal)
                            {
                                player.DealerWinsWithHigherTotal();
                            }
                            else if (dealerCardTotal < playerCardTotal)
                            {
                                Console.WriteLine("The dealer twists.");
                                dealerFifthCard = selectACard(DeckList);
                                dealer.fifthCardValue = dealerFifthCard.cardValue;
                                dealerCardTotal = dealer.addCards(dealer.firstCardValue, dealer.secondCardValue, dealer.thirdCardValue, dealer.fourthCardValue, dealer.fifthCardValue);
                                Console.WriteLine("The dealer got a " + dealerFifthCard.cardName + " of " + dealerFifthCard.cardSuit + ". Their total is now " + dealerCardTotal);
                                if (dealer.CheckWhetherBust(dealerCardTotal))
                                {
                                    player.DealerIsBust();
                                }
                                else if (dealerCardTotal == playerCardTotal)
                                {
                                    player.DealerEqualsPlayerScore();
                                }
                                else if (dealerCardTotal > playerCardTotal)
                                {
                                    player.DealerWinsWithHigherTotal();
                                }
                                else if (dealerCardTotal < playerCardTotal)
                                {
                                    Console.WriteLine("Even with 5 cards, the dealer couldn't beat you. Well done.");
                                    Console.WriteLine("Press any key to replay");
                                    Console.ReadLine();
                                }
                            }
                        }
                    }
                } 
                else if (userInputLower == "t" || userInputLower == "twist")
                {
                    Console.WriteLine("You draw another card.");
                    playerThirdCard = selectACard(DeckList);
                    player.thirdCardValue = playerThirdCard.cardValue;
                    playerCardTotal = player.addCards(player.firstCardValue, player.secondCardValue, player.thirdCardValue, player.fourthCardValue, player.fifthCardValue);
                    if (player.CheckWhetherBust(playerCardTotal))
                    {
                        Console.WriteLine("You got a " + playerThirdCard.cardName + " of " + playerThirdCard.cardSuit + " and your new total is " + playerCardTotal);
                        Console.WriteLine("I'm afraid you have gone bust");
                        Console.WriteLine("Press any key to replay");
                        Console.ReadLine();
                    } 
                    else if (!player.CheckWhetherBust(playerCardTotal))
                    {
                        Console.WriteLine("You got a " + playerThirdCard.cardName + " of " + playerThirdCard.cardSuit + " and your new total is " + playerCardTotal);
                        Console.WriteLine("Would you like to (S)tick or (T)wist?");
                        userInput = Console.ReadLine();
                        userInputLower = userInput.ToLower();
                        //Player Round 2
                        if (userInputLower == "s" || userInputLower == "stick")
                        {
                            Console.WriteLine("The dealer's first card is the: " + dealerFirstCard.cardName + " of " + dealerFirstCard.cardSuit + ". Which is worth: " + dealer.firstCardValue);
                            Console.WriteLine("The dealer's second card is the: " + dealerSecondCard.cardName + " of " + dealerSecondCard.cardSuit + ". which is worth: " + dealer.secondCardValue);
                            Console.WriteLine("The dealer's total score is: " + dealerCardTotal);
                            if (playerCardTotal < dealerCardTotal)
                            {
                                player.DealerWinsWithHigherTotal();
                            }
                            else if (playerCardTotal == dealerCardTotal)
                            {
                                player.DealerEqualsPlayerScore();
                            }
                            else if (playerCardTotal > dealerCardTotal)
                            {
                                Console.WriteLine("The Dealer Twists.");
                                dealerThirdCard = selectACard(DeckList);
                                dealer.thirdCardValue = dealerThirdCard.cardValue;
                                dealerCardTotal = dealer.addCards(dealer.firstCardValue, dealer.secondCardValue, dealer.thirdCardValue, dealer.fourthCardValue, dealer.fifthCardValue);
                                Console.WriteLine("The dealer got a " + dealerThirdCard.cardName + " of " + dealerThirdCard.cardSuit + ". Their total is now " + dealerCardTotal);
                                if (dealer.CheckWhetherBust(dealerCardTotal))
                                {
                                    player.DealerIsBust();
                                }
                                else if (dealerCardTotal == playerCardTotal)
                                {
                                    player.DealerEqualsPlayerScore();
                                }
                                else if (dealerCardTotal > playerCardTotal)
                                {
                                    player.DealerWinsWithHigherTotal();
                                }
                                else if (dealerCardTotal < playerCardTotal)
                                {
                                    Console.WriteLine("The dealer twists.");
                                    dealerFourthCard = selectACard(DeckList);
                                    dealer.fourthCardValue = dealerFourthCard.cardValue;
                                    dealerCardTotal = dealer.addCards(dealer.firstCardValue, dealer.secondCardValue, dealer.thirdCardValue, dealer.fourthCardValue, dealer.fifthCardValue);
                                    Console.WriteLine("The dealer got a " + dealerFourthCard.cardName + " of " + dealerFourthCard.cardSuit + ". Their total is now " + dealerCardTotal);
                                    if (dealer.CheckWhetherBust(dealerCardTotal))
                                    {
                                        player.DealerIsBust();
                                    }
                                    else if (dealerCardTotal == playerCardTotal)
                                    {
                                        player.DealerEqualsPlayerScore();
                                    }
                                    else if (dealerCardTotal > playerCardTotal)
                                    {
                                        player.DealerWinsWithHigherTotal();
                                    }
                                    else if (dealerCardTotal < playerCardTotal)
                                    {
                                        Console.WriteLine("The dealer twists.");
                                        dealerFifthCard = selectACard(DeckList);
                                        dealer.fifthCardValue = dealerFifthCard.cardValue;
                                        dealerCardTotal = dealer.addCards(dealer.firstCardValue, dealer.secondCardValue, dealer.thirdCardValue, dealer.fourthCardValue, dealer.fifthCardValue);
                                        Console.WriteLine("The dealer got a " + dealerFifthCard.cardName + " of " + dealerFifthCard.cardSuit + ". Their total is now " + dealerCardTotal);
                                        if (dealer.CheckWhetherBust(dealerCardTotal))
                                        {
                                            player.DealerIsBust();
                                        }
                                        else if (dealerCardTotal == playerCardTotal)
                                        {
                                            player.DealerEqualsPlayerScore();
                                        }
                                        else if (dealerCardTotal > playerCardTotal)
                                        {
                                            player.DealerWinsWithHigherTotal();
                                        }
                                        else if (dealerCardTotal < playerCardTotal)
                                        {
                                            Console.WriteLine("Even with 5 cards, the dealer couldn't beat you. Well done.");
                                            Console.WriteLine("Press any key to replay");
                                            Console.ReadLine();
                                        }
                                    }
                                }
                            }
                        }
                        else if (userInputLower == "t" || userInputLower == "twist")
                        {
                            Console.WriteLine("You draw another card.");
                            playerFourthCard = selectACard(DeckList);
                            player.fourthCardValue = playerFourthCard.cardValue;
                            playerCardTotal = player.addCards(player.firstCardValue, player.secondCardValue, player.thirdCardValue, player.fourthCardValue, player.fifthCardValue);
                            if (player.CheckWhetherBust(playerCardTotal))
                            {
                                Console.WriteLine("You got a " + playerFourthCard.cardName + " of " + playerFourthCard.cardSuit + " and your new total is " + playerCardTotal);
                                Console.WriteLine("I'm afraid you have gone bust");
                                Console.WriteLine("Press any key to replay");
                                Console.ReadLine();
                            }
                            else if (!player.CheckWhetherBust(playerCardTotal))
                            {
                                Console.WriteLine("You got a " + playerFourthCard.cardName + " of " + playerFourthCard.cardSuit + " and your new total is " + playerCardTotal);
                                Console.WriteLine("Would you like to (S)tick or (T)wist?");
                                userInput = Console.ReadLine();
                                userInputLower = userInput.ToLower();
                                //Player Round 3
                                if (userInputLower == "s" || userInputLower == "stick")
                                {
                                    Console.WriteLine("The dealer's first card is the: " + dealerFirstCard + " of " + dealerFirstCard.cardSuit + ". Which is worth: " + dealer.firstCardValue);
                                    Console.WriteLine("The dealer's second card is the: " + dealerSecondCard + " of " + dealerSecondCard.cardSuit + ". which is worth: " + dealer.secondCardValue);
                                    Console.WriteLine("The dealer's total score is: " + dealerCardTotal);
                                    if (playerCardTotal < dealerCardTotal)
                                    {
                                        player.DealerWinsWithHigherTotal();
                                    }
                                    else if (playerCardTotal == dealerCardTotal)
                                    {
                                        player.DealerEqualsPlayerScore();
                                    }
                                    else if (playerCardTotal > dealerCardTotal)
                                    {
                                        Console.WriteLine("The Dealer Twists.");
                                        dealerThirdCard = selectACard(DeckList);
                                        dealer.thirdCardValue = dealerThirdCard.cardValue;
                                        dealerCardTotal = dealer.addCards(dealer.firstCardValue, dealer.secondCardValue, dealer.thirdCardValue, dealer.fourthCardValue, dealer.fifthCardValue);
                                        Console.WriteLine("The dealer got a " + dealerThirdCard.cardName + " of " + dealerThirdCard.cardSuit + ". Their total is now " + dealerCardTotal);
                                        if (dealer.CheckWhetherBust(dealerCardTotal))
                                        {
                                            player.DealerIsBust();
                                        }
                                        else if (dealerCardTotal == playerCardTotal)
                                        {
                                            player.DealerEqualsPlayerScore();
                                        }
                                        else if (dealerCardTotal > playerCardTotal)
                                        {
                                            player.DealerWinsWithHigherTotal();
                                        }
                                        else if (dealerCardTotal < playerCardTotal)
                                        {
                                            Console.WriteLine("The dealer twists.");
                                            dealerFourthCard = selectACard(DeckList);
                                            dealer.fourthCardValue = dealerFourthCard.cardValue;
                                            dealerCardTotal = dealer.addCards(dealer.firstCardValue, dealer.secondCardValue, dealer.thirdCardValue, dealer.fourthCardValue, dealer.fifthCardValue);
                                            Console.WriteLine("The dealer got a " + dealerFourthCard.cardName + " of " + dealerFourthCard.cardSuit + ". Their total is now " + dealerCardTotal);
                                            if (dealer.CheckWhetherBust(dealerCardTotal))
                                            {
                                                player.DealerIsBust();
                                            }
                                            else if (dealerCardTotal == playerCardTotal)
                                            {
                                                player.DealerEqualsPlayerScore();
                                            }
                                            else if (dealerCardTotal > playerCardTotal)
                                            {
                                                player.DealerWinsWithHigherTotal();
                                            }
                                            else if (dealerCardTotal < playerCardTotal)
                                            {
                                                Console.WriteLine("The dealer twists.");
                                                dealerFifthCard = selectACard(DeckList);
                                                dealer.fifthCardValue = dealerFifthCard.cardValue;
                                                dealerCardTotal = dealer.addCards(dealer.firstCardValue, dealer.secondCardValue, dealer.thirdCardValue, dealer.fourthCardValue, dealer.fifthCardValue);
                                                Console.WriteLine("The dealer got a " + dealerFifthCard.cardName + " of " + dealerFifthCard.cardSuit + ". Their total is now " + dealerCardTotal);
                                                if (dealer.CheckWhetherBust(dealerCardTotal))
                                                {
                                                    player.DealerIsBust();
                                                }
                                                else if (dealerCardTotal == playerCardTotal)
                                                {
                                                    player.DealerEqualsPlayerScore();
                                                }
                                                else if (dealerCardTotal > playerCardTotal)
                                                {
                                                    player.DealerWinsWithHigherTotal();
                                                }
                                                else if (dealerCardTotal < playerCardTotal)
                                                {
                                                    Console.WriteLine("Even with 5 cards, the dealer couldn't beat you. Well done.");
                                                    Console.WriteLine("Press any key to replay");
                                                    Console.ReadLine();
                                                }
                                            }
                                        }
                                    }

                                }
                                else if (userInputLower == "t" || userInputLower == "twist")
                                {
                                    Console.WriteLine("You draw another card.");
                                    playerFifthCard = selectACard(DeckList);
                                    player.fifthCardValue = playerFifthCard.cardValue;
                                    playerCardTotal = player.addCards(player.firstCardValue, player.secondCardValue, player.thirdCardValue, player.fourthCardValue, player.fifthCardValue);
                                    if (player.CheckWhetherBust(playerCardTotal))
                                    {
                                        Console.WriteLine("You got a " + playerFifthCard.cardName + " of " + playerFifthCard.cardSuit + " and your new total is " + playerCardTotal);
                                        Console.WriteLine("I'm afraid you have gone bust");
                                        Console.ReadLine();
                                    }
                                    else if (!player.CheckWhetherBust(playerCardTotal))
                                    {
                                        Console.WriteLine("The dealer's first card is the: " + dealerFirstCard + " of " + dealerFirstCard.cardSuit + ". Which is worth: " + dealer.firstCardValue);
                                        Console.WriteLine("The dealer's second card is the: " + dealerSecondCard + " of " + dealerSecondCard.cardSuit + ". which is worth: " + dealer.secondCardValue);
                                        Console.WriteLine("The dealer's total score is: " + dealerCardTotal);
                                        if (playerCardTotal < dealerCardTotal)
                                        {
                                            player.DealerWinsWithHigherTotal();
                                        }
                                        else if (playerCardTotal == dealerCardTotal)
                                        {
                                            player.DealerEqualsPlayerScore();
                                        }
                                        else if (playerCardTotal > dealerCardTotal)
                                        {
                                            Console.WriteLine("The Dealer Twists.");
                                            dealerThirdCard = selectACard(DeckList);
                                            dealer.thirdCardValue = dealerThirdCard.cardValue;
                                            dealerCardTotal = dealer.addCards(dealer.firstCardValue, dealer.secondCardValue, dealer.thirdCardValue, dealer.fourthCardValue, dealer.fifthCardValue);
                                            Console.WriteLine("The dealer got a " + dealerThirdCard.cardName + " of " + dealerThirdCard.cardSuit + ". Their total is now " + dealerCardTotal);
                                            if (dealer.CheckWhetherBust(dealerCardTotal))
                                            {
                                                player.DealerIsBust();
                                            }
                                            else if (dealerCardTotal == playerCardTotal)
                                            {
                                                player.DealerEqualsPlayerScore();
                                            }
                                            else if (dealerCardTotal > playerCardTotal)
                                            {
                                                player.DealerWinsWithHigherTotal();
                                            }
                                            else if (dealerCardTotal < playerCardTotal)
                                            {
                                                Console.WriteLine("The dealer twists.");
                                                dealerFourthCard = selectACard(DeckList);
                                                dealer.fourthCardValue = dealerFourthCard.cardValue;
                                                dealerCardTotal = dealer.addCards(dealer.firstCardValue, dealer.secondCardValue, dealer.thirdCardValue, dealer.fourthCardValue, dealer.fifthCardValue);
                                                Console.WriteLine("The dealer got a " + dealerFourthCard.cardName + " of " + dealerFourthCard.cardSuit + ". Their total is now " + dealerCardTotal);
                                                if (dealer.CheckWhetherBust(dealerCardTotal))
                                                {
                                                    player.DealerIsBust();
                                                }
                                                else if (dealerCardTotal == playerCardTotal)
                                                {
                                                    player.DealerEqualsPlayerScore();
                                                }
                                                else if (dealerCardTotal > playerCardTotal)
                                                {
                                                    player.DealerWinsWithHigherTotal();
                                                }
                                                else if (dealerCardTotal < playerCardTotal)
                                                {
                                                    Console.WriteLine("The dealer twists.");
                                                    dealerFifthCard = selectACard(DeckList);
                                                    dealer.fifthCardValue = dealerFifthCard.cardValue;
                                                    dealerCardTotal = dealer.addCards(dealer.firstCardValue, dealer.secondCardValue, dealer.thirdCardValue, dealer.fourthCardValue, dealer.fifthCardValue);
                                                    Console.WriteLine("The dealer got a " + dealerFifthCard.cardName + " of " + dealerFifthCard.cardSuit + ". Their total is now " + dealerCardTotal);
                                                    if (dealer.CheckWhetherBust(dealerCardTotal))
                                                    {
                                                        player.DealerIsBust();
                                                    }
                                                    else if (dealerCardTotal == playerCardTotal)
                                                    {
                                                        player.DealerEqualsPlayerScore();
                                                    }
                                                    else if (dealerCardTotal > playerCardTotal)
                                                    {
                                                        player.DealerWinsWithHigherTotal();
                                                    }
                                                    else if (dealerCardTotal < playerCardTotal)
                                                    {
                                                        Console.WriteLine("Even with 5 cards, the dealer couldn't beat you. Well done.");
                                                        Console.WriteLine("Press any key to replay");
                                                        Console.ReadLine();
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public PlayingCard selectACard(List<PlayingCard> PassedDeckArray)
        {
                PlayingCard selectedCard;

                int selectedCardnumber = random.Next(1, 52);
                selectedCard = PassedDeckArray[selectedCardnumber];

            return selectedCard;
        }

        //Don't think I need this. Blackjack is usually played with multiple decks so duplicates do happen.
        /*
        public bool confirmCardIsNotDuplicate(string[] selectedCardList)
        {
            List<string> val = new List<string>();
            bool cardCheckResult = false;
            foreach(string card in selectedCardList)
            {
                if (val.Contains(card))
                {
                    cardCheckResult = true;
                    break;
                } 

            }
            return cardCheckResult;
        }*/ 

    }
}
