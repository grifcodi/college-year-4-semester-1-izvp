namespace Practice14.Models
{
    internal class TaskItem
    {
        public string Name { get; init; } = string.Empty;
        public bool Completed { get; set; } = false;

        public string DisplayText => $"{Name} - {(Completed ? "Виконано" : "Не виконано")}";

        public override string ToString()
        {
            return DisplayText;
        }
    }
}
