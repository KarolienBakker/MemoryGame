using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryGame.Core
{
    public class Highscore
    {

        public string Name { get; }
        public int Score { get; }
        public int CardAmount { get; }
        public DateTime Date { get; }

        public Highscore(string name, int score, int cardAmount, DateTime date)
        {
            this.Name = name;
            this.Score = score;
            this.CardAmount = cardAmount;
            this.Date = date;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Name: ");
            sb.Append(this.Name);
            sb.Append(" Score: ");
            sb.Append(this.Score);
            sb.Append(" CardAmount: ");
            sb.Append(this.CardAmount);
            sb.Append(" Date: ");
            sb.Append(this.Date);
            return sb.ToString();
        }
    }
}
}
