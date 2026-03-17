using AccountingSystemDemo.CommonApplication.DTOs;
using AccountingSystemDemo.CommonApplication.Enums;
using System.Text;
using System.Text.Json;

namespace AccountingSystemDemo.InvoiceInfrastructure.ServiceClients
{
    /// <summary>
    /// Service client for interacting with external invoice APIs.
    /// </summary>
    public class InvoiceServiceClient : IInvoiceServiceClient
    {
        private readonly HttpClient _httpClient;
        private JsonSerializerOptions options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };


        /// <summary>
        /// Initializes a new instance of <see cref="InvoiceServiceClient"/>.
        /// </summary>
        /// <param name="httpClient">Injected HTTP client for API calls.</param>
        public InvoiceServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Retrieves all invoices from the external service.
        /// </summary>
        
        /// <returns>Raw JSON string of all invoices.</returns>
        public async Task<IEnumerable<InvoiceDto>> GetAllInvoices()
        {
            var response = await _httpClient.GetAsync("/invoices");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<InvoiceDto>>(result, options) ?? Enumerable.Empty<InvoiceDto>();
        }

        /// <summary>
        /// Creates a new invoice via the external service.
        /// </summary>
        /// <param name="json">Invoice payload as JSON string.</param>
        
        /// <returns>Raw JSON string of created invoice.</returns>
        public async Task<InvoiceDto?> CreateInvoice(CreateInvoiceDto createInvoiceDto)
        {
            var json = JsonSerializer.Serialize(createInvoiceDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("/invoices", content);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<InvoiceDto>(result, options);
        }

        /// <summary>
        /// Updates the status of an invoice via the external service.
        /// </summary>
        /// <param name="id">Invoice ID.</param>
        /// <param name="invoiceStatusEnum">New status.</param>
        
        /// <returns>Raw JSON string of updated invoice.</returns>
        public async Task<InvoiceDto?> UpdateInvoiceStatus(int id, InvoiceStatusEnum invoiceStatusEnum)
        {
            var response = await _httpClient.PatchAsync($"/invoices/{id}/status/{(int)invoiceStatusEnum}", null);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<InvoiceDto>(result, options);
        }

        /// <summary>
        /// Retrieves invoices filtered by status from the external service.
        /// </summary>
        /// <param name="invoiceStatusEnum">Status to filter.</param>
        
        /// <returns>Raw JSON string of invoices.</returns>
        public async Task<IEnumerable<InvoiceDto>> GetInvoicesByStatus(InvoiceStatusEnum invoiceStatusEnum)
        {
            var response = await _httpClient.GetAsync($"/invoices/status/{(int)invoiceStatusEnum}");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<InvoiceDto>>(result, options) ?? Enumerable.Empty<InvoiceDto>();
        }

        /// <summary>
        /// Retrieves a single invoice by ID from the external service.
        /// </summary>
        /// <param name="id">Invoice ID.</param>
        
        /// <returns>Raw JSON string of the invoice.</returns>
        public async Task<InvoiceDto?> GetInvoiceById(int id)
        {
            var response = await _httpClient.GetAsync($"/invoices/{id}");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<InvoiceDto>(result, options);
        }
    }
}