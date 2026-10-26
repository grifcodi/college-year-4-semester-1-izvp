using System;
using System.ComponentModel;
using System.Windows.Forms;
using _11_practice.Data;
using _11_practice.Models;

namespace _11_practice.Models
{
    public partial class MainForm : Form
    {
        private readonly StudentRepository _repository = new();
        private readonly BindingSource _bindingSource = [];
        private BindingList<Student> _studentsList = [];

        public MainForm()
        {
            Text = "Student Journal System";
            InitializeComponent();
            SetupBindings();
            LoadData();
        }

        private void SetupBindings()
        {
            textName.DataBindings.Add("Text", _bindingSource, nameof(Student.Name), true, DataSourceUpdateMode.OnPropertyChanged);
            numAge.DataBindings.Add("Value", _bindingSource, nameof(Student.Age), true, DataSourceUpdateMode.OnPropertyChanged);
            textCourse.DataBindings.Add("Text", _bindingSource, nameof(Student.CourseName), true, DataSourceUpdateMode.OnPropertyChanged);

            dgvStudents.DataSource = _bindingSource;

            _bindingSource.CurrentChanged += BindingSource_CurrentChanged;
        }

        private void LoadData()
        {
            try
            {
                var students = _repository.GetAll();
                _studentsList = new BindingList<Student>(students);
                _bindingSource.DataSource = _studentsList;
                UpdateState();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка завантаження даних: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindingSource_CurrentChanged(object? sender, EventArgs e)
        {
            UpdateState();
        }

        private void UpdateState()
        {
            bool hasSelection = _bindingSource.Current is Student;
            btnUpdate.Enabled = hasSelection;
            btnDelete.Enabled = hasSelection;
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(textName.Text))
            {
                MessageBox.Show("Будь ласка, введіть ПІБ студента.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(textCourse.Text))
            {
                MessageBox.Show("Будь ласка, введіть назву курсу.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textCourse.Focus();
                return false;
            }

            return true;
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
            _studentsList.Add(student);
            _bindingSource.MoveLast();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current is not Student currentStudent || !ValidateInputs()) return;

            _repository.Update(currentStudent);
            _bindingSource.ResetCurrentItem();
            MessageBox.Show("Дані студента успішно оновлено!", "Інформація", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current is not Student currentStudent) return;

            var result = MessageBox.Show($"Видалити студента '{currentStudent.Name}'?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                _repository.Delete(currentStudent.Id);
                _bindingSource.RemoveCurrent();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _bindingSource.AddNew();
            numAge.Value = 18;
        }
    }
}