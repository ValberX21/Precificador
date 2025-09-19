using Azure.Storage.Blobs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QuestPDF.Infrastructure;

QuestPDF.Settings.License = LicenseType.Community;

var host = Host.CreateDefaultBuilder()
    .ConfigureFunctionsWebApplication() // <- aqui é o ponto do aviso AZFW0014
    .ConfigureServices(services =>
    {
        var storage = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
        if (string.IsNullOrWhiteSpace(storage))
            throw new InvalidOperationException("AzureWebJobsStorage is not set. Configure it in local.settings.json or App Settings.");

        services.AddSingleton(new BlobServiceClient(storage));
    })
    .Build();

await host.RunAsync();
