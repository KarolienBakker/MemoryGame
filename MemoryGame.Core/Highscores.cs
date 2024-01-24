using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MemoryGame.Core
{
    public class Highscores
    {
        private static Highscores instance;
        private string JsonPath = "C:\\Users\\ruben\\source\\repos\\HighscoreTracker\\HighscoreTracker\\Highscores.json";
        private List<Highscore> Scores { get; }

        private Highscores()
        {
            this.Scores = new List<Highscore>();
            LoadHighscores();
        }

        public static Highscores GetInstance()
        {
            if (instance == null)
            {
                instance = new Highscores();
            }
            return instance;
        }

        public int CalculateScore(int amountOfCards, int timeInSeconds, int attempts)
        {
            return (amountOfCards * 2 / (timeInSeconds * attempts)) * 1000;
        }

        private void LoadHighscores()
        {
            try
            {
                if (File.Exists(JsonPath))
                {
                    string jsonData = File.ReadAllText(JsonPath);
                    List<Highscore> highscores = JsonSerializer.Deserialize<List<Highscore>>(jsonData);

                    foreach (var highscore in highscores)
                    {
                        Scores.Add(highscore);
                    }
                }
                else
                {
                    Console.WriteLine("JSON file not found.");
                }
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error deserializing JSON: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error reading the file: {ex.Message}");
            }
        }

        public void AddHighscore(string name, int amountOfCards, int timeInSeconds, int attempts)
        {
            Highscore highscore = new Highscore(name, CalculateScore(amountOfCards, timeInSeconds, attempts), amountOfCards, DateTime.Now);
            this.Scores.Add(highscore);
        }

        public void WriteHighscores()
        {
            try
            {

                string jsonData = JsonSerializer.Serialize(this.Scores);
                File.WriteAllText(JsonPath, jsonData);
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error serializing JSON: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error writing the file: {ex.Message}");
            }
        }
    }
}
}
