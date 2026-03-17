using AccountingSystemDemo.PaymentApplication.Interfaces;
using System.Text;


namespace AccountingSystemDemo.PaymentInfrastructure.ServiceClients
{
    public class PaymentServiceClient : IPaymentServiceClient
    {
        private readonly HttpClient _http;

        public PaymentServiceClient(HttpClient http)
        {
            _http = http;
        }

        public async Task<string> GetPayments()
        {
            var response = await _http.GetAsync("/payments");

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> CreatePayment(string json)
        {
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _http.PostAsync("/payments", content);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
