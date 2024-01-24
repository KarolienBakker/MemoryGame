using MemoryGame.Core;
using System.Numerics;

int amountOfCards = 6;

List<int> pairsList = new List<int>();

for (int i = 1; i <= amountOfCards; i++)
{
    pairsList.Add(i);
    pairsList.Add(i); 
}

MemoryGame<int> memoryGame = new MemoryGame<int>(amountOfCards, pairsList);

int amountOfCardsFlipped = 0;
List<int> cardsFlipped = new List<int>();
List<List<int>> cardsFlippedCoords = new List<List<int>>();

 while (memoryGame.GameRunning)
{

    Console.WriteLine(memoryGame.PlayerBoard.ToString());
    Console.WriteLine("Wich card do you want to check?");
    string[] coords = Console.ReadLine().Split(',');
    int x = int.Parse(coords[0]);
    int y = int.Parse(coords[1]);

    List<int> intCoords = new List<int>();
    intCoords.Add(x);
    intCoords.Add(y);
    cardsFlippedCoords.Add(intCoords);

    int flippedCard = memoryGame.GameBoard.GetValue(x, y);
   
   
    

    if (amountOfCardsFlipped == 2)
    {
        int isEqual = cardsFlipped[0] / cardsFlipped[1];
        if (isEqual != 1) {
            foreach (var coord in cardsFlippedCoords)
            {
                memoryGame.PlayerBoard.SetValue(coord[0], coord[1], 0);
            }
            cardsFlippedCoords.Clear();
        }
    }
    
    amountOfCardsFlipped++;

    if (amountOfCardsFlipped > 2)
    {
        amountOfCardsFlipped = 1;
      
        cardsFlipped.Clear();

    }
    cardsFlipped.Add(flippedCard);
    memoryGame.PlayerBoard.SetValue(x, y, flippedCard);

}


