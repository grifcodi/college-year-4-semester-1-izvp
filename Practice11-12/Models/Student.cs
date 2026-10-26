using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace _11_practice.Models
{
    internal class Student : INotifyPropertyChanged
    {
        private int _id;
        private string _name = string.Empty;
        private int _age = 18;
        private string _courseName = string.Empty;
        public int Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {
                    _id = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                if(_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Age
        {
            get => _age;
            set
            {
                if (_age != value)
                {
                    _age = value;
                    OnPropertyChanged();
                }
            }
        }
        public string CourseName
        {
            get => _courseName;
            set
            {
                if (_courseName != value)
                {
                    _courseName = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
