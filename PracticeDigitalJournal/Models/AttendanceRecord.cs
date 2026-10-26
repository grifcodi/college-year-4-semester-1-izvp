using System;
using System.Collections.Generic;
using System.Text;

namespace Practice13_14.Models
{
    internal class AttendanceRecord
    {
        private decimal _score;
        private string _comment = string.Empty;

        public int Id { get; init; }
        public int StudentId { get; init; }
        public int LessonId { get; init; }
        public bool IsPresent { get; set; }
        public decimal Score {
            get => _score;
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException(nameof(value), "Score must be between 0 and 100.");
                _score = value;
            }
        }
        public string Comment { 
            get => _comment; 
            set => _comment = value?.Trim() ?? string.Empty;
        }
    }
}