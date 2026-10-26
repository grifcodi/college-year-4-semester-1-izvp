
using Practice14.Models;

namespace Practice14.Controllers
{
    internal class TaskController
    {
        private readonly List<TaskItem> _tasks = [];

        public IReadOnlyList<TaskItem> GetTasks()
        {
            return _tasks.AsReadOnly();
        }

        public void AddTask(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Назва завдання не може бути порожньою.");
            }

            _tasks.Add(new TaskItem { Name = name.Trim() });
        }

        public void SetTaskCompleted(TaskItem taskItem, bool completed)
        {
            ArgumentNullException.ThrowIfNull(taskItem);

            if (!_tasks.Contains(taskItem))
            {
                throw new ArgumentException("Завдання не знайдено у списку.", nameof(taskItem));
            }

            taskItem.Completed = completed;
        }

        public void DeleteTask(TaskItem taskItem)
        {
            ArgumentNullException.ThrowIfNull(taskItem);

            if (!_tasks.Remove(taskItem))
            {
                throw new ArgumentException("Завдання не знайдено у списку.", nameof(taskItem));
            }
        }
    }
}
