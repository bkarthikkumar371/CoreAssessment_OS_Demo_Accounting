using AccountingSystemDemo.CustomerDomain.Entities;

namespace AccountingSystemDemo.CustomerApplication.Interfaces
{
    /// <summary>
    /// Retrieves a collection of customers for viewing purposes.
    /// </summary>
    public interface IViewCustomersUseCase
    {
        /// <summary>
        /// Executes the use case to retrieve customers.
        /// </summary>
        /// <returns>A collection of customer DTOs.</returns>
        Task<IEnumerable<Customer>> ExecuteAsync();
    }
}