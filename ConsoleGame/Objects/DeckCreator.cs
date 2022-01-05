using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame.Objects
{
    public static class DeckCreator
    {
        public static Queue<Card> CreateCards() { }

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
            foreach(var card in updatedCards)
            {
                shuffledCards.Enqueue(card);
            }
            return shuffledCards;

            

        }
    }
}
