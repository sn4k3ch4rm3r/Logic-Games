using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace LogicGames.Database
{
    static class DatabaseConfigManager
    {
        /// <summary>
        /// Create default database configuration and save it to config.json
        /// </summary>
        public static DatabaseConfig Create()
        {
            DatabaseConfig config = new DatabaseConfig();
            config.Database = "logicgames";
            config.Username = "root";
            config.Password = "";
            config.Address = "127.0.0.1";
            string json = JsonSerializer.Serialize(config);
            File.WriteAllText("config.json", json);
            return config;
        }

        /// <summary>
        /// Save the config generated from the given parameters.
        /// </summary>
        public static DatabaseConfig Save(string username, string password, string database, string address)
        {
            DatabaseConfig config = new DatabaseConfig();
            config.Username = username;
            config.Password = password;
            config.Database = database;
            config.Address = address;
            string json = JsonSerializer.Serialize(config);
            File.WriteAllText("config.json", json);
            GameClients.GameClient.dbHandler = new DatabaseHandler();
            return config;
        }

        /// <summary>
        /// Load database configuration from config.json
        /// </summary>
        public static DatabaseConfig Load()
        {
            string path = "config.json";
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                DatabaseConfig config = JsonSerializer.Deserialize<DatabaseConfig>(json);
                return config;
            }
            else throw new FileNotFoundException($"{path} not found");
        }

        /// <summary>
        /// Check if config.json exists
        /// </summary>
        /// <returns>
        /// true if it exists
        /// </returns>
        public static bool Exists()
        {
            return File.Exists("config.json");
        }
    }
}
