using AccountingSystemDemo.CommonApplication.Enums;
using AccountingSystemDemo.InvoiceDomain.Entities;

/// <summary>
/// Use case for retrieving invoices filtered by their status.
/// </summary>
public interface IViewInvoicesByStatusUseCase
{
    /// <summary>
    /// Executes the use case to retrieve invoices by status.
    /// </summary>
    /// <param name="invoiceStatusEnum">The status to filter invoices by.</param>
    
    /// <returns>A collection of invoice DTOs with the specified status.</returns>
    Task<IEnumerable<Invoice>> ExecuteAsync(InvoiceStatusEnum invoiceStatusEnum);
}