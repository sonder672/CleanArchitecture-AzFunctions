namespace TaskMicroservice.Services.Ports.IN;

public interface ITaskHandlerInputPort
{
    Task Create(DTOs.IN.TaskCreateUpdateInputDTO task);
    Task Update(DTOs.IN.TaskCreateUpdateInputDTO task, Guid taskId);
}
