using AccountingSystemDemo.CommonApplication.DTOs;

namespace AccountingSystemDemo.CustomerApplication.Interfaces
{
    /// <summary>
    /// Retrieves the collection of customers from external service.
    /// </summary>
    /// <returns>Collection of customers.</returns>
    public interface ICustomerServiceClient
    {
        Task<IEnumerable<CustomerDto>> GetCustomers();
    }
}
