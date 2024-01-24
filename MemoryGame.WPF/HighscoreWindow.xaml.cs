using MemoryGame.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MemoryGame.WPF
{
    /// <summary>
    /// Interaction logic for HighscoreWindow.xaml
    /// </summary>
    public partial class HighscoreWindow : Window
    {
        private object JsonConvert;

        public HighscoreWindow() { 
          
            LoadData();
           
        }
        private void LoadData()
        {
            List<Highscore> scores = Highscores.GetInstance().Scores;

            foreach (var score in scores)
            {
                if (score != null)
                {
                    // Add the score to the DataGrid's Items collection
                    scoreGrid.Items.Add(score);
                }
            }
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
            // Close the HighscoreWindow
            Close();
        }





    }
}
