using System;
/// Priority Values
public enum Priority
{
    /// High priority
    High,
    /// Medium priority
    Medium,
    /// Low priority
    Low
}

/// Task Item Model
public class TaskItem
{
    /// Task Title
    public string Title { get; set; }
    /// Task Description
    public string Description { get; set; }
    /// Task Due Date
    public DateTime DueDate { get; set; }
    /// Task Priority
    public Priority Priority { get; set; }
    /// Task Completion Status
    public bool Completed { get; set; }

    /// Task Item Constructor
    public TaskItem(string title, string description, DateTime dueDate, Priority priority)
    {
        Title = title;
        Description = description;
        DueDate = dueDate;
        Priority = priority;
        Completed = false;
    }
}
