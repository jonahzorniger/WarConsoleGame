using ConsoleGame.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            int totalTurnCount = 0;
            int finiteGameCount = 0;

            for (int count = 0; count < 1000; count++)
            {
                Game game = new Game("Eli", "Jonah");
                while (!game.IsEndOfGame())
                {
                    game.PlayTurn();
                }
                Console.WriteLine("\nThe game is over, press any key to play again");
                Console.ReadLine();
                Console.Clear();

                if (game.IsEndOfGame())
                {
                    count = 0;
                }

                if (game.TurnCount < 1000)
                {
                    totalTurnCount += game.TurnCount;
                    finiteGameCount++;
                }
            }
        }
    }
}
