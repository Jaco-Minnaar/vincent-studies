namespace TodoApp;

public class Todo(int id, int priority, string text, bool isDone)
{
    public int Id { get; set; } = id;
    public int Priority { get; set; } = priority;
    public string Text { get; set; } = text;
    public bool IsDone { get; set; } = isDone;
}

