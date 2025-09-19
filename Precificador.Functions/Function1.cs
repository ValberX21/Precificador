using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Precificador.Functions.Contract;
using System.Text.Json;

namespace Precificador.Functions;

public class Function1
{
    private readonly ILogger<Function1> _logger;
    private readonly BlobServiceClient _blobServiceClient;
    public Function1(BlobServiceClient blobService, ILogger<Function1> logger)
    {
        _blobServiceClient = blobService;
        _logger = logger;
    }

    [Function("Test")]
    public async Task<IActionResult> Run(
     [HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        try
        {
            // Read the raw body text
            using var reader = new StreamReader(req.Body);
            string body = await reader.ReadToEndAsync();

            if (string.IsNullOrWhiteSpace(body))
                return new BadRequestObjectResult("Request body is empty.");

            // Deserialize JSON -> your model
            var msg = JsonSerializer.Deserialize<MateriaPrima>(
                body,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            if (msg is null)
                return new BadRequestObjectResult("Invalid JSON for MateriaPrima.");

            // Return an object (or serialize yourself)
            _logger.LogError("C# HTTP " + msg.Nome);
            return new OkObjectResult(new { message = "Hello, Welcome to Azure Functions!", data = msg });
        }
        catch (JsonException jex)
        {
            return new BadRequestObjectResult($"Invalid JSON: {jex.Message}");
        }
        catch (Exception ex)
        {
            return new ObjectResult($"Unexpected error: {ex.Message}") { StatusCode = 500 };
        }
        //return new OkObjectResult("Hello, Welcome to Azure Functions! + " + msg);
    }
}