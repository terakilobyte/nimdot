using System;
using System.Threading;

namespace NimDot
{
    public class Nim
    {
        enum Player
        {
            Human,
            Computer
        }

        int Total { get; set; }
        Player CurrentPlayer { get; set; }
        bool GameOver { get; set; }

        public Nim()
        {
            Total = 1;
            CurrentPlayer = Player.Human;
            GameOver = false;
        }
        public void StartGame()
        {
            Console.WriteLine("Hello! Let's play a game of Nim (21)!");
            Console.WriteLine("The game begins with one player saying the number 1, then each player takes turns saying 1, 2, or 3, adding to a running total.");
            Console.WriteLine("The player who is forced to say a number resulting in a total of 21 or greater loses!");
            Console.WriteLine("I'll go first. 1, for a total of 1.");
            GameLoop();
        }

        private static int GetChoice(int total)
        {
            int choice;
            do
            {
                Console.WriteLine("Your turn. The total is currently {0}. Choose 1, 2, or 3.", total);
                choice = int.Parse(Console.ReadLine());
            } while (choice < 1 || choice > 3);
            return choice;
        }

        public void CheckGame()
        {
            if (Total >= 21)
            {
                GameOver = true;
            }
        }

        public void HumanTurn()
        {
            var choice = GetChoice(Total);
            Console.WriteLine("You chose {0}. The total is now {1}.", choice, Total + choice);
            Total += choice;
            CheckGame();
            CurrentPlayer = Player.Computer;
        }

        public void ComputerTurn()
        {
            Thread.Sleep(1000);
            int choice;
            if (Total == 20)
            {
                choice = 1;
            }
            else
            {
                var random = new Random();

                choice = Total % 4 != 0 ? 4 - (Total % 4) : random.Next(1, 4); ;
            }
            Total += choice;
            Console.WriteLine("I chose {0}. The total is now {1}.", choice, Total);
            CheckGame();
            CurrentPlayer = Player.Human;
        }

        public void GameLoop()
        {
            while (!GameOver)
            {
                if (CurrentPlayer == Player.Human)
                {
                    HumanTurn();
                }
                else
                {
                    ComputerTurn();
                }
            }
            if (CurrentPlayer == Player.Computer)
            {
                Console.WriteLine("You lose!");
            }
            else
            {
                Console.WriteLine("You win!");
            }
        }
    }
}
