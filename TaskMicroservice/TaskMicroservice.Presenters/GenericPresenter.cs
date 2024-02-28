using System.Diagnostics;
using TaskMicroservice.Presenters.Contracts;
using TaskMicroservice.Services.Ports.OUT;

namespace TaskMicroservice.Presenters;

public class GenericPresenter : IGenericTaskHandlerOutputPort, IPresenter
{
    public bool IsSuccess { get; private set; }
    public object? Result { get; private set; }

    public async Task PresentError(IEnumerable<string>? errors)
    {
        IsSuccess = false;
        errors ??= ["A business error has occurred"];
        Result = new { errors };

        await Task.CompletedTask;
    }

    public async Task PresentSuccess(object result)
    {
        IsSuccess = true;
        Result = result;

        await Task.CompletedTask;
    }
}
