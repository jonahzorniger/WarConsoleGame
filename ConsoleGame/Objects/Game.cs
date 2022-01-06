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
        public int TurnCount;

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
                return true;
            }
            else if (TurnCount > 1000)
            {
                Console.WriteLine("\nLet's call this a draw! It's taking way to long!");
                return true;
            }
            return false;   
                       
        }

        public void PlayTurn()
        {
            Queue<Card> pool = new Queue<Card>();

            var player1card = Player1.Deck.Dequeue();
            var player2card = Player2.Deck.Dequeue();

            pool.Enqueue(player1card);
            pool.Enqueue(player2card);

            Console.WriteLine(Player1.Name + " has played a " + player1card.Name + " ...... " + Player2.Name + " has played a " + player2card.Name);

            while (player1card.Value == player2card.Value)
            {
                Console.WriteLine("THIS MEANS WAR!!!!");
                if (Player1.Deck.Count < 4)
                {
                    Player1.Deck.Clear();
                    return;
                }
                if (Player2.Deck.Count < 4)
                {
                    Player2.Deck.Clear();
                    return;
                }                

                pool.Enqueue(Player1.Deck.Dequeue());
                pool.Enqueue(Player1.Deck.Dequeue());
                pool.Enqueue(Player1.Deck.Dequeue());
                pool.Enqueue(Player2.Deck.Dequeue());
                pool.Enqueue(Player2.Deck.Dequeue());
                pool.Enqueue(Player2.Deck.Dequeue());

                player1card = Player1.Deck.Dequeue();
                player2card = Player2.Deck.Dequeue();

                pool.Enqueue(player1card);
                pool.Enqueue(player2card);

                Console.WriteLine(Player1.Name + " has played a " + player1card.Name + "......" + Player2.Name + " has played a " + player2card.Name);
            }

            if(player1card.Value < player2card.Value)
            {
                Player2.Deck.Enqueue(pool);
                Console.WriteLine("And the winner is... " + Player2.Name + "! \n" + "Winner winner, chicken dinner!");
            }
            else
            {
                Player1.Deck.Enqueue(pool);
                Console.WriteLine("And the winner is... " + Player1.Name + "! \n" + "Winner winner, chicken dinner!");
            }
            
            TurnCount++;
        }
    }
}
