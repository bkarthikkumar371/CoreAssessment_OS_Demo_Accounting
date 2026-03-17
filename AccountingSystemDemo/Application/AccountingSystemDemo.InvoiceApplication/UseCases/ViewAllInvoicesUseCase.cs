using AccountingSystemDemo.InvoiceDomain.Entities;

/// <summary>
/// Use case for retrieving all invoices.
/// </summary>
public class ViewAllInvoicesUseCase : IViewAllInvoicesUseCase
{
    private readonly IInvoiceRepository _invoiceRepository;

    /// <summary>
    /// Initializes a new instance of <see cref="ViewAllInvoicesUseCase"/>.
    /// </summary>
    /// <param name="invoiceRepository">Injected invoice repository.</param>
    public ViewAllInvoicesUseCase(IInvoiceRepository invoiceRepository)
    {
        _invoiceRepository = invoiceRepository;
    }

    /// <summary>
    /// Executes the use case to retrieve all invoices.
    /// </summary>
    
    /// <returns>A collection of invoice DTOs.</returns>
    public async Task<IEnumerable<Invoice>> ExecuteAsync()
    {
        return await _invoiceRepository.GetAllInvoices();
    }
}