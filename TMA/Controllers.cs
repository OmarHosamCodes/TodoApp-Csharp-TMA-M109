#pragma warning disable CS8602 // Dereference of a possibly null reference.
using ConsoleTables;

public static class TodoController
{
    private static List<TaskItem> tasks = new List<TaskItem>();

    public static void AddTask(string title, string description, DateTime dueDate, Priority priority)
    {
        tasks.Add(new TaskItem(title, description, dueDate, priority));
        Console.WriteLine("Task added successfully.");
    }


    public static void ListTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks found.");
            return;
        }

        var table = new ConsoleTable("ID", "Title", "Description", "Due Date", "Priority", "Completed");
        foreach (var task in tasks.OrderBy(t => t.Priority))
        {
            table.AddRow(tasks.IndexOf(task), task.Title, task.Description, task.DueDate.ToString("yyyy-MM-dd"), task.Priority, task.Completed ? "Yes" : "No");
        }

        Console.WriteLine(table.ToString());
    }

    public static void EditTask(int id, string title, string description, DateTime dueDate, Priority priority)
    {
        if (id < 0 || id >= tasks.Count)
        {
            Console.WriteLine("Invalid task ID.");
            return;
        }
        TaskItem task = tasks[id];
        Console.WriteLine($"Editing task: {task.Title}");
        task.Title = title;
        task.Description = description;
        task.DueDate = dueDate;
        task.Priority = priority;
        Console.WriteLine("Task edited successfully.");
    }

    public static void CompleteTask(int id)
    {
        if (id < 0 || id >= tasks.Count)
        {
            Console.WriteLine("Invalid task ID.");
            return;
        }
        tasks[id].Completed = true;
        Console.WriteLine("Task marked as completed.");
    }

    public static void DeleteTask(int id)
    {
        if (id < 0 || id >= tasks.Count)
        {
            Console.WriteLine("Invalid task ID.");
            return;
        }
        tasks.RemoveAt(id);
        Console.WriteLine("Task deleted successfully.");
    }

    public static void SetPriority(int id, Priority priority)
    {
        if (id < 0 || id >= tasks.Count)
        {
            Console.WriteLine("Invalid task ID.");
            return;
        }
        tasks[id].Priority = priority;
        Console.WriteLine("Priority set successfully.");
    }

    public static void DisplayMenu()
    {
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Add");
        Console.WriteLine("2. List");
        Console.WriteLine("3. Edit");
        Console.WriteLine("4. Complete");
        Console.WriteLine("5. Delete");
        Console.WriteLine("6. Set Priority");
        Console.WriteLine("7. Exit");
        Console.Write("Choose an option: ");
    }

    public static void RunTodoList()
    {
        string? choice;
        do
        {
            DisplayMenu();
            choice = Console.ReadLine()?.ToLower();
            switch (choice)
            {
                case "1":
                case "add":
                    Console.Write("Enter task title: ");
                    string? title = Console.ReadLine();
                    Console.Write("Enter task description: ");
                    string? description = Console.ReadLine();
                    Console.Write("Enter due date (YYYY-MM-DD): ");
                    DateTime dueDate;
                    if (!DateTime.TryParse(Console.ReadLine(), out dueDate))
                    {
                        Console.WriteLine("Invalid date format. Task not added.");
                        break;
                    }
                    Console.Write("Enter priority (high, medium, low): ");
                    string? priorityStr = Console.ReadLine()?.ToLower();
                    if (priorityStr != "high" && priorityStr != "medium" && priorityStr != "low")
                    {
                        Console.WriteLine("Invalid priority. Task not added.");
                        break;
                    }
                    Priority priority = (Priority)Enum.Parse(typeof(Priority), priorityStr, true);
                    AddTask(title.ToString(), description.ToString(), dueDate, priority);
                    break;

                case "2":
                case "list":
                    ListTasks();
                    break;

                case "3":
                case "edit":
                    Console.Write("Enter task ID to edit: ");
                    if (!int.TryParse(Console.ReadLine(), out int editId))
                    {
                        Console.WriteLine("Invalid task ID.");
                        break;
                    }
                    Console.Write("Enter new title: ");
                    string? newTitle = Console.ReadLine();
                    Console.Write("Enter new description: ");
                    string? newDescription = Console.ReadLine();
                    Console.Write("Enter new due date (YYYY-MM-DD): ");
                    DateTime newDueDate;
                    if (!DateTime.TryParse(Console.ReadLine(), out newDueDate))
                    {
                        Console.WriteLine("Invalid date format. Task not edited.");
                        break;
                    }
                    Console.Write("Enter new priority (high, medium, low): ");
                    string? newPriorityStr = Console.ReadLine()?.ToLower();
                    if (newPriorityStr != "high" && newPriorityStr != "medium" && newPriorityStr != "low")
                    {
                        Console.WriteLine("Invalid priority. Task not edited.");
                        break;
                    }
                    Priority newPriority = (Priority)Enum.Parse(typeof(Priority), newPriorityStr, true);
                    EditTask(editId, newTitle.ToString(), newDescription.ToString(), newDueDate, newPriority);
                    break;

                case "4":
                case "complete":
                    Console.Write("Enter task ID to mark as completed: ");
                    if (!int.TryParse(Console.ReadLine(), out int completeId))
                    {
                        Console.WriteLine("Invalid task ID.");
                        break;
                    }
                    CompleteTask(completeId);
                    break;

                case "5":
                case "delete":
                    Console.Write("Enter task ID to delete: ");
                    if (!int.TryParse(Console.ReadLine(), out int deleteId))
                    {
                        Console.WriteLine("Invalid task ID.");
                        break;
                    }
                    DeleteTask(deleteId);
                    break;

                case "6":
                case "set priority":
                    Console.Write("Enter task ID to set priority: ");
                    if (!int.TryParse(Console.ReadLine(), out int priorityId))
                    {
                        Console.WriteLine("Invalid task ID.");
                        break;
                    }
                    Console.Write("Enter new priority (high, medium, low): ");
                    string? priorityValue = Console.ReadLine()?.ToLower();
                    if (priorityValue != "high" && priorityValue != "medium" && priorityValue != "low")
                    {
                        Console.WriteLine("Invalid priority.");
                        break;
                    }
                    SetPriority(priorityId, (Priority)Enum.Parse(typeof(Priority), priorityValue, true));
                    break;

                case "7":
                case "exit":
                    Console.WriteLine("Exiting the application. Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        } while (choice != "exit");
    }
}
