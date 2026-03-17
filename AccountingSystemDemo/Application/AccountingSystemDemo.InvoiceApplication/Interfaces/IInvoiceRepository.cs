using AccountingSystemDemo.CommonApplication.Enums;
using AccountingSystemDemo.InvoiceDomain.Entities;

/// <summary>
/// Repository interface for accessing invoice data.
/// </summary>
public interface IInvoiceRepository
{
    /// <summary>
    /// Retrieves all invoices.
    /// </summary>
    
    /// <returns>List of invoices.</returns>
    Task<List<Invoice>> GetAllInvoices();

    /// <summary>
    /// Retrieves invoices filtered by status.
    /// </summary>
    Task<List<Invoice>> GetInvoicesByStatus(InvoiceStatusEnum invoiceStatusEnum);

    /// <summary>
    /// Retrieves an invoice by its ID.
    /// </summary>
    Task<Invoice?> GetInvoiceById(int id);

    /// <summary>
    /// Creates a new invoice.
    /// </summary>
    Task<Invoice> CreateInvoice(Invoice invoice);

    /// <summary>
    /// Updates the status of an invoice.
    /// </summary>
    Task<Invoice?> UpdateInvoiceStatus(int id, InvoiceStatusEnum invoiceStatusEnum);
}