
using Practice14.Controllers;
using Practice14.Models;

namespace Practice14.Views
{
    public partial class MainForm : Form
    {
        private readonly TaskController _taskController = new();

        public MainForm()
        {
            InitializeComponent();
            RefreshTaskList();
        }

        private void RefreshTaskList()
        {
            ListTasks.ItemCheck -= ListTasks_ItemCheck;

            ListTasks.Items.Clear();

            foreach (TaskItem task in _taskController.GetTasks())
            {
                int index = ListTasks.Items.Add(task);
                ListTasks.SetItemChecked(index, task.Completed);
            }

            ListTasks.DisplayMember = nameof(TaskItem.DisplayText);

            ListTasks.ItemCheck += ListTasks_ItemCheck;
        }

        private void ListTasks_ItemCheck(object? sender, ItemCheckEventArgs e)
        {
            if (ListTasks.Items[e.Index] is TaskItem selectedTask)
            {
                bool completed = e.NewValue == CheckState.Checked;

                _taskController.SetTaskCompleted(selectedTask, completed);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                _taskController.AddTask(TxtName.Text);
                TxtName.Clear();
                RefreshTaskList();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Помилка введення",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (ListTasks.SelectedItem is not TaskItem selectedTask)
            {
                MessageBox.Show(
                    "Оберіть завдання для видалення.",
                    "Увага",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            _taskController.DeleteTask(selectedTask);
            RefreshTaskList();
        }
    }
}
