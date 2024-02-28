namespace TaskMicroservice.Presenters.Contracts;

public interface IPresenter
{
    public bool IsSuccess { get; }
    public object? Result { get; }
}
