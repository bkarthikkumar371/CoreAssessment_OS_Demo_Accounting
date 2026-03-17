using AccountingSystemDemo.CommonApplication.DTOs;
using AccountingSystemDemo.CustomerApplication.Interfaces;
using System.Net.Http.Json;
namespace AccountingSystemDemo.CustomerInfrastructure.ServiceClients
{
    /// <summary>
    /// Service client for retrieving customer data from an external API.
    /// </summary>
    public class CustomerServiceClient : ICustomerServiceClient
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Initializes a new instance of <see cref="CustomerServiceClient"/>.
        /// </summary>
        /// <param name="httpClient">Injected HTTP client for API calls.</param>
        public CustomerServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Retrieves customers from the external API.
        /// </summary>
        
        /// <returns>A collection of <see cref="CustomerDto"/>.</returns>
        public async Task<IEnumerable<CustomerDto>> GetCustomers()
        {
            var response = await _httpClient.GetAsync("/customers");
            response.EnsureSuccessStatusCode();

            var customers = await response.Content.ReadFromJsonAsync<IEnumerable<CustomerDto>>();
            return customers ?? new List<CustomerDto>();
        }
    }
}