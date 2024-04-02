
public enum Priority
{
    High,
    Medium,
    Low
}

public class TaskItem
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public Priority Priority { get; set; }
    public bool Completed { get; set; }

    public TaskItem(string title, string description, DateTime dueDate, Priority priority)
    {
        Title = title;
        Description = description;
        DueDate = dueDate;
        Priority = priority;
        Completed = false;
    }
}
