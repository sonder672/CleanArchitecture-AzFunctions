using TaskMicroservice.Domain.Repositories;

namespace TaskMicroservice.EFCore.Repositories;

public class TaskRepository : ITaskRepository
{
    public Task Create(Domain.POCOs.Task task)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Domain.POCOs.Task task)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Domain.POCOs.Task>?> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Domain.POCOs.Task> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Domain.POCOs.Task>>? GetTasksInDateRange(DateTime startDate, DateTime finishDate)
    {
        throw new NotImplementedException();
    }

    public Task Update(Domain.POCOs.Task task)
    {
        throw new NotImplementedException();
    }
}
