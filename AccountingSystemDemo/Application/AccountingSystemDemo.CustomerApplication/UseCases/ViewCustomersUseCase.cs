using AccountingSystemDemo.CustomerApplication.Interfaces;
using AccountingSystemDemo.CustomerDomain.Entities;

/// <summary>
/// Use case for retrieving customers from the repository.
/// </summary>
public class ViewCustomersUseCase : IViewCustomersUseCase
{
    /// <summary>
    /// Repository used to access customer data.
    /// </summary>
    private readonly ICustomerRepository customerRepository;

    /// <summary>
    /// Initializes a new instance of <see cref="ViewCustomersUseCase"/>.
    /// </summary>
    /// <param name="customerRepository">Injected customer repository.</param>
    public ViewCustomersUseCase(ICustomerRepository customerRepository)
    {
        this.customerRepository = customerRepository;
    }

    /// <summary>
    /// Executes the use case to retrieve customers.
    /// </summary>
    /// <returns>A collection of customer DTOs.</returns>
    public async Task<IEnumerable<Customer>> ExecuteAsync()
    {
        var customers = await customerRepository.GetCustomers();
        return customers;
    }
}