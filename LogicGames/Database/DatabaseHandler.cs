using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace LogicGames.Database
{
    static class DatabaseHandler
    {
        public static DatabaseConfig Config { get; set; }
        private static MySqlConnection conn;
        private static bool connectionValid = false;

        public static void Setup()
        {
            if (Config == null)
            {
                if (DatabaseConfigManager.Exists()) Config = DatabaseConfigManager.Load();
                else Config = DatabaseConfigManager.Create();
            }
            MySqlConnection conn = new MySqlConnection($"server='{Config.Address}';user='{Config.Username}';password='{Config.Password}'");
            conn.Open();

            MySqlCommand createDB = new MySqlCommand
            (
                $"CREATE DATABASE IF NOT EXISTS {Config.Database};" +
                $"USE {Config.Database};" +
                $"CREATE TABLE IF NOT EXISTS tetris (id int PRIMARY KEY AUTO_INCREMENT, score int, cleared int, o int, i int, l int, j int, t int, s int, z int, time int);" +
                $"CREATE TABLE IF NOT EXISTS minesweeper (id int PRIMARY KEY AUTO_INCREMENT, time int, flags int, checked int, mine boolean);" +
                $"CREATE TABLE IF NOT EXISTS game2048 (id int PRIMARY KEY AUTO_INCREMENT, score int, tile2 int, tile4 int, tile8 int, tile16 int, tile32 int, tile64 int, tile128 int, tile256 int, tile512 int, tile1024 int, tile2048 int, tileMore int, time int);",
                conn
            );
            
            createDB.ExecuteNonQuery();
            conn.Close();
            connectionValid = true;
        }

        /// <summary>
        /// Open the MySqlConnection
        /// </summary>
        public static void Open()
        {
            if (!connectionValid) return;
            try
            {
                conn = new MySqlConnection($"server='{Config.Address}';user='{Config.Username}';password='{Config.Password}';database='{Config.Database}'");
                conn.Open();
            }
            catch
            {
                connectionValid = false;
            }
        }

        /// <summary>
        /// Close the MySqlConnection
        /// </summary>
        public static void Close()
        {
            conn.Close();
        }

        /// <summary>
        /// Runs the SQL query
        /// </summary>
        /// <param name="query">
        /// SQL
        /// </param>
        /// <returns>
        /// All the records in a dictionary list
        /// </returns>
        public static List<Dictionary<string, object>> ExecuteRequest(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, conn);

            MySqlDataReader reader = cmd.ExecuteReader();

            List<Dictionary<string, object>> result = new List<Dictionary<string, object>>();
            while (reader.Read())
            {
                Dictionary<string, object> dict = new Dictionary<string, object>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    dict.Add(reader.GetName(i), reader.GetValue(i));
                }
                result.Add(dict);
            }
            return result;
        }

        /// <summary>
        /// Runs the SQL command
        /// </summary>
        /// <param name="command">
        /// SQL
        /// </param>
        /// <returns>
        /// The number of rows affected.
        /// </returns>
        public static int ExecuteCommand(string command)
        {
            MySqlCommand cmd = new MySqlCommand(command, conn);
            return cmd.ExecuteNonQuery();
        }
    }
}
