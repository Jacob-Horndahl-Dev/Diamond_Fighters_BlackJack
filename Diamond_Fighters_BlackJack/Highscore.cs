using System.Text.Json;

namespace Diamond_Fighters_BlackJack
{
    public class Highscore
    {
        public string Name { get; set; }
        public int FinalBalance { get; set; }
        public int RoundsPlayed { get; set; }
    }

    public class HighscoreList
    {
        private List<Highscore> entries = new List<Highscore>();
        private string filePath = "highscores.json";

        public void Load()
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    entries = new List<Highscore>();
                    return;
                }

                string json = File.ReadAllText(filePath);
                entries = JsonSerializer.Deserialize<List<Highscore>>(json);

                if (entries == null)
                    entries = new List<Highscore>();
            }
            catch
            {
                entries = new List<Highscore>();
            }
        }

        public void Add(string name, int finalBalance, int roundsPlayed)
        {
            Highscore entry = new Highscore();
            entry.Name = name;
            entry.FinalBalance = finalBalance;
            entry.RoundsPlayed = roundsPlayed;

            entries.Add(entry);
            Save();
        }

        public void Save()
        {
            string json = JsonSerializer.Serialize(entries);
            File.WriteAllText(filePath, json);
        }

        public void Show()
        {
            for (int i = 0; i < entries.Count; i++)
            {
                for (int j = i + 1; j < entries.Count; j++)
                {
                    if (entries[j].FinalBalance > entries[i].FinalBalance)
                    {
                        Highscore temp = entries[i];
                        entries[i] = entries[j];
                        entries[j] = temp;
                    }
                }
            }

            Console.WriteLine("Topplista");

            if (entries.Count == 0)
            {
                Console.WriteLine("Topplistan är tom.");
                return;
            }

            int count = entries.Count;
            if (count > 5)
                count = 5;

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(
                    (i + 1) + ". " + entries[i].Name +
                    "   " + entries[i].FinalBalance + " kr" +
                    "   (" + entries[i].RoundsPlayed + " rundor)");
            }
        }
    }
}