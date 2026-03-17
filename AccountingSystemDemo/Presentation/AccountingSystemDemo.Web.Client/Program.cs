using AccountingSystemDemo.Web.Client;
using AccountingSystemDemo.Web.Client.Interfaces;
using AccountingSystemDemo.Web.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Root components
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configure HttpClient with base API URI
var baseUri = builder.Configuration["ApiSettings:BaseUri"];
if (string.IsNullOrWhiteSpace(baseUri))
    throw new InvalidOperationException("ApiSettings:BaseUri configuration is missing or empty.");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseUri) });

// Register client-side API service
builder.Services.AddScoped<IApiService, ApiService>();

// Build and run the WebAssembly app
await builder.Build().RunAsync();