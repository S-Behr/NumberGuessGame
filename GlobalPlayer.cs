using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace AzubiDemo
{
    public static class GlobalPlayer
    {
        public static string Name { get; set; } = "";

        private static readonly string filePath = "player.json";
        private static List<string> knownPlayers = new();

        public static void Load()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                knownPlayers = JsonSerializer.Deserialize<List<string>>(json) ?? new();
            }
        }

        public static void SaveIfNew()
        {
            if (!knownPlayers.Contains(Name, StringComparer.OrdinalIgnoreCase))
            {
                knownPlayers.Add(Name);
                string json = JsonSerializer.Serialize(knownPlayers, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, json);
            }
        }

        public static bool IsKnown(string name)
        {
            return knownPlayers.Contains(name, StringComparer.OrdinalIgnoreCase);
        }
    }
}