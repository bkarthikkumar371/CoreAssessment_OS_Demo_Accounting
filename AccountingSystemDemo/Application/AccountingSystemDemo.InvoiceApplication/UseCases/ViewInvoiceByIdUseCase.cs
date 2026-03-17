using AccountingSystemDemo.InvoiceDomain.Entities;

/// <summary>
/// Use case for retrieving a single invoice by its ID.
/// </summary>
public class ViewInvoiceByIdUseCase : IViewInvoiceByIdUseCase
{
    private readonly IInvoiceRepository _invoiceRepository;

    /// <summary>
    /// Initializes a new instance of <see cref="ViewInvoiceByIdUseCase"/>.
    /// </summary>
    /// <param name="invoiceRepository">Injected invoice repository.</param>
    public ViewInvoiceByIdUseCase(IInvoiceRepository invoiceRepository)
    {
        _invoiceRepository = invoiceRepository;
    }

    /// <summary>
    /// Executes the use case to retrieve an invoice by ID.
    /// </summary>
    /// <param name="invoiceId">ID of the invoice to retrieve.</param>
    
    /// <returns>The invoice if found; otherwise, null.</returns>
    public async Task<Invoice?> ExecuteAsync(int invoiceId)
    {
        return await _invoiceRepository.GetInvoiceById(invoiceId);
    }
}