using ConsoleApp_Flashcards.models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Flashcards
{
    internal static class DbOperations
    {
        static string connectionString = "Data Source=flashcards.db";
        internal static void CreateStacksTable()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    CREATE TABLE IF NOT EXISTS stacks
                    (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                    name TEXT NOT NULL,
                    number_studied INTEGER);
                ";
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        internal static void CreateCardsTable()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandText =
                @"
                    CREATE TABLE IF NOT EXISTS cards
                    (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                    card_front TEXT NOT NULL,
                    card_back TEXT NOT NULL,
                    number_seen INTEGER,
                    number_correct INTEGER,
                    stack INTEGER NOT NULL);
                ";
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        internal static void CreateTables()
        {
            CreateStacksTable();
            CreateCardsTable();
        }

        internal static void AddStack(string name)
        {
            using(var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "INSERT INTO stacks (name) VALUES (@name)";
                command.Parameters.AddWithValue("@name", name);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        internal static void ListStacks()
        {
            using(var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = "SELECT * from stacks";
                Console.WriteLine($"ID\tName\n\n");
                using (var reader  = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string Id = reader.GetString(reader.GetOrdinal("id"));
                        string name = reader.GetString(reader.GetOrdinal("name"));
                        Console.WriteLine($"{Id}\t{name}\n");
                    }
                }
            }
           
        }

    }
}
