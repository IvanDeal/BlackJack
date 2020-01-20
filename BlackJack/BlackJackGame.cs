using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    /*
     Version 1.0 of my Blackjack game. Base project complete. Things to imoprove/add/change in future versions
     1) Move objects into classes for easier management and tidyness
     2) Add check for duplicate cards being drawn (simulating a single deck game)
     3) Add visuals/graphics
     4) Game loop
     5) Add currency to wager?
     6) Extended blackjack rules such as splits and having a blackjack and an ace
     6) Ace is currently only worth 1, need to add option for 11
     7) I think there are also rules about minimum numbers to stick on.....16 maybe? Need to find those.
     8) Multiple players?
     9) Clean up inputs
     */

    class BlackJackGame
    {
        //Player player = new Player();
        //Player dealer = new Player();

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
        
        public PlayingCard[] DeckArray = new PlayingCard[52]; //single dimensional array?
        

        public BlackJackGame()
        {

            while (true)
            {

                Player player = new Player();
                Player dealer = new Player();

                //Hearts
                PlayingCard aceOfHearts = new PlayingCard(CardNameList.Ace, "Hearts");
                PlayingCard twoOfHearts = new PlayingCard(CardNameList.Two, "Hearts");
                PlayingCard threeOfHearts = new PlayingCard(CardNameList.Three, "Hearts");
                PlayingCard fourOfHearts = new PlayingCard(CardNameList.Four, "Hearts");
                PlayingCard fiveOfHearts = new PlayingCard(CardNameList.Five, "Hearts");
                PlayingCard sixOfHearts = new PlayingCard(CardNameList.Six, "Hearts");
                PlayingCard sevenOfHearts = new PlayingCard(CardNameList.Seven, "Hearts");
                PlayingCard eightOfHearts = new PlayingCard(CardNameList.Eight, "Hearts");
                PlayingCard nineOfHearts = new PlayingCard(CardNameList.Nine, "Hearts");
                PlayingCard tenOfHearts = new PlayingCard(CardNameList.Ten, "Hearts");
                PlayingCard jackOfHearts = new PlayingCard(CardNameList.Jack, "Hearts");
                PlayingCard queenOfHearts = new PlayingCard(CardNameList.Queen, "Hearts");
                PlayingCard kingOfHearts = new PlayingCard(CardNameList.King, "Hearts");
                //Diamonds
                PlayingCard aceOfDiamonds = new PlayingCard(CardNameList.Ace, "Diamonds");
                PlayingCard twoOfDiamonds = new PlayingCard(CardNameList.Two, "Diamonds");
                PlayingCard threeOfDiamonds = new PlayingCard(CardNameList.Three, "Diamonds");
                PlayingCard fourOfDiamonds = new PlayingCard(CardNameList.Four, "Diamonds");
                PlayingCard fiveOfDiamonds = new PlayingCard(CardNameList.Five, "Diamonds");
                PlayingCard sixOfDiamonds = new PlayingCard(CardNameList.Six, "Diamonds");
                PlayingCard sevenOfDiamonds = new PlayingCard(CardNameList.Seven, "Diamonds");
                PlayingCard eightOfDiamonds = new PlayingCard(CardNameList.Eight, "Diamonds");
                PlayingCard nineOfDiamonds = new PlayingCard(CardNameList.Nine, "Diamonds");
                PlayingCard tenOfDiamonds = new PlayingCard(CardNameList.Ten, "Diamonds");
                PlayingCard jackOfDiamonds = new PlayingCard(CardNameList.Jack, "Diamonds");
                PlayingCard queenOfDiamonds = new PlayingCard(CardNameList.Queen, "Diamonds");
                PlayingCard kingOfDiamonds = new PlayingCard(CardNameList.King, "Diamonds");
                //Clubs
                PlayingCard aceOfClubs = new PlayingCard(CardNameList.Ace, "Clubs");
                PlayingCard twoOfClubs = new PlayingCard(CardNameList.Two, "Clubs");
                PlayingCard threeOfClubs = new PlayingCard(CardNameList.Three, "Clubs");
                PlayingCard fourOfClubs = new PlayingCard(CardNameList.Four, "Clubs");
                PlayingCard fiveOfClubs = new PlayingCard(CardNameList.Five, "Clubs");
                PlayingCard sixOfClubs = new PlayingCard(CardNameList.Six, "Clubs");
                PlayingCard sevenOfClubs = new PlayingCard(CardNameList.Seven, "Clubs");
                PlayingCard eightOfClubs = new PlayingCard(CardNameList.Eight, "Clubs");
                PlayingCard nineOfClubs = new PlayingCard(CardNameList.Nine, "Clubs");
                PlayingCard tenOfClubs = new PlayingCard(CardNameList.Ten, "Clubs");
                PlayingCard jackOfClubs = new PlayingCard(CardNameList.Jack, "Clubs");
                PlayingCard queenOfClubs = new PlayingCard(CardNameList.Queen, "Clubs");
                PlayingCard kingOfClubs = new PlayingCard(CardNameList.King, "Clubs");
                //Spades
                PlayingCard aceOfSpades = new PlayingCard(CardNameList.Ace, "Spades");
                PlayingCard twoOfSpades = new PlayingCard(CardNameList.Two, "Spades");
                PlayingCard threeOfSpades = new PlayingCard(CardNameList.Three, "Spades");
                PlayingCard fourOfSpades = new PlayingCard(CardNameList.Four, "Spades");
                PlayingCard fiveOfSpades = new PlayingCard(CardNameList.Five, "Spades");
                PlayingCard sixOfSpades = new PlayingCard(CardNameList.Six, "Spades");
                PlayingCard sevenOfSpades = new PlayingCard(CardNameList.Seven, "Spades");
                PlayingCard eightOfSpades = new PlayingCard(CardNameList.Eight, "Spades");
                PlayingCard nineOfSpades = new PlayingCard(CardNameList.Nine, "Spades");
                PlayingCard tenOfSpades = new PlayingCard(CardNameList.Ten, "Spades");
                PlayingCard jackOfSpades = new PlayingCard(CardNameList.Jack, "Spades");
                PlayingCard queenOfSpades = new PlayingCard(CardNameList.Queen, "Spades");
                PlayingCard kingOfSpades = new PlayingCard(CardNameList.King, "Spades");
                //player.clearPlayerTotals();
                //dealer.clearPlayerTotals();

                DeckArray[0] = aceOfSpades;
                DeckArray[1] = aceOfHearts;
                DeckArray[2] = aceOfDiamonds;
                DeckArray[3] = aceOfClubs;
                DeckArray[4] = twoOfSpades;
                DeckArray[5] = twoOfHearts;
                DeckArray[6] = twoOfDiamonds;
                DeckArray[7] = twoOfClubs;
                DeckArray[8] = threeOfSpades;
                DeckArray[9] = threeOfHearts;
                DeckArray[10] = threeOfDiamonds;
                DeckArray[11] = threeOfClubs;
                DeckArray[12] = fourOfSpades;
                DeckArray[13] = fourOfHearts;
                DeckArray[14] = fourOfDiamonds;
                DeckArray[15] = fourOfClubs;
                DeckArray[16] = fiveOfSpades;
                DeckArray[17] = fiveOfHearts;
                DeckArray[18] = fiveOfDiamonds;
                DeckArray[19] = fiveOfClubs;
                DeckArray[20] = sixOfSpades;
                DeckArray[21] = sixOfHearts;
                DeckArray[22] = sixOfDiamonds;
                DeckArray[23] = sixOfClubs;
                DeckArray[24] = sevenOfSpades;
                DeckArray[25] = sevenOfHearts;
                DeckArray[26] = sevenOfDiamonds;
                DeckArray[27] = sevenOfClubs;
                DeckArray[28] = eightOfSpades;
                DeckArray[29] = eightOfHearts;
                DeckArray[30] = eightOfDiamonds;
                DeckArray[31] = eightOfClubs;
                DeckArray[32] = nineOfSpades;
                DeckArray[33] = nineOfHearts;
                DeckArray[34] = nineOfDiamonds;
                DeckArray[35] = nineOfClubs;
                DeckArray[36] = tenOfSpades;
                DeckArray[37] = tenOfHearts;
                DeckArray[38] = tenOfDiamonds;
                DeckArray[39] = tenOfClubs;
                DeckArray[40] = jackOfSpades;
                DeckArray[41] = jackOfHearts;
                DeckArray[42] = jackOfDiamonds;
                DeckArray[43] = jackOfClubs;
                DeckArray[44] = queenOfSpades;
                DeckArray[45] = queenOfHearts;
                DeckArray[46] = queenOfDiamonds;
                DeckArray[47] = queenOfClubs;
                DeckArray[48] = kingOfSpades;
                DeckArray[49] = kingOfHearts;
                DeckArray[50] = kingOfDiamonds;
                DeckArray[51] = kingOfClubs;

                playerFirstCard = selectACard(DeckArray);
                player.firstCardValue = playerFirstCard.cardValue;
                
                playerSecondCard = selectACard(DeckArray);
                player.secondCardValue = playerSecondCard.cardValue;
                playerCardTotal = player.addCards(player.firstCardValue, player.secondCardValue, player.thirdCardValue, player.fourthCardValue, player.fifthCardValue);

                dealerFirstCard = selectACard(DeckArray);
                dealer.firstCardValue = dealerFirstCard.cardValue;
                dealerSecondCard = selectACard(DeckArray);
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
                        Console.WriteLine("I'm sorry, the dealer's total is higher and has won.");
                        Console.WriteLine("Press any key to replay");
                        Console.ReadLine();
                    }
                    else if (playerCardTotal == dealerCardTotal)
                    {
                        Console.WriteLine("i'm sorry, the dealer has matched your score and has won.");
                        Console.WriteLine("Press any key to replay");
                        Console.ReadLine();
                    }
                    else if (playerCardTotal > dealerCardTotal)
                    {
                        Console.WriteLine("The Dealer Twists.");
                        dealerThirdCard = selectACard(DeckArray);
                        dealer.thirdCardValue = dealerThirdCard.cardValue;
                        dealerCardTotal = dealer.addCards(dealer.firstCardValue, dealer.secondCardValue, dealer.thirdCardValue, dealer.fourthCardValue, dealer.fifthCardValue);
                        Console.WriteLine("The dealer got a " + dealerThirdCard.cardName + " of " + dealerThirdCard.cardSuit + ". Their total is now " + dealerCardTotal);
                        if (dealer.CheckWhetherBust(dealerCardTotal))
                        {
                            Console.WriteLine("The dealer is bust. You win.");
                            Console.WriteLine("Press any key to replay");
                            Console.ReadLine();
                        }
                        else if (dealerCardTotal == playerCardTotal)
                        {
                            Console.WriteLine("Ooooh, so close but i'm afraid the dealer has matched your score and has won.");
                            Console.WriteLine("Press any key to replay");
                            Console.ReadLine();
                        }
                        else if (dealerCardTotal > playerCardTotal)
                        {
                            Console.WriteLine("The dealer has beaten your score and has won.");
                            Console.WriteLine("Press any key to replay");
                            Console.ReadLine();
                        }
                        else if (dealerCardTotal < playerCardTotal)
                        {
                            Console.WriteLine("The dealer twists.");
                            dealerFourthCard = selectACard(DeckArray);
                            dealer.fourthCardValue = dealerFourthCard.cardValue;
                            dealerCardTotal = dealer.addCards(dealer.firstCardValue, dealer.secondCardValue, dealer.thirdCardValue, dealer.fourthCardValue, dealer.fifthCardValue);
                            Console.WriteLine("The dealer got a " + dealerFourthCard.cardName + " of " + dealerFourthCard.cardSuit + ". Their total is now " + dealerCardTotal);
                            if (dealerCardTotal > 21)
                            {
                                Console.WriteLine("The dealer is bust. You win.");
                                Console.WriteLine("Press any key to replay");
                                Console.ReadLine();
                            }
                            else if (dealerCardTotal == playerCardTotal)
                            {
                                Console.WriteLine("Ooooh, so close but i'm afraid the dealer has matched your score and has won.");
                                Console.WriteLine("Press any key to replay");
                                Console.ReadLine();
                            }
                            else if (dealerCardTotal > playerCardTotal)
                            {
                                Console.WriteLine("The dealer has beaten your score and has won.");
                                Console.WriteLine("Press any key to replay");
                                Console.ReadLine();
                            }
                            else if (dealerCardTotal < playerCardTotal)
                            {
                                Console.WriteLine("The dealer twists.");
                                dealerFifthCard = selectACard(DeckArray);
                                dealer.fifthCardValue = dealerFifthCard.cardValue;
                                dealerCardTotal = dealer.addCards(dealer.firstCardValue, dealer.secondCardValue, dealer.thirdCardValue, dealer.fourthCardValue, dealer.fifthCardValue);
                                Console.WriteLine("The dealer got a " + dealerFifthCard.cardName + " of " + dealerFifthCard.cardSuit + ". Their total is now " + dealerCardTotal);
                                if (dealer.CheckWhetherBust(dealerCardTotal))
                                {
                                    Console.WriteLine("The dealer is bust. You win.");
                                    Console.WriteLine("Press any key to replay");
                                    Console.ReadLine();
                                }
                                else if (dealerCardTotal == playerCardTotal)
                                {
                                    Console.WriteLine("Ooooh, so close but i'm afraid the dealer has matched your score and has won.");
                                    Console.WriteLine("Press any key to replay");
                                    Console.ReadLine();
                                }
                                else if (dealerCardTotal > playerCardTotal)
                                {
                                    Console.WriteLine("The dealer has beaten your score and has won.");
                                    Console.WriteLine("Press any key to replay");
                                    Console.ReadLine();
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
                    playerThirdCard = selectACard(DeckArray);
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
                                Console.WriteLine("I'm sorry, the dealer's total is higher and has won.");
                                Console.WriteLine("Press any key to replay");
                                Console.ReadLine();
                            }
                            else if (playerCardTotal == dealerCardTotal)
                            {
                                Console.WriteLine("i'm sorry, the dealer has matched your score and has won.");
                                Console.WriteLine("Press any key to replay");
                                Console.ReadLine();
                            }
                            else if (playerCardTotal > dealerCardTotal)
                            {
                                Console.WriteLine("The Dealer Twists.");
                                dealerThirdCard = selectACard(DeckArray);
                                dealer.thirdCardValue = dealerThirdCard.cardValue;
                                dealerCardTotal = dealer.addCards(dealer.firstCardValue, dealer.secondCardValue, dealer.thirdCardValue, dealer.fourthCardValue, dealer.fifthCardValue);
                                Console.WriteLine("The dealer got a " + dealerThirdCard.cardName + " of " + dealerThirdCard.cardSuit + ". Their total is now " + dealerCardTotal);
                                if (dealer.CheckWhetherBust(dealerCardTotal))
                                {
                                    Console.WriteLine("The dealer is bust. You win.");
                                    Console.WriteLine("Press any key to replay");
                                    Console.ReadLine();
                                }
                                else if (dealerCardTotal == playerCardTotal)
                                {
                                    Console.WriteLine("Ooooh, so close but i'm afraid the dealer has matched your score and has won.");
                                    Console.WriteLine("Press any key to replay");
                                    Console.ReadLine();
                                }
                                else if (dealerCardTotal > playerCardTotal)
                                {
                                    Console.WriteLine("The dealer has beaten your score and has won.");
                                    Console.WriteLine("Press any key to replay");
                                    Console.ReadLine();
                                }
                                else if (dealerCardTotal < playerCardTotal)
                                {
                                    Console.WriteLine("The dealer twists.");
                                    dealerFourthCard = selectACard(DeckArray);
                                    dealer.fourthCardValue = dealerFourthCard.cardValue;
                                    dealerCardTotal = dealer.addCards(dealer.firstCardValue, dealer.secondCardValue, dealer.thirdCardValue, dealer.fourthCardValue, dealer.fifthCardValue);
                                    Console.WriteLine("The dealer got a " + dealerFourthCard.cardName + " of " + dealerFourthCard.cardSuit + ". Their total is now " + dealerCardTotal);
                                    if (dealer.CheckWhetherBust(dealerCardTotal))
                                    {
                                        Console.WriteLine("The dealer is bust. You win.");
                                        Console.WriteLine("Press any key to replay");
                                        Console.ReadLine();
                                    }
                                    else if (dealerCardTotal == playerCardTotal)
                                    {
                                        Console.WriteLine("Ooooh, so close but i'm afraid the dealer has matched your score and has won.");
                                        Console.WriteLine("Press any key to replay");
                                        Console.ReadLine();
                                    }
                                    else if (dealerCardTotal > playerCardTotal)
                                    {
                                        Console.WriteLine("The dealer has beaten your score and has won.");
                                        Console.WriteLine("Press any key to replay");
                                        Console.ReadLine();
                                    }
                                    else if (dealerCardTotal < playerCardTotal)
                                    {
                                        Console.WriteLine("The dealer twists.");
                                        dealerFifthCard = selectACard(DeckArray);
                                        dealer.fifthCardValue = dealerFifthCard.cardValue;
                                        dealerCardTotal = dealer.addCards(dealer.firstCardValue, dealer.secondCardValue, dealer.thirdCardValue, dealer.fourthCardValue, dealer.fifthCardValue);
                                        Console.WriteLine("The dealer got a " + dealerFifthCard.cardName + " of " + dealerFifthCard.cardSuit + ". Their total is now " + dealerCardTotal);
                                        if (dealer.CheckWhetherBust(dealerCardTotal))
                                        {
                                            Console.WriteLine("The dealer is bust. You win.");
                                            Console.WriteLine("Press any key to replay");
                                            Console.ReadLine();
                                        }
                                        else if (dealerCardTotal == playerCardTotal)
                                        {
                                            Console.WriteLine("Ooooh, so close but i'm afraid the dealer has matched your score and has won.");
                                            Console.WriteLine("Press any key to replay");
                                            Console.ReadLine();
                                        }
                                        else if (dealerCardTotal > playerCardTotal)
                                        {
                                            Console.WriteLine("The dealer has beaten your score and has won.");
                                            Console.WriteLine("Press any key to replay");
                                            Console.ReadLine();
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
                            playerFourthCard = selectACard(DeckArray);
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
                                        Console.WriteLine("I'm sorry, the dealer's total is higher and has won.");
                                        Console.WriteLine("Press any key to replay");
                                        Console.ReadLine();
                                    }
                                    else if (playerCardTotal == dealerCardTotal)
                                    {
                                        Console.WriteLine("i'm sorry, the dealer has matched your score and has won.");
                                        Console.WriteLine("Press any key to replay");
                                        Console.ReadLine();
                                    }
                                    else if (playerCardTotal > dealerCardTotal)
                                    {
                                        Console.WriteLine("The Dealer Twists.");
                                        dealerThirdCard = selectACard(DeckArray);
                                        dealer.thirdCardValue = dealerThirdCard.cardValue;
                                        dealerCardTotal = dealer.addCards(dealer.firstCardValue, dealer.secondCardValue, dealer.thirdCardValue, dealer.fourthCardValue, dealer.fifthCardValue);
                                        Console.WriteLine("The dealer got a " + dealerThirdCard.cardName + " of " + dealerThirdCard.cardSuit + ". Their total is now " + dealerCardTotal);
                                        if (dealer.CheckWhetherBust(dealerCardTotal))
                                        {
                                            Console.WriteLine("The dealer is bust. You win.");
                                            Console.WriteLine("Press any key to replay");
                                            Console.ReadLine();
                                        }
                                        else if (dealerCardTotal == playerCardTotal)
                                        {
                                            Console.WriteLine("Ooooh, so close but i'm afraid the dealer has matched your score and has won.");
                                            Console.WriteLine("Press any key to replay");
                                            Console.ReadLine();
                                        }
                                        else if (dealerCardTotal > playerCardTotal)
                                        {
                                            Console.WriteLine("The dealer has beaten your score and has won.");
                                            Console.WriteLine("Press any key to replay");
                                            Console.ReadLine();
                                        }
                                        else if (dealerCardTotal < playerCardTotal)
                                        {
                                            Console.WriteLine("The dealer twists.");
                                            dealerFourthCard = selectACard(DeckArray);
                                            dealer.fourthCardValue = dealerFourthCard.cardValue;
                                            dealerCardTotal = dealer.addCards(dealer.firstCardValue, dealer.secondCardValue, dealer.thirdCardValue, dealer.fourthCardValue, dealer.fifthCardValue);
                                            Console.WriteLine("The dealer got a " + dealerFourthCard.cardName + " of " + dealerFourthCard.cardSuit + ". Their total is now " + dealerCardTotal);
                                            if (dealer.CheckWhetherBust(dealerCardTotal))
                                            {
                                                Console.WriteLine("The dealer is bust. You win.");
                                                Console.WriteLine("Press any key to replay");
                                                Console.ReadLine();
                                            }
                                            else if (dealerCardTotal == playerCardTotal)
                                            {
                                                Console.WriteLine("Ooooh, so close but i'm afraid the dealer has matched your score and has won.");
                                                Console.WriteLine("Press any key to replay");
                                                Console.ReadLine();
                                            }
                                            else if (dealerCardTotal > playerCardTotal)
                                            {
                                                Console.WriteLine("The dealer has beaten your score and has won.");
                                                Console.WriteLine("Press any key to replay");
                                                Console.ReadLine();
                                            }
                                            else if (dealerCardTotal < playerCardTotal)
                                            {
                                                Console.WriteLine("The dealer twists.");
                                                dealerFifthCard = selectACard(DeckArray);
                                                dealer.fifthCardValue = dealerFifthCard.cardValue;
                                                dealerCardTotal = dealer.addCards(dealer.firstCardValue, dealer.secondCardValue, dealer.thirdCardValue, dealer.fourthCardValue, dealer.fifthCardValue);
                                                Console.WriteLine("The dealer got a " + dealerFifthCard.cardName + " of " + dealerFifthCard.cardSuit + ". Their total is now " + dealerCardTotal);
                                                if (dealer.CheckWhetherBust(dealerCardTotal))
                                                {
                                                    Console.WriteLine("The dealer is bust. You win.");
                                                    Console.WriteLine("Press any key to replay");
                                                    Console.ReadLine();
                                                }
                                                else if (dealerCardTotal == playerCardTotal)
                                                {
                                                    Console.WriteLine("Ooooh, so close but i'm afraid the dealer has matched your score and has won.");
                                                    Console.WriteLine("Press any key to replay");
                                                    Console.ReadLine();
                                                }
                                                else if (dealerCardTotal > playerCardTotal)
                                                {
                                                    Console.WriteLine("The dealer has beaten your score and has won.");
                                                    Console.WriteLine("Press any key to replay");
                                                    Console.ReadLine();
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
                                    playerFifthCard = selectACard(DeckArray);
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
                                            Console.WriteLine("I'm sorry, the dealer's total is higher and has won.");
                                            Console.WriteLine("Press any key to replay");
                                            Console.ReadLine();
                                        }
                                        else if (playerCardTotal == dealerCardTotal)
                                        {
                                            Console.WriteLine("i'm sorry, the dealer has matched your score and has won.");
                                            Console.WriteLine("Press any key to replay");
                                            Console.ReadLine();
                                        }
                                        else if (playerCardTotal > dealerCardTotal)
                                        {
                                            Console.WriteLine("The Dealer Twists.");
                                            dealerThirdCard = selectACard(DeckArray);
                                            dealer.thirdCardValue = dealerThirdCard.cardValue;
                                            dealerCardTotal = dealer.addCards(dealer.firstCardValue, dealer.secondCardValue, dealer.thirdCardValue, dealer.fourthCardValue, dealer.fifthCardValue);
                                            Console.WriteLine("The dealer got a " + dealerThirdCard.cardName + " of " + dealerThirdCard.cardSuit + ". Their total is now " + dealerCardTotal);
                                            if (dealer.CheckWhetherBust(dealerCardTotal))
                                            {
                                                Console.WriteLine("The dealer is bust. You win.");
                                                Console.WriteLine("Press any key to replay");
                                                Console.ReadLine();
                                            }
                                            else if (dealerCardTotal == playerCardTotal)
                                            {
                                                Console.WriteLine("Ooooh, so close but i'm afraid the dealer has matched your score and has won.");
                                                Console.WriteLine("Press any key to replay");
                                                Console.ReadLine();
                                            }
                                            else if (dealerCardTotal > playerCardTotal)
                                            {
                                                Console.WriteLine("The dealer has beaten your score and has won.");
                                                Console.WriteLine("Press any key to replay");
                                                Console.ReadLine();
                                            }
                                            else if (dealerCardTotal < playerCardTotal)
                                            {
                                                Console.WriteLine("The dealer twists.");
                                                dealerFourthCard = selectACard(DeckArray);
                                                dealer.fourthCardValue = dealerFourthCard.cardValue;
                                                dealerCardTotal = dealer.addCards(dealer.firstCardValue, dealer.secondCardValue, dealer.thirdCardValue, dealer.fourthCardValue, dealer.fifthCardValue);
                                                Console.WriteLine("The dealer got a " + dealerFourthCard.cardName + " of " + dealerFourthCard.cardSuit + ". Their total is now " + dealerCardTotal);
                                                if (dealer.CheckWhetherBust(dealerCardTotal))
                                                {
                                                    Console.WriteLine("The dealer is bust. You win.");
                                                    Console.WriteLine("Press any key to replay");
                                                    Console.ReadLine();
                                                }
                                                else if (dealerCardTotal == playerCardTotal)
                                                {
                                                    Console.WriteLine("Ooooh, so close but i'm afraid the dealer has matched your score and has won.");
                                                    Console.WriteLine("Press any key to replay");
                                                    Console.ReadLine();
                                                }
                                                else if (dealerCardTotal > playerCardTotal)
                                                {
                                                    Console.WriteLine("The dealer has beaten your score and has won.");
                                                    Console.WriteLine("Press any key to replay");
                                                    Console.ReadLine();
                                                }
                                                else if (dealerCardTotal < playerCardTotal)
                                                {
                                                    Console.WriteLine("The dealer twists.");
                                                    dealerFifthCard = selectACard(DeckArray);
                                                    dealer.fifthCardValue = dealerFifthCard.cardValue;
                                                    dealerCardTotal = dealer.addCards(dealer.firstCardValue, dealer.secondCardValue, dealer.thirdCardValue, dealer.fourthCardValue, dealer.fifthCardValue);
                                                    Console.WriteLine("The dealer got a " + dealerFifthCard.cardName + " of " + dealerFifthCard.cardSuit + ". Their total is now " + dealerCardTotal);
                                                    if (dealer.CheckWhetherBust(dealerCardTotal))
                                                    {
                                                        Console.WriteLine("The dealer is bust. You win.");
                                                        Console.WriteLine("Press any key to replay");
                                                        Console.ReadLine();
                                                    }
                                                    else if (dealerCardTotal == playerCardTotal)
                                                    {
                                                        Console.WriteLine("Ooooh, so close but i'm afraid the dealer has matched your score and has won.");
                                                        Console.WriteLine("Press any key to replay");
                                                        Console.ReadLine();
                                                    }
                                                    else if (dealerCardTotal > playerCardTotal)
                                                    {
                                                        Console.WriteLine("The dealer has beaten your score and has won.");
                                                        Console.WriteLine("Press any key to replay");
                                                        Console.ReadLine();
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

        public PlayingCard selectACard(PlayingCard[] PassedDeckArray)
        {
                PlayingCard selectedCard;

                int selectecCardnumber = random.Next(1, 52);
                selectedCard = PassedDeckArray[selectecCardnumber];

            return selectedCard;
        }


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
        }

    }
}
