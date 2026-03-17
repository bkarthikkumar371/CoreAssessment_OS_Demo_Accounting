using AccountingSystemDemo.CommonApplication.DTOs;

namespace AccountingSystemDemo.Api.CustomerService.Interface
{
    /// <summary>
    /// Application service interface for managing customers.
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// Retrieves customers filtered by name.
        /// </summary>
        
        /// <returns>A list of <see cref="CustomerDto"/> matching the filter.</returns>
        Task<List<CustomerDto>> GetCustomers();
    }
}