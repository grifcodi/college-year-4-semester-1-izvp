using Avalonia;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Practice15.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Practice15.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _taskText = string.Empty;

    [ObservableProperty]
    private TaskItem? _selectedTask;

    [ObservableProperty]
    private int _completedTasks;

    public ObservableCollection<TaskItem> Tasks { get; } = [];

    private void UpdateCompletedCount()
    {
        CompletedTasks = Tasks.Count(t => t.Completed);
    }

    [RelayCommand]
    private void AddTask()
    {
        if (string.IsNullOrWhiteSpace(TaskText)) 
            return;

        var newTask = new TaskItem { Name = TaskText.Trim(), Completed = false };

        newTask.PropertyChanged += Task_PropertyChanged;

        Tasks.Add(newTask);
        TaskText = string.Empty;

        UpdateCompletedCount();
    }

    [RelayCommand]
    private void ToggleTask(TaskItem? task)
    {
        task?.Completed = !task.Completed;
    }

    [RelayCommand]
    private void DeleteTask(TaskItem? task)
    {
        if (task is not null)
        {
            task.PropertyChanged -= Task_PropertyChanged;
            Tasks.Remove(task);

            UpdateCompletedCount();
        }
    }

    private void Task_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(TaskItem.Completed))
        {
            UpdateCompletedCount();
        }
    }
}
