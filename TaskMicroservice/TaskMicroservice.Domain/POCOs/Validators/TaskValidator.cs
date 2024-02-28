namespace TaskMicroservice.Domain.POCOs.Validators;

public static class TaskValidator
{
    public static IList<string>? ValidateTaskAndGetErrors(
        string name,
        string description,
        DateTime creationDate,
        DateTime? dueDate,
        TaskPriority priority,
        TaskStatus status)
    {
        IList<string> errors = [];

        if (string.IsNullOrWhiteSpace(name))
            errors.Add("Name cannot be null or empty.");

        if (string.IsNullOrWhiteSpace(description))
            errors.Add("Description cannot be null or empty.");

        if (creationDate == default)
            errors.Add("CreationDate cannot be default.");

        if (dueDate.HasValue && dueDate < creationDate)
            errors.Add("DueDate cannot be earlier than CreationDate.");

        if (priority == TaskPriority.High && status == TaskStatus.Pending)
            errors.Add("High priority tasks cannot have pending status.");

        return errors.Count != 0
        ? errors
        : null;
    }
}
