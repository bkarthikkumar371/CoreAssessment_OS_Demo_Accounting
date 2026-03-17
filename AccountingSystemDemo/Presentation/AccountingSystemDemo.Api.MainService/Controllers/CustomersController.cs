using AccountingSystemDemo.CustomerApplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AccountingSystemDemo.Api.MainService.Controllers
{
    /// <summary>
    /// API controller for customer-related endpoints.
    /// </summary>
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerServiceClient _customerServiceClient;

        /// <summary>
        /// Initializes a new instance of <see cref="CustomersController"/>.
        /// </summary>
        /// <param name="customerServiceClient">Injected customer service client.</param>
        public CustomersController(ICustomerServiceClient customerServiceClient)
        {
            _customerServiceClient = customerServiceClient;
        }

        /// <summary>
        /// Retrieves customers with optional search filter.
        /// </summary>
        /// <param name="search">Optional search string for customer names.</param>
        /// <returns>List of customers as JSON.</returns>
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var data = await _customerServiceClient.GetCustomers();

            if (data is null || !data.Any())
                return NotFound("No customers found.");

            return Ok(data);
        }
    }
}
