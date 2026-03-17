using AccountingSystemDemo.Api.CustomerService.Interface;
using AccountingSystemDemo.Api.CustomerService.Service;
using AccountingSystemDemo.CustomerApplication.Interfaces;
using AccountingSystemDemo.CustomerInfrastructure.Persistence.InMemory;


var builder = WebApplication.CreateBuilder(args);

// Register default services and configurations
builder.AddServiceDefaults();

// Dependency Injection
builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IViewCustomersUseCase, ViewCustomersUseCase>();
builder.Services.AddTransient<ICustomerService, CustomerService>();

// Configure CORS from appsettings
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

// Enable HTTPS and routing
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("SettingsPolicy");

// Map API endpoint for customers
app.MapGet("/customers",
    async (ICustomerService customerService, string? name = null) =>
    {
        var customers = await customerService.GetCustomers();
        return customers.Any()
            ? Results.Ok(customers)
            : Results.NotFound($"Customer '{name}' not found");
    })
    .WithName("GetCustomers")
    .WithTags("Customer");

// Map default endpoints (e.g., health checks, metrics)
app.MapDefaultEndpoints();

// Run the application
app.Run();