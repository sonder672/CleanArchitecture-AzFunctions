using System.Diagnostics;
using TaskMicroservice.Domain.Repositories;
using TaskMicroservice.Services.DTOs.OUT;
using TaskMicroservice.Services.Ports.IN;
using TaskMicroservice.Services.Ports.OUT;
using UtilMicroservice.Domain;

namespace TaskMicroservice.Services.UseCases;

public class TaskActionUseCase : ITaskHandlerInputPort
{
    private readonly ITaskRepository _taskRepository;
    private readonly IGenericTaskHandlerOutputPort _taskHandlerOutputPort;

    public TaskActionUseCase(ITaskRepository taskRepository, IGenericTaskHandlerOutputPort taskHandlerOutputPort)
    {
        _taskRepository = taskRepository;
        _taskHandlerOutputPort = taskHandlerOutputPort;
    }

    public async Task Create(DTOs.IN.TaskCreateUpdateInputDTO task)
    {
        Result<Domain.POCOs.Task> taskInstance = Domain.POCOs.Task.Create(
            task.Name,
            task.Description,
            task.CreationDate,
            task.DueDate,
            task.Status,
            task.Priority,
            task.Labels,
            task.AssignedUser,
            task.Notes);

        if (!taskInstance.IsSuccess || taskInstance.Value is null)
        {
            await this._taskHandlerOutputPort.PresentError(taskInstance.ErrorMessages);

            return;
        }

        await this._taskRepository.Create(taskInstance.Value!);

        TaskCreateUpdateOutputDTO successfulResponse = new(
            Name: task.Name,
            Id: taskInstance.Value!.TaskId);
        await this._taskHandlerOutputPort.PresentSuccess(successfulResponse);
    }

    public async Task Update(DTOs.IN.TaskCreateUpdateInputDTO task, Guid taskId)
    {
        Result<Domain.POCOs.Task> taskInstance = Domain.POCOs.Task.Create(
            task.Name,
            task.Description,
            task.CreationDate,
            task.DueDate,
            task.Status,
            task.Priority,
            task.Labels,
            task.AssignedUser,
            task.Notes,
            taskId);

        if (!taskInstance.IsSuccess || taskInstance.Value is null)
        {
            await this._taskHandlerOutputPort.PresentError(taskInstance.ErrorMessages);

            return;
        }

        await this._taskRepository.Update(taskInstance.Value!);

        TaskCreateUpdateOutputDTO successfulResponse = new(
            Name: task.Name,
            Id: taskInstance.Value!.TaskId);
        await this._taskHandlerOutputPort.PresentSuccess(successfulResponse);
    }
}
