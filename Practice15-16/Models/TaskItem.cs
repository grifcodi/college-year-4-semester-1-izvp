using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practice15.Models
{
    public partial class TaskItem : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(DisplayText))]
        private string _name = string.Empty;
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(DisplayText))]
        private bool _completed = false;

        public string DisplayText => $"{Name} - {(Completed ? "Completed" : "Not Completed")}";
    }
}
