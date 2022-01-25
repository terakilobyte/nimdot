public class Nim
{
    enum Player
    {
        Human,
        Computer
    }

    int total { get; set; }
    Player currentPlayer { get; set; }
    bool gameOver { get; set; }

    public Nim()
    {
        total = 1;
        currentPlayer = Player.Human;
        gameOver = false;
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
        if (total >= 21)
        {
            gameOver = true;
        }
    }

    public void HumanTurn()
    {
        var choice = GetChoice(total);
        Console.WriteLine("You chose {0}. The total is now {1}.", choice, total + choice);
        total += choice;
        CheckGame();
        currentPlayer = Player.Computer;
    }

    public void ComputerTurn()
    {
        Thread.Sleep(1000);
        int choice;
        if (total == 20)
        {
            choice = 1;
        }
        else
        {
            choice = total % 4 != 0 ? 4 - (total % 4) : Random.Shared.Next(1, 4); ;
        }
        total += choice;
        Console.WriteLine("I chose {0}. The total is now {1}.", choice, total);
        CheckGame();
        currentPlayer = Player.Human;
    }

    public void GameLoop()
    {
        while (!gameOver)
        {
            if (currentPlayer == Player.Human)
            {
                HumanTurn();
            }
            else
            {
                ComputerTurn();
            }
        }
        if (currentPlayer == Player.Computer)
        {
            Console.WriteLine("You lose!");
        }
        else
        {
            Console.WriteLine("You win!");
        }
    }
}
