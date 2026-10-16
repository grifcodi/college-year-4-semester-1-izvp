using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sqlite;
using Practice13_14.Models;

namespace Practice13_14.Data
{
    internal class StudentRepository(string connectionString)
    {
        private readonly string _connectionString = connectionString;

        public List<Student> GetStudents()
        {
            var list = new List<Student>();
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "SELECT Id, Name FROM Students;";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Student
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1)
                });
            }

            return list;
        }

        public void Add(Student student)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = @"
                INSERT INTO Students (Name)
                VALUES (@Name);
            ";
            command.Parameters.AddWithValue("@Name", student.Name);

            command.ExecuteNonQuery();
        }

        public void Update(Student student)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = @"
                UPDATE Students
                SET Name = @Name
                Where Id = @Id;
            ";
            command.Parameters.AddWithValue("@Id", student.Id);
            command.Parameters.AddWithValue("@Name", student.Name);

            command.ExecuteNonQuery();
        }

        public void Delete(Student student)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Students WHERE Id = @Id;";
            command.Parameters.AddWithValue("@Id", student.Id);

            command.ExecuteNonQuery();
        }
    }
}
