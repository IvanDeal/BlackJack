using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    /*
     Version 1.7 of my Blackjack game. Base project complete. Things to improve/add/change in future versions
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

        public int playerCardTotal;

        public int dealerCardTotal;

        public int selectedCardArraySlotRow = 0;

        public List<PlayingCard> DealerHand = new List<PlayingCard>();

        public BlackJackGame()
        {

            while (true)
            {
                Player player = new Player();
                Player dealer = new Player();
                Deck deck = new Deck();

                player.PlayerHand.Add(deck.SelectACard(deck.DeckList));
                player.PlayerHand.Add(deck.SelectACard(deck.DeckList));
                playerCardTotal = player.GetPlayerCardTotal();

                dealer.PlayerHand.Add(deck.SelectACard(deck.DeckList));
                dealer.PlayerHand.Add(deck.SelectACard(deck.DeckList));
                dealerCardTotal = dealer.GetPlayerCardTotal();

                player.RevealPlayerCards();

                Console.WriteLine("Your current total is: " + playerCardTotal);
                Console.WriteLine("Would you like to (S)tick or (T)wist?");
                string userInput = Console.ReadLine();
                string userInputLower = userInput.ToLower();
                //PlayerInput round 1

                if (userInputLower == "s")
                {
                    dealer.RevealPlayerCards();
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
                        dealer.PlayerHand.Add(deck.SelectACard(deck.DeckList));
                        dealerCardTotal = dealer.GetPlayerCardTotal();
                        dealer.RevealPlayerCards();
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
                            dealer.PlayerHand.Add(deck.SelectACard(deck.DeckList));
                            dealerCardTotal = dealer.GetPlayerCardTotal();
                            dealer.RevealPlayerCards();
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
                                dealer.PlayerHand.Add(deck.SelectACard(deck.DeckList));
                                dealerCardTotal = dealer.GetPlayerCardTotal();
                                dealer.RevealPlayerCards();
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
                else if (userInputLower == "t")
                {
                    Console.WriteLine("You draw another card.");
                    player.PlayerHand.Add(deck.SelectACard(deck.DeckList));
                    playerCardTotal = player.GetPlayerCardTotal();
                    if (player.CheckWhetherBust(playerCardTotal))
                    {
                        player.RevealPlayerCards();
                        Console.WriteLine("I'm afraid you have gone bust");
                        Console.WriteLine("Press any key to replay");
                        Console.ReadLine();
                    } 
                    else if (!player.CheckWhetherBust(playerCardTotal))
                    {
                        player.RevealPlayerCards();
                        Console.WriteLine("Would you like to (S)tick or (T)wist?");
                        userInput = Console.ReadLine();
                        userInputLower = userInput.ToLower();
                        //Player Round 2
                        if (userInputLower == "s")
                        {
                            dealer.RevealPlayerCards();
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
                                dealer.PlayerHand.Add(deck.SelectACard(deck.DeckList));
                                dealerCardTotal = dealer.GetPlayerCardTotal();
                                dealer.RevealPlayerCards();
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
                                    dealer.PlayerHand.Add(deck.SelectACard(deck.DeckList));
                                    dealerCardTotal = dealer.GetPlayerCardTotal();
                                    dealer.RevealPlayerCards();
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
                                        dealer.PlayerHand.Add(deck.SelectACard(deck.DeckList));
                                        dealerCardTotal = dealer.GetPlayerCardTotal();
                                        dealer.RevealPlayerCards();
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
                        else if (userInputLower == "t")
                        {
                            Console.WriteLine("You draw another card.");
                            player.PlayerHand.Add(deck.SelectACard(deck.DeckList));
                            playerCardTotal = player.GetPlayerCardTotal();
                            if (player.CheckWhetherBust(playerCardTotal))
                            {
                                player.RevealPlayerCards();
                                Console.WriteLine("I'm afraid you have gone bust");
                                Console.WriteLine("Press any key to replay");
                                Console.ReadLine();
                            }
                            else if (!player.CheckWhetherBust(playerCardTotal))
                            {
                                player.RevealPlayerCards();
                                Console.WriteLine("Would you like to (S)tick or (T)wist?");
                                userInput = Console.ReadLine();
                                userInputLower = userInput.ToLower();
                                //Player Round 3
                                if (userInputLower == "s")
                                {
                                    dealer.RevealPlayerCards();
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
                                        dealer.PlayerHand.Add(deck.SelectACard(deck.DeckList));
                                        dealerCardTotal = dealer.GetPlayerCardTotal();
                                        dealer.RevealPlayerCards();
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
                                            dealer.PlayerHand.Add(deck.SelectACard(deck.DeckList));
                                            dealerCardTotal = dealer.GetPlayerCardTotal();
                                            dealer.RevealPlayerCards();
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
                                                dealer.PlayerHand.Add(deck.SelectACard(deck.DeckList));
                                                dealerCardTotal = dealer.GetPlayerCardTotal();
                                                dealer.RevealPlayerCards();
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
                                else if (userInputLower == "t")
                                {
                                    Console.WriteLine("You draw another card.");
                                    player.PlayerHand.Add(deck.SelectACard(deck.DeckList));
                                    playerCardTotal = player.GetPlayerCardTotal();
                                    if (player.CheckWhetherBust(playerCardTotal))
                                    {
                                        player.RevealPlayerCards();
                                        Console.WriteLine("I'm afraid you have gone bust");
                                        Console.ReadLine();
                                    }
                                    else if (!player.CheckWhetherBust(playerCardTotal))
                                    {
                                        dealer.RevealPlayerCards();
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
                                            dealer.PlayerHand.Add(deck.SelectACard(deck.DeckList));
                                            dealerCardTotal = dealer.GetPlayerCardTotal();
                                            dealer.RevealPlayerCards();
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
                                                dealer.PlayerHand.Add(deck.SelectACard(deck.DeckList));
                                                dealerCardTotal = dealer.GetPlayerCardTotal();
                                                dealer.RevealPlayerCards();
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
                                                    dealer.PlayerHand.Add(deck.SelectACard(deck.DeckList));
                                                    dealerCardTotal = dealer.GetPlayerCardTotal();
                                                    dealer.RevealPlayerCards();
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
    }
}
