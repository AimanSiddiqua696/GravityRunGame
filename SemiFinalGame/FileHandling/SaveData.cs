using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemiFinalGame.FileHandling
{
    internal class SaveData
    {
        // This file will be created in the same folder as your game .exe
        private static string filePath = "stats.txt";

        // --- SAVE METHOD (APPEND MODE) ---
        public static void SaveStats(int level, int score, int coins, int lives)
        {
            // Format: Level, Score, Coins, Lives
            // Environment.NewLine adds a "Enter" to go to the next line
            string data = $"Level: {level}, Score: {score}, Coins: {coins}, Lives: {lives}" + Environment.NewLine;

            // Write to file (Append Mode adds to the end instead of replacing)
            File.AppendAllText(filePath, data);
        }

        // --- LOAD HISTORY METHOD ---
        // Returns a list of all game records
        public static List<string> LoadHistory()
        {
            List<string> history = new List<string>();

            if (File.Exists(filePath))
            {
                // Read all lines
                string[] lines = File.ReadAllLines(filePath);
                history.AddRange(lines);
            }
            return history;
        }
    }
}
