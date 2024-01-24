using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame.Core
{
    public class MemoryGame<T>
    {
        public Board<T> GameBoard { get; }
        public Board<T> PlayerBoard { get; }
        private List<T> Cards;
        public bool GameRunning {  get; set; }
        public MemoryGame(int amountOfCards, List<T> cards)
        { 
            this.GameBoard = new Board<T>(amountOfCards);
            this.PlayerBoard = new Board<T>(amountOfCards);
            this.Cards = cards;
            this.GameRunning = true;
            FillGameBoard();
        }
        

        private void FillGameBoard()
        {
            // shuffle the cards
            Random random = new Random();
            this.Cards = this.Cards.OrderBy(c => random.Next()).ToList();
            int counter = 0;
            for (int i = 0; i < GameBoard.Length; i++)
            {
                for (int j = 0; j < GameBoard.Width; j++)
                {
                    this.GameBoard.SetValue(i, j, this.Cards[counter]);
                    counter++;
                }
            }
        }
        


    }
}
