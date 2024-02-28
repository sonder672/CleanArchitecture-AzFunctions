namespace TaskMicroservice.Services.DTOs.IN;

public record TaskCreateUpdateInputDTO(
    Guid? Id,
    string Name,
    string Description,
    DateTime CreationDate,
    DateTime? DueDate,
    Domain.POCOs.TaskStatus Status,
    Domain.POCOs.TaskPriority Priority,
    List<string>? Labels,
    string AssignedUser,
    string Notes);
