using Practice13_14.Data;
using Practice13_14.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice13_14.Services
{
    internal class LessonService(LessonRepository lessonRepository)
    {
        private readonly LessonRepository _lessonRepository = lessonRepository;

        public void GenerateAcademicYear(int startYear, DayOfWeek lessonDay)
        {
            DateTime startDate = new(startYear, 9, 1);
            DateTime endDate = new(startYear + 1, 6, 30);

            DateTime currentDate = startDate;
            while (currentDate.DayOfWeek != lessonDay)
            {
                currentDate = currentDate.AddDays(1);
            }

            while (currentDate <= endDate)
            {
                _lessonRepository.Add(new Lesson { LessonDate = currentDate });

                currentDate = currentDate.AddDays(7);
            }
        }
    }
}
