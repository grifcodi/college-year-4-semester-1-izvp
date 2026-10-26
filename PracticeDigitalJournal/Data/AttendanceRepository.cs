using Microsoft.Data.Sqlite;
using Practice13_14.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice13_14.Data
{
    internal class AttendanceRepository(string connectionString)
    {
        private readonly string _connectionString = connectionString;

        public AttendanceRecord? GetAttendanceRecord(int studentId, int lessonId)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = @"
                SELECT Id, StudentId, LessonId, IsPresent, Score, Comment 
                FROM AttendanceRecords
                WHERE StudentId = @StudentId AND LessonId = @LessonId;
            ";

            command.Parameters.AddWithValue("@StudentId", studentId);
            command.Parameters.AddWithValue("@LessonId", lessonId);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new AttendanceRecord
                {
                    Id = reader.GetInt32(0),
                    StudentId = reader.GetInt32(1),
                    LessonId = reader.GetInt32(2),
                    IsPresent = reader.GetBoolean(3),
                    Score = reader.GetDecimal(4),
                    Comment = reader.IsDBNull(5) ? string.Empty : reader.GetString(5)
                };
            }

            return null;
        }

        public void Add(AttendanceRecord attendanceRecord)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var command = connection.CreateCommand();

            command.CommandText = @"
                INSERT INTO AttendanceRecords (StudentId, LessonId, IsPresent, Score, Comment)
                Values (@StudentId, @LessonId, @IsPresent, @Score, @Comment)
                ON CONFLICT(StudentId, LessonId) DO UPDATE SET
                    IsPresent = excluded.IsPresent,
                    Score = excluded.Score,
                    Comment = excluded.Comment;
            ";

            command.Parameters.AddWithValue("@StudentId", attendanceRecord.StudentId);
            command.Parameters.AddWithValue("@LessonId", attendanceRecord.LessonId);
            command.Parameters.AddWithValue("@IsPresent", attendanceRecord.IsPresent);
            command.Parameters.AddWithValue("@Score", attendanceRecord.Score);
            command.Parameters.AddWithValue("@Comment", attendanceRecord.Comment);

            command.ExecuteNonQuery();
        }
    }
}
