using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame.Objects
{
    public class Game
    {
        private Player Player1;
        private Player Player2;
        private int TurnCount;

        public Game(string player1name, string player2name)
        {
            Player1 = new Player(player1name);
            Player2 = new Player(player2name);

            var cards = DeckCreator.CreateCards();

            var deck = Player1.Deal(cards);

            Player2.Deck = deck;
        }

        public bool IsEndOfGame()
        {
            if (!Player1.Deck.Any())
            {
                Console.WriteLine(Player1.Name + " is out of cards! " + Player2.Name + " WINS!");
                Console.WriteLine("TURNS: " + TurnCount.ToString());
                return true;
            }
            else if (!Player2.Deck.Any())
            {
                Console.WriteLine(Player2.Name + " is out of cards! " + Player1.Name + " WINS!");
                Console.WriteLine("TURNS: " + TurnCount.ToString());
            }
            else if(TurnCount > 222)
            {
                Console.WriteLine("Let's call this a draw! It's taking way to long!");
                return true;
            }
            return false;
        }

        public void PlayTurn()
        {
            Queue<Card> pool = new Queue<Card>();

            var player1card = Player1.Deck.Dequeue();
            var player2card = Player2.Deck.Dequeue();

            pool.Add(player1card);
            pool.Add(player2card);

            Console.WriteLine(Player1.Name + " has played a " + player1card.Value + " ...... " + Player2.Name + " has played a " + player2card.Value);
        }
    }
}
