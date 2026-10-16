using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using _11_practice.Data;
using _11_practice.Models;

namespace _11_practice.Models
{
    public partial class MainForm : Form
    {
        private readonly StudentRepository _repository = new();
        private int _selectedStudentId = 0;

        public MainForm()
        {
            Text = "Student Journal System";
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var students = _repository.GetAll();
                dgvStudents.DataSource = new BindingList<Student>(students);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs()
        {
            if(string.IsNullOrWhiteSpace(textName.Text))
            {
                MessageBox.Show("Please enter student initials.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textCourse.Text))
            {
                MessageBox.Show("Please enter course.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textCourse.Focus();
                return false;
            }

            return true;
        }

        private void ClearInputs()
        {
            _selectedStudentId = 0;
            textName.Clear();
            numAge.Value = 18;
            textCourse.Clear();

            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            dgvStudents.ClearSelection();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            var student = new Student
            {
                Name = textName.Text.Trim(),
                Age = (int)numAge.Value,
                CourseName = textCourse.Text.Trim()
            };

            _repository.Add(student);
            ClearInputs();
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedStudentId == 0) return;

            var result = MessageBox.Show("Delete this student?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _repository.Delete(_selectedStudentId);
                ClearInputs();
                LoadData();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_selectedStudentId == 0 || !ValidateInputs()) return;

            var student = new Student
            {
                Id = _selectedStudentId,
                Name = textName.Text.Trim(),
                Age = (int)numAge.Value,
                CourseName = textCourse.Text.Trim()
            };

            _repository.Update(student);
            ClearInputs();
            LoadData();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }
        private void DgvStudents_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStudents.SelectedRows.Count == 0) return;

            if (dgvStudents.SelectedRows[0].DataBoundItem is not Student selectedStudent) return;

            _selectedStudentId = selectedStudent.Id;
            textName.Text = selectedStudent.Name;
            numAge.Value = selectedStudent.Age;
            textCourse.Text = selectedStudent.CourseName;

            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }
    }
}
