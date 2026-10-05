var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.AspireFunctionsPoc_ApiService>("apiservice")
    .WithHttpHealthCheck("/health");

builder.AddProject<Projects.AspireFunctionsPoc_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(apiService)
    .WaitFor(apiService);

builder.AddAzureFunctionsProject<Projects.FunctionApp1>("functionapp1");

builder.Build().Run();
