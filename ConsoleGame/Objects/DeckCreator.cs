using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame.Objects
{
    public static class DeckCreator
    {
        public static Queue<Card> CreateCards()
        {
            Queue<Card> cards = new Queue<Card>();
            for (int cardNumber = 2; cardNumber <= 14; cardNumber++)
            {
                foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                {
                    cards.Enqueue(new Card()
                    {
                        Suit = suit,
                        Value = cardNumber,
                        DisplayName = GetCardName(cardNumber, suit)
                    });
                }
            }
            return Shuffle(cards);
        }

        private static Queue<Card> Shuffle(Queue<Card> cards)
        {
            List<Card> updatedCards = cards.ToList();
            Random r = new Random(DateTime.Now.Millisecond);
            for (int newCardCount = updatedCards.Count - 1; newCardCount > 0; --newCardCount)
            {
                int chosenCard = r.Next(newCardCount + 1);

                Card card = updatedCards[chosenCard];
                updatedCards[newCardCount] = updatedCards[chosenCard];
                updatedCards[chosenCard] = card;
            }

            Queue<Card> shuffledCards = new Queue<Card>();
            foreach (var card in updatedCards)
            {
                shuffledCards.Enqueue(card);
            }
            return shuffledCards;



        }

        private static string GetCardName(int value, Suit suit)
        {
            string displayValue = "";
            if(value >= 2 && value <= 10)
            {
                displayValue = value.ToString();
            }
            else if (value == 11)
            {
                displayValue = "Jack";
            }
            else if (value == 12)
            {
                displayValue = "Queen";
            }
            else if (value == 13)
            {
                displayValue = "King";
            }
            else if (value == 14)
            {
                displayValue = "Ace";
            }

            return displayValue + Enum.GetName(typeof(Suit), suit)[0];
        }
    }
}
