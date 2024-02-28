using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using TaskMicroservice.Presenters.Contracts;
using TaskMicroservice.Services.DTOs.IN;
using TaskMicroservice.Services.Ports.IN;
using TaskMicroservice.Services.Ports.OUT;

namespace TaskMicroservice.Api
{
    public class Controller
    {
        private readonly ITaskHandlerInputPort _inputPort;
        private readonly IGenericTaskHandlerOutputPort _outputPort;

        public Controller(IGenericTaskHandlerOutputPort outputPort, ITaskHandlerInputPort inputPort)
        {
            _outputPort = outputPort;
            _inputPort = inputPort;
        }

        [Function("Create")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = "v1/task/create")] HttpRequestData req)
        {
            TaskCreateUpdateInputDTO? requestBody = await req.ReadFromJsonAsync<TaskCreateUpdateInputDTO>();

            if (requestBody is null)
            {
                return HttpResponseHelper.BadRequestResponse(req, null);
            }

            await this._inputPort.Create(requestBody!);

            bool isSuccess = ((IPresenter)_outputPort).IsSuccess;
            object? response = ((IPresenter)_outputPort).Result;

            if (!isSuccess)
            {
                return HttpResponseHelper.BadRequestResponse(req, response);
            }

            return HttpResponseHelper.OkResponse(req, response);
        }
    }
}
