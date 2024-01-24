using System.Windows;

namespace MemoryGame.WPF
{
    public partial class MainWindow : Window
    {
        private HighscoreWindow highscoreWindow = new HighscoreWindow();

        public MainWindow()
        {
            InitializeComponent();
            InitScreen();
        }

        private void InitScreen()
        {
            // Attach the click event handler for the "See Highscores" button
            highscoresButton.Click += (sender, e) => ShowHighscoreWindow();
            
            
        }


        private void SeeHighscores(object sender, RoutedEventArgs e)
        {
            // Call the method to show the HighscoreWindow
            ShowHighscoreWindow();
        }

        private void ShowHighscoreWindow()
        {
            Close();
            // Show the HighscoreWindow
            highscoreWindow.ShowDialog(); // Use ShowDialog to make it a modal window
        }
        private void CloseHighscoreWidow()
        {
            Close();


        }
    }
}