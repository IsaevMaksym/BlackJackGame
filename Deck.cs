using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{

    public struct CardSet
    {
        const int suitNum = 5;
        const int cardNum = 14;

        public Card[] cards;
        public int size;
        public Card[,] cDeck;    // 1-мерный массив карт (!+ легко перемешать)

        public static CardSet CreateDeck(int numOfCards, int numOFSuit)                      //Creating memory for card Deck;
        {
            
            CardSet emptyDeck;
            emptyDeck.cDeck = new Card[numOfCards, numOFSuit];
            return emptyDeck;
        }

        public static Card GetCard(CardSet d)
        {
            Card lastCard = d.cards[d.size-1];
            --d.size;

            return lastCard;
        }

        public static bool AddCardToCardSet(CardSet d, Card c)
        {
            bool ok = d.size < d.cards.Length;

            if (ok)
            {
                d.cards[d.size - 1] = c;
                ++d.size;
            }

            return ok;
        }

        public static void FillTheDeck( ref Card cDeck)                                 //Fill up Structure with values.
        {
            CardSet bJDeck = CardSet.CreateDeck(13, 4);

            for (int i = 1; i < suitNum; i++)
            {
                for (int j = 1; j < cardNum; j++)
                {
                    
                    cDeck.cardNum = 1;
                    cDeck.cardNum++;
                    switch (i)
                    {
                        case 1:
                            cDeck.suit = "spades";
                            break;

                        case 2:
                            cDeck.suit = "clubs";
                            break;

                        case 3:
                            cDeck.suit = "hearts";
                            break;

                        case 4:
                            cDeck.suit = "diamonds";
                            break;

                    }

                    switch (j)
                    {
                        case 1:
                            cDeck.valueOFCard = 11;
                            cDeck.nameOfCard = "Ace";
                            break;
                        case 2:
                            cDeck.valueOFCard = 2;
                            cDeck.nameOfCard = "Two";
                            break;
                        case 3:
                            cDeck.valueOFCard = 3;
                            cDeck.nameOfCard = "Three";
                            break;
                        case 4:
                            cDeck.valueOFCard = 4;
                            cDeck.nameOfCard = "Four";
                            break;
                        case 5:
                            cDeck.valueOFCard = 5;
                            cDeck.nameOfCard = "FIve";
                            break;
                        case 6:
                            cDeck.valueOFCard = 6;
                            cDeck.nameOfCard = "Six";
                            break;
                        case 7:
                            cDeck.valueOFCard = 7;
                            cDeck.nameOfCard = "Seven";
                            break;
                        case 8:
                            cDeck.valueOFCard = 8;
                            cDeck.nameOfCard = "Eight";
                            break;
                        case 9:
                            cDeck.valueOFCard = 9;
                            cDeck.nameOfCard = "Nine";
                            break;
                        case 10:
                            cDeck.valueOFCard = 10;
                            cDeck.nameOfCard = "Ten";
                            break;
                        case 11:
                            cDeck.valueOFCard = 2;
                            cDeck.nameOfCard = "Jack";
                            break;
                        case 12:
                            cDeck.valueOFCard = 3;
                            cDeck.nameOfCard = "Queen";
                            break;
                        case 13:
                            cDeck.valueOFCard = 4;
                            cDeck.nameOfCard = "King";
                            break;                 

                    }                       
                }
            }
        }
    }
}

     



















        //public static void FillTheDeck()
        //{
        //    int cardNumber=1;
        //    for (int i = 1; i <= suitNum; i++)             //4 suits of cards in deck.
        //    { 
        //        for (int j = 1; j <= cardNum; j++)         //13 cards in 1 suit.
        //        {
        //            Card currentcard=new Card();          //Creating a new card
                 

        //            currentcard.cardNum=cardNumber;       //Set cards Suit;
        //            if (i == 1)
        //            {currentcard.suit = "spades";}
        //            if (i == 2)
        //            {currentcard.suit = [clubs];}
        //            if (i == 3)
        //            {currentcard.suit = "hearts";}
        //            if (i == 4)
        //            {currentcard.suit = "diamonds";}

        //            currentcard.valueOFCard = j;    //Set value of the card.
                    
                
        //       }
        //    }
        //}




//    public struct Deck
//    {
//        public List<Card>cards;
//        public Deck()
//        {
//            cards = new List<Card>();
//            CreateCardDeck();
//        }
   
//    public static void CreateCardDeck()
//    {
//    int cardNum=1;
//    for (int i = 1; i < 5; i++)           //4 suits of cards in deck.
//            {
//             for (int j = 1; j < 14; j++)   //13 cards in 1 suit.
//            {
			 
//            }
//            }

//    }
//}
