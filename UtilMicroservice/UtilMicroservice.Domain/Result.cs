namespace UtilMicroservice.Domain;

public record Result<T>
{
    public bool IsSuccess { get; init; }
    public T? Value { get; init; }
    public IEnumerable<string>? ErrorMessages { get; init; }
    public static Result<T> Success(T value) => new() { IsSuccess = true, Value = value };
    public static Result<T> Failure(string errorMessage) => new()
    {
        IsSuccess = false,
        ErrorMessages = [errorMessage]
    };
    public static Result<T> Failure(IEnumerable<string> errorMessages) => new()
    {
        IsSuccess = false,
        ErrorMessages = errorMessages.ToList()
    };
}
