using AccountingSystemDemo.Api.CustomerService.Interface;
using AccountingSystemDemo.CommonApplication.DTOs;
using AccountingSystemDemo.CustomerApplication.Interfaces;
using AccountingSystemDemo.CustomerDomain.Entities;

namespace AccountingSystemDemo.Api.CustomerService.Service
{
    /// <summary>
    /// Application service implementation for managing customers.
    /// </summary>
    public class CustomerService : ICustomerService
    {
        private readonly IViewCustomersUseCase _viewCustomersUseCase;

        /// <summary>
        /// Initializes a new instance of <see cref="CustomerService"/>.
        /// </summary>
        /// <param name="viewCustomersUseCase">Injected use case for viewing customers.</param>
        public CustomerService(IViewCustomersUseCase viewCustomersUseCase)
        {
            _viewCustomersUseCase = viewCustomersUseCase;
        }

        public CustomerDto MapToDto(Customer customer)
        {
            return new CustomerDto { 
                CustomerId = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber
            };
        }

        /// <summary>
        /// Retrieves customers filtered by name.
        /// </summary>
        /// <param name="name">Name filter (optional).</param>
        
        /// <returns>List of <see cref="CustomerDto"/> matching the filter.</returns>
        public async Task<List<CustomerDto>> GetCustomers()
        {
            var customerDtos = (await _viewCustomersUseCase.ExecuteAsync()).Select(x => MapToDto(x));
            return customerDtos.ToList();
        }
    }
}