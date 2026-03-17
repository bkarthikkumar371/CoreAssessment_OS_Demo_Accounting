using AccountingSystemDemo.Api.InvoiceService.Interface;
using AccountingSystemDemo.Api.InvoiceService.Service;
using AccountingSystemDemo.CommonApplication.DTOs;
using AccountingSystemDemo.CommonApplication.Enums;
using AccountingSystemDemo.InvoiceInfrastructure.Persistence.InMemory;
var builder = WebApplication.CreateBuilder(args);

// Register default services
builder.AddServiceDefaults();

// Dependency Injection
builder.Services.AddSingleton<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddInvoiceUseCases();
builder.Services.AddTransient<IInvoiceService, InvoiceService>();

// Configure CORS
var allowedOrigins = builder.Configuration
    .GetSection("CorsSettings:AllowedOrigins")
    .Get<string[]>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("SettingsPolicy", policy =>
    {
        if (allowedOrigins != null)
        {
            policy.WithOrigins(allowedOrigins)
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        }
    });
});

var app = builder.Build();


// Middleware
app.UseHttpsRedirection();
app.UseRouting();

app.UseCors("SettingsPolicy");

// API Endpoints

// Get all invoices
app.MapGet("/invoices", async (IInvoiceService service) =>
{
    var invoices = await service.GetAllInvoices();
    return invoices.Any() ? Results.Ok(invoices) : Results.NotFound("Invoices not found");
})
.WithName("GetAllInvoices")
.WithTags("Invoice");

// Get invoice by ID
app.MapGet("/invoices/{id:int}", async (IInvoiceService service, int id) =>
{
    var invoice = await service.GetInvoiceById(id);
    return invoice is not null ? Results.Ok(invoice) : Results.NotFound("Invoice not found");
})
.WithName("GetInvoiceById")
.WithTags("Invoice");

// Get invoices by status
app.MapGet("/invoices/status/{statusCode:int}", async (IInvoiceService service, int statusCode) =>
{
    var invoices = await service.GetInvoicesByStatus((InvoiceStatusEnum)statusCode);
    return invoices.Any() ? Results.Ok(invoices) : Results.NotFound("Invoices not found");
})
.WithName("GetInvoicesByStatus")
.WithTags("Invoice");

// Create new invoice
app.MapPost("/invoices", async (CreateInvoiceDto dto, IInvoiceService service) =>
{
    var invoice = await service.CreateInvoice(dto);
    return invoice is not null
        ? Results.Created($"/invoices/{invoice.InvoiceId}", invoice)
        : Results.Problem("Invoice not created");
})
.WithName("CreateInvoice")
.WithTags("Invoice");

// Update invoice status
app.MapPatch("/invoices/{id:int}/status/{statusCode:int}", async (IInvoiceService service, int id, int statusCode) =>
{
    var invoice = await service.UpdateInvoiceStatus(id, (InvoiceStatusEnum)statusCode);
    return invoice is not null ? Results.Ok(invoice) : Results.NotFound("Invoice not found");
})
.WithName("UpdateInvoiceStatus")
.WithTags("Invoice");

// Default endpoints (health checks, etc.)
app.MapDefaultEndpoints();

app.Run();