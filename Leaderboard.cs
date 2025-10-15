using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Linq;

namespace AzubiDemo
{
    public class ScoreEntry
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public string Difficulty { get; set; }
    }

    public static class Leaderboard
    {
        private static readonly string filePath = "leaderboard.json";
        private static List<ScoreEntry> scores = new();

        static Leaderboard()
        {
            Load();
        }
        
        public static void Add(string name, int score, string difficulty = "")
        {
            var existing = scores.FirstOrDefault(s =>
                s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            if (existing != null)
            {

                existing.Score += score;
                
                existing.Difficulty = difficulty;
            }
            else
            {

                scores.Add(new ScoreEntry
                {
                    Name = name,
                    Score = score,
                    Difficulty = difficulty
                });
            }
            
            scores = scores
                .OrderByDescending(s => s.Score)
                .Take(10)
                .ToList();

            Save();
        }

        public static int GetScoreForPlayer(string name)
        {
            var entry = scores.FirstOrDefault(s =>
                s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));

            return entry?.Score ?? 0;
        }

        public static void Show()
        {
            Console.WriteLine("\n=== Leaderboard ===");

            if (scores.Count == 0)
            {
                Console.WriteLine("No entries yet!");
                return;
            }

            int rank = 1;
            foreach (var entry in scores)
            {
                string diff = string.IsNullOrEmpty(entry.Difficulty)
                    ? ""
                    : $" ({entry.Difficulty})";

                Console.WriteLine($"{rank}. {entry.Name} - {entry.Score} Points{diff}");
                rank++;
            }

            Console.WriteLine("====================\n");
        }

        private static void Save()
        {
            string json = JsonSerializer.Serialize(scores, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            File.WriteAllText(filePath, json);
        }

        public static void Load()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                scores = JsonSerializer.Deserialize<List<ScoreEntry>>(json) ?? new();
            }
        }
    }
}
