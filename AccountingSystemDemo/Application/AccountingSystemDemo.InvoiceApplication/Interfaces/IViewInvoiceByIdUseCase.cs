using AccountingSystemDemo.InvoiceDomain.Entities;


/// <summary>
/// Use case for retrieving a single invoice by its ID.
/// </summary>
public interface IViewInvoiceByIdUseCase
{
    /// <summary>
    /// Executes the use case to retrieve an invoice by ID.
    /// </summary>
    /// <param name="invoiceId">ID of the invoice to retrieve.</param>
    
    /// <returns>The invoice DTO if found; otherwise, null.</returns>
    Task<Invoice?> ExecuteAsync(int invoiceId);
}