using AccountingSystemDemo.CommonApplication.Enums;
using AccountingSystemDemo.InvoiceDomain.Entities;

/// <summary>
/// Use case for updating the status of an invoice.
/// </summary>
public interface IUpdateInvoiceStatusUseCase
{
    /// <summary>
    /// Updates the status of an invoice.
    /// </summary>
    /// <param name="id">ID of the invoice to update.</param>
    /// <param name="invoiceStatusEnum">New status to set.</param>
    
    /// <returns>The updated invoice if successful; otherwise, null.</returns>
    Task<Invoice?> ExecuteAsync(int id, InvoiceStatusEnum invoiceStatusEnum);
}