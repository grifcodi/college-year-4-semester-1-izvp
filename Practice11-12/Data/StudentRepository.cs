using Microsoft.Data.Sqlite;
using _11_practice.Models;


namespace _11_practice.Data
{
    internal class StudentRepository
    {
        private readonly string _connectionString = "Data Source=students.db";
        public StudentRepository()
        {
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Students (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Age INTEGER NOT NULL,
                    CourseName TEXT NOT NULL
                );";
            command.ExecuteNonQuery();
        }

        public List<Student> GetAll()
        {
            var list = new List<Student>();
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "SELECT Id, Name, Age, CourseName FROM Students;";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Student
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Age = reader.GetInt32(2),
                    CourseName = reader.GetString(3)
                });
            }

            return list;
        }

        public void Add(Student student)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
                INSERT INTO Students (Name, Age, CourseName)
                VALUES (@Name, @Age, @CourseName);";

            command.Parameters.AddWithValue("@Name", student.Name);
            command.Parameters.AddWithValue("@Age", student.Age);
            command.Parameters.AddWithValue("@CourseName", student.CourseName);

            command.ExecuteNonQuery();
        }

        public void Update(Student student)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"
                UPDATE Students 
                SET Name = @Name, Age = @Age, CourseName = @CourseName
                Where Id = @Id;";

            command.Parameters.AddWithValue("@Id", student.Id);
            command.Parameters.AddWithValue("@Name", student.Name);
            command.Parameters.AddWithValue("@Age", student.Age);
            command.Parameters.AddWithValue("@CourseName", student.CourseName);

            command.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Students WHERE Id = @Id;";
            command.Parameters.AddWithValue("@Id", id);

            command.ExecuteNonQuery();
        }
    }
}
