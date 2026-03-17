using AccountingSystemDemo.InvoiceDomain.Entities;

/// <summary>
/// Use case for retrieving all invoices.
/// </summary>
public interface IViewAllInvoicesUseCase
{
    /// <summary>
    /// Executes the use case to retrieve all invoices.
    /// </summary>
    
    /// <returns>A collection of invoice.</returns>
    Task<IEnumerable<Invoice>> ExecuteAsync();
}