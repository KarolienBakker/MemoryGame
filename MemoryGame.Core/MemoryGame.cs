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
        private int Attempts { get; set; }
        public List<List<int>> FlippedCards { get; set; }
        public int CreatedPairs { get; set; }
        public DateTime startTime;
        public string Name { get; set; }


        public MemoryGame(int amountOfCards, List<T> cards, string name)
        { 
            this.GameBoard = new Board<T>(amountOfCards);
            this.PlayerBoard = new Board<T>(amountOfCards);
            this.Cards = cards;
            this.GameRunning = true;
            this.Attempts = 0;
            this.FlippedCards = new List<List<int>>();
            this.CreatedPairs = 0;
            this.startTime = DateTime.Now;
            this.Name = name;
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
        
        public bool CheckMatch(int x1, int y1, int x2, int y2)
        {
            T card1 = this.GameBoard.GetValue(x1, y1);
            T card2 = this.GameBoard.GetValue(x2, y2);
            if (card1.Equals(card2))
            {
                return true;
            }
            return false;
        }

        public void PlayRound(int x, int y)
        {
            FlipCard(x, y);
            EndRound();
            this.FlippedCards.Add(new List<int> { x, y });
            CheckPair();
            CheckWin();
        }

        public void FlipCard(int x, int y)
        {
            this.PlayerBoard.SetValue(x, y, this.GameBoard.GetValue(x, y));
        }
        
        public bool CoordsExist(int x, int y)
        {
            return x <= this.PlayerBoard.Length && y <= this.PlayerBoard.Width;
        }

        public void EndRound()
        {
            // check if 2 cards are flipped
            if(FlippedCards.Count >= 2)
            {
                // check if the 2 cards are not a match, if they are not flip them back
                if(!CheckMatch(FlippedCards[0][0], FlippedCards[0][1], FlippedCards[1][0], FlippedCards[1][1]))
                {
                   foreach (var coord in FlippedCards)
                   {
                        this.PlayerBoard.SetValue(coord[0], coord[1], default);
                   }
                }
                FlippedCards.Clear();
            }
            
        }

        public void CheckPair()
        {
            if(FlippedCards.Count >= 2)
            {
                this.Attempts++;
                if (CheckMatch(FlippedCards[0][0], FlippedCards[0][1], FlippedCards[1][0], FlippedCards[1][1]))
                {
                    CreatedPairs++;
                }
            }
        }

        public void CheckWin()
        {
            if(CreatedPairs == (this.GameBoard.Length * this.GameBoard.Width / 2))
            {
                this.GameRunning = false;
                Highscores.GetInstance().AddHighscore(this.Name, this.GameBoard.Length * this.GameBoard.Width / 2, (int)(DateTime.Now - startTime).TotalSeconds, this.Attempts);
            }
        }

        public bool CheckIfCardFlipped(int x, int y)
        {
            if (!this.PlayerBoard.GetValue(x, y).Equals(PlayerBoard.defaultValue))
            {
                return true;
            }
            return false;
        }
    }
}
