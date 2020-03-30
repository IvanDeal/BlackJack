using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    /*
     Version 1.5 of my Blackjack game. Base project complete. Things to improve/add/change in future versions
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
        //public Dictionary<string, int> cardNamesAndValues = new Dictionary<string, int>();

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

        public int dealerCardTotal;

        public int selectedCardArraySlotRow = 0;

        Random random = new Random();

        public List<PlayingCard> PlayerHand = new List<PlayingCard>();
        public List<PlayingCard> DealerHand = new List<PlayingCard>();

        public BlackJackGame()
        {

            while (true)
            {
                Player player = new Player();
                Player dealer = new Player();
                Deck deck = new Deck();
                
                playerFirstCard = selectACard(deck.DeckList);
                player.firstCardValue = playerFirstCard.cardValue;
                
                playerSecondCard = selectACard(deck.DeckList);
                player.secondCardValue = playerSecondCard.cardValue;
                playerCardTotal = player.addCards(player.firstCardValue, player.secondCardValue, player.thirdCardValue, player.fourthCardValue, player.fifthCardValue);

                dealerFirstCard = selectACard(deck.DeckList);
                dealer.firstCardValue = dealerFirstCard.cardValue;
                dealerSecondCard = selectACard(deck.DeckList);
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
                        dealerThirdCard = selectACard(deck.DeckList);
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
                            dealerFourthCard = selectACard(deck.DeckList);
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
                                dealerFifthCard = selectACard(deck.DeckList);
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
                    playerThirdCard = selectACard(deck.DeckList);
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
                                dealerThirdCard = selectACard(deck.DeckList);
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
                                    dealerFourthCard = selectACard(deck.DeckList);
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
                                        dealerFifthCard = selectACard(deck.DeckList);
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
                            playerFourthCard = selectACard(deck.DeckList);
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
                                        dealerThirdCard = selectACard(deck.DeckList);
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
                                            dealerFourthCard = selectACard(deck.DeckList);
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
                                                dealerFifthCard = selectACard(deck.DeckList);
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
                                    playerFifthCard = selectACard(deck.DeckList);
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
                                            dealerThirdCard = selectACard(deck.DeckList);
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
                                                dealerFourthCard = selectACard(deck.DeckList);
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
                                                    dealerFifthCard = selectACard(deck.DeckList);
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

    }
}
