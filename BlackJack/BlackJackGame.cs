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
     */

    class BlackJackGame
    {
        public string playerFirstCard;
        public string playerSecondCard;
        public string playerThirdCard;
        public string playerFourthCard;
        public string playerFifthCard;

        public int playerFirstCardValue;
        public int playerSecondCardValue;
        public int playerThirdCardValue = 0;
        public int playerFourthCardValue = 0;
        public int playerFifthCardValue = 0;
        public int playerCardTotal;

        public string dealerFirstCard;
        public string dealerSecondCard;
        public string dealerThirdCard;
        public string dealerFourthCard;
        public string dealerFifthCard;

        public int dealerFirstCardValue;
        public int dealerSecondCardValue;
        public int dealerThirdCardValue;
        public int dealerFourthCardValue;
        public int dealerFifthCardValue;
        public int dealerCardTotal;

        public string firstCardSlot;
        public string secondCardSlot;
        public string thirdCardSlot;
        public string fourthCardSlot;
        public string fifthCardSlot;
        public string sixthCardSlot;
        public string seventhCardSlot;
        public string eightCardslot;
        public string ninthCardSlot;
        public string tenthCardSlot;

        public int selectedCardArraySlotRow = 0;

        Random random = new Random();
        public string[] DeckArray = new string[52];
        public string[] selectedCardArray = new string[10];

        public BlackJackGame()
        {
            DeckArray[0] = "Ace of Spades";
            DeckArray[1] = "Ace of Hearts";
            DeckArray[2] = "Ace of Diamonds";
            DeckArray[3] = "Ace of Clubs";
            DeckArray[4] = "Two of Spades";
            DeckArray[5] = "Two of Hearts";
            DeckArray[6] = "Two of Diamonds";
            DeckArray[7] = "Two of Clubs";
            DeckArray[8] = "Three of Spades";
            DeckArray[9] = "Three of Hearts";
            DeckArray[10] = "Three of Diamonds";
            DeckArray[11] = "Three of Clubs";
            DeckArray[12] = "Four of Spades";
            DeckArray[13] = "Four of Hearts";
            DeckArray[14] = "Four of Diamonds";
            DeckArray[15] = "Four of Clubs";
            DeckArray[16] = "Five of Spades";
            DeckArray[17] = "Five of Hearts";
            DeckArray[18] = "Five of Diamonds";
            DeckArray[19] = "Five of Clubs";
            DeckArray[20] = "Six of Spades";
            DeckArray[21] = "Six of Hearts";
            DeckArray[22] = "Six of Diamonds";
            DeckArray[23] = "Six of Clubs";
            DeckArray[24] = "Seven of Spades";
            DeckArray[25] = "Seven of Hearts";
            DeckArray[26] = "Seven of Diamonds";
            DeckArray[27] = "Seven of Clubs";
            DeckArray[28] = "Eight of Spades";
            DeckArray[29] = "Eight of Hearts";
            DeckArray[30] = "Eight of Diamonds";
            DeckArray[31] = "Eight of Clubs";
            DeckArray[32] = "Nine of Spades";
            DeckArray[33] = "Nine of Hearts";
            DeckArray[34] = "Nine of Diamonds";
            DeckArray[35] = "Nine of Clubs";
            DeckArray[36] = "Ten of Spades";
            DeckArray[37] = "Ten of Hearts";
            DeckArray[38] = "Ten of Diamonds";
            DeckArray[39] = "Ten of Clubs";
            DeckArray[40] = "Jack of Spades";
            DeckArray[41] = "Jack of Hearts";
            DeckArray[42] = "Jack of Diamonds";
            DeckArray[43] = "Jack of Clubs";
            DeckArray[44] = "Queen of Spades";
            DeckArray[45] = "Queen of Hearts";
            DeckArray[46] = "Queen of Diamonds";
            DeckArray[47] = "Queen of Clubs";
            DeckArray[48] = "King of Spades";
            DeckArray[49] = "King of Hearts";
            DeckArray[50] = "King of Diamonds";
            DeckArray[51] = "King of Clubs";

            selectedCardArray[0] = "";
            selectedCardArray[1] = "";
            selectedCardArray[2] = "";
            selectedCardArray[3] = "";
            selectedCardArray[4] = "";
            selectedCardArray[5] = "";
            selectedCardArray[6] = "";
            selectedCardArray[7] = "";
            selectedCardArray[8] = "";
            selectedCardArray[9] = "";

            while (true)
            {
                playerFirstCard = selectACard();
                playerFirstCardValue = getCardValue(playerFirstCard);
                playerSecondCard = selectACard();
                playerSecondCardValue = getCardValue(playerSecondCard);
                playerCardTotal = addCards(playerFirstCardValue, playerSecondCardValue, playerThirdCardValue, playerFourthCardValue, playerFifthCardValue);

                dealerFirstCard = selectACard();
                dealerFirstCardValue = getCardValue(dealerFirstCard);
                dealerSecondCard = selectACard();
                dealerSecondCardValue = getCardValue(dealerSecondCard);
                dealerCardTotal = addCards(dealerFirstCardValue, dealerSecondCardValue, dealerThirdCardValue, dealerFourthCardValue, dealerFifthCardValue);

                Console.WriteLine("Your first card is the: " + playerFirstCard + ". Which is worth: " + playerFirstCardValue);
                Console.WriteLine("Your second card is the: " + playerSecondCard + ". Which is worth: " + playerSecondCardValue);
                Console.WriteLine("Your current total is: " + playerCardTotal);
                Console.WriteLine("Would you like to (S)tick or (T)wist?");
                string userInput = Console.ReadLine();
                if (userInput == "S" || userInput == "Stick")
                {
                    Console.WriteLine("The dealer's first card is the: " + dealerFirstCard + ". Which is worth: " + dealerFirstCardValue);
                    Console.WriteLine("The dealer's second card is the: " + dealerSecondCard + ". which is worth: " + dealerSecondCardValue);
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
                        dealerThirdCard = selectACard();
                        dealerThirdCardValue = getCardValue(dealerThirdCard);
                        dealerCardTotal = addCards(dealerFirstCardValue, dealerSecondCardValue, dealerThirdCardValue, dealerFourthCardValue, dealerFifthCardValue);
                        Console.WriteLine("The dealer got a " + dealerThirdCard + ". Their total is now " + dealerCardTotal);
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
                            dealerFourthCard = selectACard();
                            dealerFourthCardValue = getCardValue(dealerFourthCard);
                            dealerCardTotal = addCards(dealerFirstCardValue, dealerSecondCardValue, dealerThirdCardValue, dealerFourthCardValue, dealerFifthCardValue);
                            Console.WriteLine("The dealer got a " + dealerFourthCard + ". Their total is now " + dealerCardTotal);
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
                                dealerFifthCard = selectACard();
                                dealerFifthCardValue = getCardValue(dealerFifthCard);
                                dealerCardTotal = addCards(dealerFirstCardValue, dealerSecondCardValue, dealerThirdCardValue, dealerFourthCardValue, dealerFifthCardValue);
                                Console.WriteLine("The dealer got a " + dealerFifthCard + ". Their total is now " + dealerCardTotal);
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
                                    Console.WriteLine("Even with 5 cards, the dealer couldn't beat you. Well done.");
                                    Console.WriteLine("Press any key to replay");
                                    Console.ReadLine();
                                }
                            }
                        }
                    }

                } 
                else if (userInput == "T" || userInput == "Twist")
                {
                    Console.WriteLine("You draw another card.");
                    playerThirdCard = selectACard();
                    playerThirdCardValue = getCardValue(playerThirdCard);
                    playerCardTotal = addCards(playerFirstCardValue, playerSecondCardValue, playerThirdCardValue, playerFourthCardValue, playerFifthCardValue);
                    if (checkWhetherBust(playerCardTotal))
                    {
                        Console.WriteLine("You got a " + playerThirdCard + " and your new total is " + playerCardTotal);
                        Console.WriteLine("I'm afraid you have gone bust");
                        Console.WriteLine("Press any key to replay");
                        Console.ReadLine();
                    } 
                    else if (!checkWhetherBust(playerCardTotal))
                    {
                        Console.WriteLine("You got a " + playerThirdCard + " and your new total is " + playerCardTotal);
                        Console.WriteLine("Would you like to (S)tick or (T)wist?");
                        userInput = Console.ReadLine();
                        if (userInput == "S" || userInput == "Stick")
                        {
                            Console.WriteLine("The dealer's first card is the: " + dealerFirstCard + ". Which is worth: " + dealerFirstCardValue);
                            Console.WriteLine("The dealer's second card is the: " + dealerSecondCard + ". which is worth: " + dealerSecondCardValue);
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
                                dealerThirdCard = selectACard();
                                dealerThirdCardValue = getCardValue(dealerThirdCard);
                                dealerCardTotal = addCards(dealerFirstCardValue, dealerSecondCardValue, dealerThirdCardValue, dealerFourthCardValue, dealerFifthCardValue);
                                Console.WriteLine("The dealer got a " + dealerThirdCard + ". Their total is now " + dealerCardTotal);
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
                                    dealerFourthCard = selectACard();
                                    dealerFourthCardValue = getCardValue(dealerFourthCard);
                                    dealerCardTotal = addCards(dealerFirstCardValue, dealerSecondCardValue, dealerThirdCardValue, dealerFourthCardValue, dealerFifthCardValue);
                                    Console.WriteLine("The dealer got a " + dealerFourthCard + ". Their total is now " + dealerCardTotal);
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
                                        dealerFifthCard = selectACard();
                                        dealerFifthCardValue = getCardValue(dealerFifthCard);
                                        dealerCardTotal = addCards(dealerFirstCardValue, dealerSecondCardValue, dealerThirdCardValue, dealerFourthCardValue, dealerFifthCardValue);
                                        Console.WriteLine("The dealer got a " + dealerFifthCard + ". Their total is now " + dealerCardTotal);
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
                                            Console.WriteLine("Even with 5 cards, the dealer couldn't beat you. Well done.");
                                            Console.WriteLine("Press any key to replay");
                                            Console.ReadLine();
                                        }
                                    }
                                }
                            }

                        }
                        else if (userInput == "T" || userInput == "Twist")
                        {
                            Console.WriteLine("You draw another card.");
                            playerFourthCard = selectACard();
                            playerFourthCardValue = getCardValue(playerFourthCard);
                            playerCardTotal = addCards(playerFirstCardValue, playerSecondCardValue, playerThirdCardValue, playerFourthCardValue, playerFifthCardValue);
                            if (checkWhetherBust(playerCardTotal))
                            {
                                Console.WriteLine("You got a " + playerFourthCard + " and your new total is " + playerCardTotal);
                                Console.WriteLine("I'm afraid you have gone bust");
                                Console.WriteLine("Press any key to replay");
                                Console.ReadLine();
                            }
                            else if (!checkWhetherBust(playerCardTotal))
                            {
                                Console.WriteLine("You got a " + playerFourthCard + " and your new total is " + playerCardTotal);
                                Console.WriteLine("Would you like to (S)tick or (T)wist?");
                                userInput = Console.ReadLine();
                                if (userInput == "S" || userInput == "Stick")
                                {
                                    Console.WriteLine("The dealer's first card is the: " + dealerFirstCard + ". Which is worth: " + dealerFirstCardValue);
                                    Console.WriteLine("The dealer's second card is the: " + dealerSecondCard + ". which is worth: " + dealerSecondCardValue);
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
                                        dealerThirdCard = selectACard();
                                        dealerThirdCardValue = getCardValue(dealerThirdCard);
                                        dealerCardTotal = addCards(dealerFirstCardValue, dealerSecondCardValue, dealerThirdCardValue, dealerFourthCardValue, dealerFifthCardValue);
                                        Console.WriteLine("The dealer got a " + dealerThirdCard + ". Their total is now " + dealerCardTotal);
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
                                            dealerFourthCard = selectACard();
                                            dealerFourthCardValue = getCardValue(dealerFourthCard);
                                            dealerCardTotal = addCards(dealerFirstCardValue, dealerSecondCardValue, dealerThirdCardValue, dealerFourthCardValue, dealerFifthCardValue);
                                            Console.WriteLine("The dealer got a " + dealerFourthCard + ". Their total is now " + dealerCardTotal);
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
                                                dealerFifthCard = selectACard();
                                                dealerFifthCardValue = getCardValue(dealerFifthCard);
                                                dealerCardTotal = addCards(dealerFirstCardValue, dealerSecondCardValue, dealerThirdCardValue, dealerFourthCardValue, dealerFifthCardValue);
                                                Console.WriteLine("The dealer got a " + dealerFifthCard + ". Their total is now " + dealerCardTotal);
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
                                                    Console.WriteLine("Even with 5 cards, the dealer couldn't beat you. Well done.");
                                                    Console.WriteLine("Press any key to replay");
                                                    Console.ReadLine();
                                                }
                                            }
                                        }
                                    }

                                }
                                else if (userInput == "T" || userInput == "Twist")
                                {
                                    Console.WriteLine("You draw another card.");
                                    playerFifthCard = selectACard();
                                    playerFifthCardValue = getCardValue(playerFifthCard);
                                    playerCardTotal = addCards(playerFirstCardValue, playerSecondCardValue, playerThirdCardValue, playerFourthCardValue, playerFifthCardValue);
                                    if (checkWhetherBust(playerCardTotal))
                                    {
                                        Console.WriteLine("You got a " + playerFifthCard + " and your new total is " + playerCardTotal);
                                        Console.WriteLine("I'm afraid you have gone bust");
                                        Console.ReadLine();
                                    }
                                    else if (!checkWhetherBust(playerCardTotal))
                                    {
                                        Console.WriteLine("The dealer's first card is the: " + dealerFirstCard + ". Which is worth: " + dealerFirstCardValue);
                                        Console.WriteLine("The dealer's second card is the: " + dealerSecondCard + ". which is worth: " + dealerSecondCardValue);
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
                                            dealerThirdCard = selectACard();
                                            dealerThirdCardValue = getCardValue(dealerThirdCard);
                                            dealerCardTotal = addCards(dealerFirstCardValue, dealerSecondCardValue, dealerThirdCardValue, dealerFourthCardValue, dealerFifthCardValue);
                                            Console.WriteLine("The dealer got a " + dealerThirdCard + ". Their total is now " + dealerCardTotal);
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
                                                dealerFourthCard = selectACard();
                                                dealerFourthCardValue = getCardValue(dealerFourthCard);
                                                dealerCardTotal = addCards(dealerFirstCardValue, dealerSecondCardValue, dealerThirdCardValue, dealerFourthCardValue, dealerFifthCardValue);
                                                Console.WriteLine("The dealer got a " + dealerFourthCard + ". Their total is now " + dealerCardTotal);
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
                                                    dealerFifthCard = selectACard();
                                                    dealerFifthCardValue = getCardValue(dealerFifthCard);
                                                    dealerCardTotal = addCards(dealerFirstCardValue, dealerSecondCardValue, dealerThirdCardValue, dealerFourthCardValue, dealerFifthCardValue);
                                                    Console.WriteLine("The dealer got a " + dealerFifthCard + ". Their total is now " + dealerCardTotal);
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

        public string selectACard()
        {
                string selectedCard;

                int selectecCardnumber = random.Next(1, 52);
                selectedCard = DeckArray[selectecCardnumber];

            return selectedCard;
        }

        public void addCardToChosenCardArray(string selectedCard, int arraySlotRow)
        {
            selectedCardArray[0] = selectedCard;
            selectedCardArraySlotRow = selectedCardArraySlotRow + 1;
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

        public int getCardValue(string cardName)
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

        public int addCards(int firstCard, int secondCard, int thirdCard, int fourthCard, int fifthCard)
        {
            int total;
            total = (firstCard + secondCard + thirdCard + fourthCard + fifthCard);
            return total;
        }

        public bool checkWhetherBust(int currentTotal)
        {
            bool isPlayerBust;

            if (currentTotal > 21)
            {
                isPlayerBust = true;
            } else
            {
                isPlayerBust = false;
            }

            return isPlayerBust;
        }


    }
}
