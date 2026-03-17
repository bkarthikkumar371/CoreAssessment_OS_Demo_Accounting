using AccountingSystemDemo.CommonApplication.Enums;
using AccountingSystemDemo.InvoiceDomain.Entities;

/// <summary>
/// Use case for retrieving invoices filtered by their status.
/// </summary>
public class ViewInvoicesByStatusUseCase : IViewInvoicesByStatusUseCase
{
    private readonly IInvoiceRepository _invoiceRepository;

    /// <summary>
    /// Initializes a new instance of <see cref="ViewInvoicesByStatusUseCase"/>.
    /// </summary>
    /// <param name="invoiceRepository">Injected invoice repository.</param>
    public ViewInvoicesByStatusUseCase(IInvoiceRepository invoiceRepository)
    {
        _invoiceRepository = invoiceRepository;
    }

    /// <summary>
    /// Executes the use case to retrieve invoices by status.
    /// </summary>
    /// <param name="invoiceStatusEnum">The status to filter invoices by.</param>
    
    /// <returns>A collection of invoice  with the specified status.</returns>
    public async Task<IEnumerable<Invoice>> ExecuteAsync(InvoiceStatusEnum invoiceStatusEnum)
    {
        return await _invoiceRepository.GetInvoicesByStatus(invoiceStatusEnum);
    }
}