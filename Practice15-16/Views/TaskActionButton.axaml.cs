using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Windows.Input;

namespace Practice15.Views
{
    public partial class TaskActionButton : UserControl
    {
        public static readonly StyledProperty<string> ButtonTextProperty =
            AvaloniaProperty.Register<TaskActionButton, string>(nameof(ButtonText));

        public static readonly StyledProperty<ICommand> ActionCommandProperty =
            AvaloniaProperty.Register<TaskActionButton, ICommand>(nameof(ActionCommand));

        public static readonly StyledProperty<object?> ActionParameterProperty =
            AvaloniaProperty.Register<TaskActionButton, object?>(nameof(ActionParameter));

        public string ButtonText
        {
            get => GetValue(ButtonTextProperty);
            set => SetValue(ButtonTextProperty, value);
        }

        public ICommand ActionCommand
        {
            get => GetValue(ActionCommandProperty);
            set => SetValue(ActionCommandProperty, value);
        }

        public object? ActionParameter
        {
            get => GetValue(ActionParameterProperty);
            set => SetValue(ActionParameterProperty, value);
        }

        public TaskActionButton()
        {
            InitializeComponent();
        }
    }
}