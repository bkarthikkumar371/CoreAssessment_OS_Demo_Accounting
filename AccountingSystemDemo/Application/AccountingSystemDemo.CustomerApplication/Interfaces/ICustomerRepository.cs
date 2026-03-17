
using AccountingSystemDemo.CustomerDomain.Entities;

namespace AccountingSystemDemo.CustomerApplication.Interfaces
{
    /// <summary>
    /// Repository interface for retrieving customer data.
    /// </summary>
    public interface ICustomerRepository
    {
        /// <summary>
        /// Retrieves customers whose names match the provided search criteria.
        /// </summary>
        /// <returns>Collection of matching customers.</returns>
        Task<IEnumerable<Customer>> GetCustomers();
    }
}
