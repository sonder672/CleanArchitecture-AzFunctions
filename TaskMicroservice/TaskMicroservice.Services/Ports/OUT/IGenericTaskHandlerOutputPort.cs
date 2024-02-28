using UtilMicroservice.Domain;

namespace TaskMicroservice.Services.Ports.OUT;

public interface IGenericTaskHandlerOutputPort
{
    Task PresentError(IEnumerable<string>? errors);
    Task PresentSuccess(object result);
}
