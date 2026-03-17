using AccountingSystemDemo.CommonApplication.DTOs;
using AccountingSystemDemo.CommonApplication.Enums;
using AccountingSystemDemo.Web.Client.Interfaces;
using System.Net.Http.Json;

namespace AccountingSystemDemo.Web.Client.Services
{
    /// <summary>
    /// Client-side API service for communicating with customer and invoice APIs.
    /// </summary>
    public class ApiService : IApiService
    {
        private readonly HttpClient _http;

        /// <summary>
        /// Initializes a new instance of <see cref="ApiService"/>.
        /// </summary>
        /// <param name="http">Injected HttpClient.</param>
        public ApiService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<CustomerDto>> GetCustomers()
        {
            var result = await _http.GetFromJsonAsync<List<CustomerDto>>("api/customers");
            return result ?? new List<CustomerDto>();
        }

        public async Task<List<InvoiceDto>> GetAllInvoices()
        {
            var result = await _http.GetFromJsonAsync<List<InvoiceDto>>("api/invoices");
            return result ?? new List<InvoiceDto>();
        }

        public async Task<List<InvoiceDto>> GetAllInvoicesByStatus(int statusCode)
        {
            var result = await _http.GetFromJsonAsync<List<InvoiceDto>>($"api/invoices/status/{statusCode}");
            return result ?? new List<InvoiceDto>();
        }

        public async Task<InvoiceDto?> GetInvoiceById(int id)
        {
            return await _http.GetFromJsonAsync<InvoiceDto>($"api/invoices/{id}");
        }

        public async Task<InvoiceDto?> UpdateInvoiceStatus(int id, InvoiceStatusEnum statusCode)
        {
            var url = $"api/invoices/{id}/status/{(int)statusCode}";
            var response = await _http.PatchAsync(url, null);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<InvoiceDto>();
            }

            return null;
        }

        public async Task<InvoiceDto?> CreateInvoice(CreateInvoiceDto createInvoiceDto)
        {
            if (createInvoiceDto is null)
                throw new ArgumentNullException(nameof(createInvoiceDto));

            var response = await _http.PostAsJsonAsync("api/invoices", createInvoiceDto);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<InvoiceDto>();
            }

            return null;
        }
    }
}