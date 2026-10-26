using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice13_14.Data
{

    internal class DatabaseRepository
    {
        public string ConnectionString { get; }
        public DatabaseRepository()
        {
            var builder = new SqliteConnectionStringBuilder
            {
                DataSource = "students.db",
                ForeignKeys = true
            };

            ConnectionString = builder.ConnectionString;

            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using var connection = new SqliteConnection(ConnectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Students (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL
                );

                CREATE TABLE IF NOT EXISTS Lessons (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    LessonDate TEXT NOT NULL
                );

                CREATE TABLE IF NOT EXISTS AttendanceRecords (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    StudentId INTEGER NOT NULL,
                    LessonId INTEGER NOT NULL,
                    IsPresent INTEGER NOT NULL CHECK (IsPresent IN (0, 1)),
                    Score REAL NOT NULL DEFAULT 0.0,
                    Comment TEXT DEFAULT '',
                    FOREIGN KEY (StudentId) REFERENCES Students(Id) ON DELETE CASCADE,
                    FOREIGN KEY (LessonId) REFERENCES Lessons(Id) ON DELETE CASCADE,
                    CONSTRAINT UQ_Student_Lesson UNIQUE (StudentId, LessonId)
                );
                ";

            command.ExecuteNonQuery();
        }
    }
}
