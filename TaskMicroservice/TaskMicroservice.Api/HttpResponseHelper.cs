using System.Net;
using System.Text.Json;
using Microsoft.Azure.Functions.Worker.Http;

namespace TaskMicroservice.Api;

public static class HttpResponseHelper
{
    public static HttpResponseData OkResponse(HttpRequestData req, object? body)
    {
        var response = req.CreateResponse(HttpStatusCode.OK);
        WriteJsonToResponse(response, body ?? new { message = "Successful" });

        return response;
    }

    public static HttpResponseData BadRequestResponse(HttpRequestData req, object? body)
    {
        var response = req.CreateResponse(HttpStatusCode.BadRequest);
        WriteJsonToResponse(response, body ?? new { message = "Something has gone wrong" });

        return response;
    }


    private static void WriteJsonToResponse(HttpResponseData response, object body)
    {
        var jsonString = JsonSerializer.Serialize(body);
        var buffer = System.Text.Encoding.UTF8.GetBytes(jsonString);

        response.Body = new MemoryStream(buffer);
        response.Headers.Add("Content-Type", "application/json; charset=utf-8");
    }
}
