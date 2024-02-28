namespace TaskMicroservice.Domain.Repositories;

public interface ITaskRepository
{
    public Task Create(POCOs.Task task);
    public Task<IEnumerable<POCOs.Task>>? GetTasksInDateRange(DateTime startDate, DateTime finishDate);
    public Task<POCOs.Task> GetById(Guid id);
    public Task<IEnumerable<POCOs.Task>?> GetAll();
    public Task Update(POCOs.Task task);
    public Task Delete(POCOs.Task task);
}
