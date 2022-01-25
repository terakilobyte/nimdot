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

        enum Variant
        {
            Nim21,
            Nim100
        }

        int Total { get; set; }
        Player CurrentPlayer { get; set; }
        bool GameOver { get; set; }
        Variant gameType { get; set; }

        public Nim()
        {
            Total = 1;
            CurrentPlayer = Player.Human;
            GameOver = false;
        }
        public void StartGame()
        {
            Console.WriteLine("Hello! Let's play a game of Nim!");
            switch (GetGameType()) {
                case 21:
                    Nim21();
                    break;
                case 100:
                    Nim100();
                    break;
            }

            GameLoop();
        }

        public void Nim21()
        {
            gameType = Variant.Nim21;
            Console.WriteLine("The game begins with one player saying the number 1, then each player takes turns saying 1, 2, or 3, adding to a running total.");
            Console.WriteLine("The player who is forced to say a number resulting in a total of 21 or greater loses!");
            Console.WriteLine("I'll go first. 1, for a total of 1.");
        }

        public void Nim100()
        {
            gameType = Variant.Nim100;
            Console.WriteLine("The game begins with one player saying a number between 1 and 10 (inclusive), then each player takes turns saying a number between 1 and 10 (inclusive), adding to a running total.");
            Console.WriteLine("The player who says 100 or greater first wins!");
            var random = new Random();
            var choice = random.Next(1, 11);
            Total = choice;
            Console.WriteLine("I'll go first. {0}, for a total of {1}.", choice, Total);

        }

        private static int GetGameType()
        {
            int choice;
            do
            {
                Console.WriteLine("Would you like to play a game of Nim 21 or Nim 100? Enter 21 for Nim 21, and 100 for Nim 100");
                choice = int.Parse(Console.ReadLine());
            } while (!(choice != 21 || choice != 100));
            return choice;
        }

        private static int GetChoice21(int total)
        {
            int choice;
            do
            {
                Console.WriteLine("Your turn. The total is currently {0}. Choose 1, 2, or 3.", total);
                choice = int.Parse(Console.ReadLine());
            } while (choice < 1 || choice > 3);
            return choice;
        }
        
        private static int GetChoice100(int total)
        {
            int choice;
            do
            {
                Console.WriteLine("Your turn. The total is currently {0}. Choose a number between 1 and 10 (inclusive)", total);
                choice = int.Parse(Console.ReadLine());
            } while (choice < 1 || choice > 10);
            return choice;
        }

        public void CheckGame()
        {
            if (Total >= 21 && gameType == Variant.Nim21)
            {
                GameOver = true;
            }
            if (Total >= 100 && gameType == Variant.Nim100)
            {
                GameOver = true;
            }
        }

        public void HumanTurn()
        {
            int choice;
            if (gameType == Variant.Nim21)
            {
                choice = Nim.GetChoice21(Total);
            } else if (gameType == Variant.Nim100)
            {
                choice = Nim.GetChoice100(Total);
            } else
            {
                choice = 0;
            }
            Console.WriteLine("You chose {0}. The total is now {1}.", choice, Total + choice);
            Total += choice;
            CheckGame();
            CurrentPlayer = Player.Computer;
        }

        public void ComputerTurn()
        {
            Thread.Sleep(1000);
            int choice;
            switch (gameType)
            {
                case Variant.Nim21:
                    if (Total == 20)
                    {
                        choice = 1;
                    }
                    else
                    {
                        var random = new Random();

                        choice = Total % 4 != 0 ? 4 - (Total % 4) : random.Next(1, 4); ;
                    }
                    break;
                case Variant.Nim100:
                    if (Total > 90)
                    {
                        choice = 100 - Total;
                    } else
                    {
                        var random = new Random();
                        choice = Total % 11 == 1 ? random.Next(1, 11) : Total % 11 == 0 ? 1 : 12 - (Total % 11);
                    }
                    break;
                default:
                    choice = 0;
                    break;
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
            if (CurrentPlayer == Player.Computer && gameType != Variant.Nim100)
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
