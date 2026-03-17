using AccountingSystemDemo.CustomerApplication.Interfaces;
using AccountingSystemDemo.CustomerInfrastructure.ServiceClients;
using AccountingSystemDemo.InvoiceInfrastructure.ServiceClients;

var builder = WebApplication.CreateBuilder(args);

// Register default services
builder.AddServiceDefaults();

// Add MVC controllers
builder.Services.AddControllers();

// Enable OpenAPI/Swagger
builder.Services.AddOpenApi();

// Configure HTTP clients for external services
var customerServiceUrl = builder.Configuration["Services:CustomerService"];
if (string.IsNullOrEmpty(customerServiceUrl))
    throw new InvalidOperationException("Configuration value for 'Services:CustomerService' is missing.");

builder.Services.AddHttpClient<ICustomerServiceClient, CustomerServiceClient>(c =>
{
    c.BaseAddress = new Uri(customerServiceUrl);
});

var invoiceServiceUrl = builder.Configuration["Services:InvoiceService"];
if (string.IsNullOrEmpty(invoiceServiceUrl))
    throw new InvalidOperationException("Configuration value for 'Services:InvoiceService' is missing.");

builder.Services.AddHttpClient<IInvoiceServiceClient, InvoiceServiceClient>(c =>
{
    c.BaseAddress = new Uri(invoiceServiceUrl);
});

// Configure CORS (Development only policy)
builder.Services.AddCors(options =>
{
    options.AddPolicy("DevOpenPolicy", policy =>
    {
        policy.AllowAnyOrigin() // WARNING: Only use this in Dev
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Default endpoints for health checks or metrics
app.MapDefaultEndpoints();

// Configure middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseCors("DevOpenPolicy");
}
else
{
    app.UseHttpsRedirection();
}

app.UseRouting();

// Map API controllers
app.MapControllers();

// Run the application
app.Run();