using Practice13_14.Data;
using Practice13_14.Models;
using Practice13_14.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Practice13_14.Forms
{
    public partial class MainForm : Form
    {
        private readonly StudentRepository studentRepository;
        private readonly LessonRepository lessonRepository;
        private readonly AttendanceRepository attendanceRepository;
        private readonly LessonService lessonService;

        public MainForm()
        {
            InitializeComponent();

            var databaseRepository = new DatabaseRepository();

            studentRepository = new(databaseRepository.ConnectionString);
            lessonRepository = new(databaseRepository.ConnectionString);
            attendanceRepository = new(databaseRepository.ConnectionString);
            lessonService = new(lessonRepository);

            LoadDataStudents();
            LoadDataLessons();
            LoadDataDays();
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(textName.Text))
            {
                MessageBox.Show("Please enter student initials.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textName.Focus();
                return false;
            }
            return true;
        }

        private void LoadDataStudents()
        {
            var students = studentRepository.GetStudents();

            cmbStudents.DataSource = null;
            cmbStudents.DataSource = students;
            cmbStudents.DisplayMember = "Name";
            cmbStudents.ValueMember = "Id";

            textName.Clear();
        }

        private void LoadDataLessons()
        {
            var lessons = lessonRepository.GetLessons();

            cmbLessons.DataSource = null;
            cmbLessons.DataSource = lessons;
            cmbLessons.DisplayMember = "LessonDate";
            cmbLessons.ValueMember = "Id";
        }

        private void LoadDataDays()
        {
            var daysUa = new Dictionary<DayOfWeek, string>
            {
                { DayOfWeek.Monday, "Понеділок" },
                { DayOfWeek.Tuesday, "Вівторок" },
                { DayOfWeek.Wednesday, "Середа" },
                { DayOfWeek.Thursday, "Четвер" },
                { DayOfWeek.Friday, "П'ятниця" },
                { DayOfWeek.Saturday, "Субота" },
                { DayOfWeek.Sunday, "Неділя" }
            };

            cmbDays.DataSource = new BindingSource(daysUa, "");
            cmbDays.DisplayMember = "Value";
            cmbDays.ValueMember = "Key";
        }

        private void LoadDataAttendanceRecord()
        {
            if (cmbStudents.SelectedItem is Student selectedStudent && cmbLessons.SelectedItem is Lesson selectedLesson)
            {
                var record = attendanceRepository.GetAttendanceRecord(selectedStudent.Id, selectedLesson.Id);

                if (record != null)
                {
                    radioBtnAttendance.Checked = record.IsPresent;
                    numMark.Value = record.Score;
                    textComment.Text = record.Comment;
                }
                else
                {
                    radioBtnAttendance.Checked = false;
                    numMark.Value = 0;
                    textComment.Clear();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            var student = new Student
            {
                Name = textName.Text.Trim(),
            };

            studentRepository.Add(student);
            LoadDataStudents();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cmbStudents.SelectedItem is not Student selectedStudent)
            {
                MessageBox.Show("Please select a student from the drop-down list to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidateInputs()) return;

            string newName = textName.Text.Trim();

            var confirm = MessageBox.Show($"Are you sure you want to rename {selectedStudent.Name} to {newName}?", "Confirm Rename", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.No) return;

            selectedStudent.Name = newName;

            studentRepository.Update(selectedStudent);
            LoadDataStudents();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cmbStudents.SelectedItem is not Student selectedStudent)
            {
                MessageBox.Show("Please select a student from the drop-down list to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"Are you sure you want to delete {selectedStudent.Name}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.No) return;

            studentRepository.Delete(selectedStudent);
            LoadDataStudents();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (cmbDays.SelectedValue is DayOfWeek selectedDay)
            {
                lessonService.GenerateAcademicYear(2025, selectedDay);
                LoadDataLessons();
                MessageBox.Show("Academic year lessons generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbStudents.SelectedItem is not Student selectedStudent || cmbLessons.SelectedItem is not Lesson selectedLesson)
            {
                MessageBox.Show("Please select both a student and a lesson date.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var record = new AttendanceRecord
            {
                StudentId = selectedStudent.Id,
                LessonId = selectedLesson.Id,
                IsPresent = radioBtnAttendance.Checked,
                Score = numMark.Value,
                Comment = textComment.Text.Trim()
            };

            attendanceRepository.Add(record);

            MessageBox.Show($"Attendance saved for {selectedStudent.Name}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmbStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStudents.SelectedItem is Student selectedStudent)
            {
                textName.Text = selectedStudent.Name;
            }

            LoadDataAttendanceRecord();
        }

        private void cmbLessons_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataAttendanceRecord();
        }
    }
}
