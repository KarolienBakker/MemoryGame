using MemoryGame.Core;

Console.Clear();

bool programLoop = true;

while(programLoop)
{
    MemoryGame<int> memoryGame = StartGame();
    while (memoryGame.GameRunning)
    {

        Console.WriteLine(memoryGame.PlayerBoard.ToString() + "\n\n");

        Console.WriteLine("Which card do you want to check: ");
        string[] coords = Console.ReadLine().Split(',');

        if (coords.Length != 2 || !int.TryParse(coords[0], out int x) || !int.TryParse(coords[1], out int y))
        {
            Console.WriteLine("Invalid input. Please enter valid coordinates.");

        }
        else if (!memoryGame.CoordsExist(x, y))
        {
            Console.WriteLine("Coordinates do not exist.");
        }
        else if (memoryGame.CheckIfCardFlipped(x, y))
        {
            Console.WriteLine("Card is already flipped.");
        }
        else
        {
            memoryGame.PlayRound(x, y);

            if (memoryGame.GameRunning == false)
            {
                Console.WriteLine("You won! Press any key to play another game.");
                Console.ReadKey();
                break;
            }
        }
    }
}

MemoryGame<int> StartGame()
{
    Console.Write("Please enter your name: ");
    string name = Console.ReadLine();
    Console.Write("How many cards do you want to play with: ");
    int amountOfCards = int.Parse(Console.ReadLine());

    // keep asking for input until the input is valid
    while (amountOfCards < 5 || amountOfCards > 20)
    {
        Console.WriteLine("Invalid input. Please enter a number between 5 and 20.");
        amountOfCards = int.Parse(Console.ReadLine());
    }

    List<int> pairsList = new List<int>();

    for (int i = 1; i <= amountOfCards; i++)
    {
        pairsList.Add(i);
        pairsList.Add(i);
    }

    return new MemoryGame<int>(amountOfCards, pairsList, name);
}


