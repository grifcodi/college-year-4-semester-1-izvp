using Microsoft.Data.Sqlite;
using Practice13_14.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice13_14.Data
{
    internal class LessonRepository(string connectionString)
    {
        private readonly string _connectionString = connectionString;

        public List<Lesson> GetLessons()
        {
            var list = new List<Lesson>();
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "Select Id, LessonDate FROM Lessons;";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Lesson
                {
                    Id = reader.GetInt32(0),
                    LessonDate = DateTime.Parse(reader.GetString(1))
                });
            }

            return list;
        }

        public void Add(Lesson lesson)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = @"
                INSERT INTO Lessons (LessonDate)
                VALUES (@LessonDate);
            ";
            command.Parameters.AddWithValue("@LessonDate", lesson.LessonDate);

            command.ExecuteNonQuery();
        }
    }
}
