using TaskMicroservice.Domain.POCOs.Validators;
using UtilMicroservice.Domain;

namespace TaskMicroservice.Domain.POCOs;

public class Task
{
    public Guid TaskId { get; }
    public string Name { get; } = null!;
    public string Description { get; } = null!;
    public DateTime CreationDate { get; }
    public DateTime? DueDate { get; }
    public TaskStatus Status { get; }
    public TaskPriority Priority { get; }
    public List<string>? Labels { get; }
    public string AssignedUser { get; } = null!;
    public string Notes { get; } = null!;

    private Task() { }
    private Task(
        Guid taskId,
        string name,
        string description,
        DateTime creationDate,
        DateTime? dueDate,
        TaskStatus status,
        TaskPriority priority,
        List<string>? labels,
        string assignedUser,
        string notes)
    {
        TaskId = taskId;
        Name = name;
        Description = description;
        CreationDate = creationDate;
        DueDate = dueDate;
        Status = status;
        Priority = priority;
        Labels = labels;
        AssignedUser = assignedUser;
        Notes = notes;
    }

    public static Result<Task> Create(
        string name,
        string description,
        DateTime creationDate,
        DateTime? dueDate,
        TaskStatus status,
        TaskPriority priority,
        List<string>? labels,
        string assignedUser,
        string notes,
        Guid? taskId = null
    )
    {
        IList<string>? errors = TaskValidator.ValidateTaskAndGetErrors(
        name,
        description,
        creationDate,
        dueDate,
        priority,
        status);

        if (errors is not null)
        {
            return Result<Task>.Failure(errors);
        }

        return Result<Task>.Success(new(
            taskId ?? Guid.NewGuid(),
            name,
            description,
            creationDate,
            dueDate,
            status,
            priority,
            labels,
            assignedUser,
            notes));
    }
}

public enum TaskStatus
{
    Pending,
    InProgress,
    Completed,
    Canceled
}

public enum TaskPriority
{
    Low,
    Medium,
    High
}