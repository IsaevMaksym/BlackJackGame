using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalExam_Part2
{
    public class CardSet
    {
        private List<Card> deck;
        Random rnd = new Random();

        public CardSet()
        {
            this.CreateDeck();
        }


        private List<Card> CreateDeck()
        {
            deck = new List<Card>();
            return deck;
        }      //Создаёт колоду

        public void FillTheDeck()
        {
            for (CardValue c = CardValue.Two; c <= CardValue.Ace; c++)
            {
                deck.Add(new DiamondsCard() { valueOfCard = c, suitOfCard = CardSuit.Diamonds });
                deck.Add(new HeartsCard() { valueOfCard = c, suitOfCard = CardSuit.Hearts });
                deck.Add(new SpadesCard() { valueOfCard = c, suitOfCard = CardSuit.Spades });
                deck.Add(new ClubCard() { valueOfCard = c, suitOfCard = CardSuit.Clubs });                
            }
            this.SmashDeck();
        }           //Заполняет пустую колоду картами
        
        private void SmashDeck()
        {            
            int count = deck.Count;
            while (count > 1)
            {
                count--;
                int cardPosition = rnd.Next(count + 1);
                Card tempCard = deck[cardPosition];
                deck[cardPosition] = deck[count];
                deck[count] = tempCard;
            }
        }            //Перемешивает колоду

        public Card GetCard()
        {
            if (deck.Count<=0)
            {
                this.CreateDeck();
                this.FillTheDeck();
                this.SmashDeck();                
            }
            Card cardToReturn = deck[deck.Count - 1];
            deck.RemoveAt(deck.Count - 1);
            return cardToReturn;

        }               //Выдаёт карту из колоды






       
        
    }
}
