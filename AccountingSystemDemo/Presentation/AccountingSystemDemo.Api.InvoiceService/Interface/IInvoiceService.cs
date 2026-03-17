using AccountingSystemDemo.CommonApplication.DTOs;
using AccountingSystemDemo.CommonApplication.Enums;

namespace AccountingSystemDemo.Api.InvoiceService.Interface
{
    /// <summary>
    /// Application service interface for managing invoices.
    /// </summary>
    public interface IInvoiceService
    {
        /// <summary>
        /// Retrieves all invoices.
        /// </summary>
        
        /// <returns>List of <see cref="InvoiceDto"/>.</returns>
        Task<List<InvoiceDto>> GetAllInvoices();

        /// <summary>
        /// Retrieves a single invoice by its ID.
        /// </summary>
        /// <param name="id">Invoice ID.</param>
        
        /// <returns>The <see cref="InvoiceDto"/> if found; otherwise, null.</returns>
        Task<InvoiceDto?> GetInvoiceById(int id);

        /// <summary>
        /// Creates a new invoice.
        /// </summary>
        /// <param name="dto">Invoice creation details.</param>
        
        /// <returns>The created <see cref="InvoiceDto"/>.</returns>
        Task<InvoiceDto> CreateInvoice(CreateInvoiceDto dto);

        /// <summary>
        /// Updates the status of an invoice.
        /// </summary>
        /// <param name="id">Invoice ID.</param>
        /// <param name="invoiceStatusEnum">New status to set.</param>
        
        /// <returns>The updated <see cref="InvoiceDto"/> if successful; otherwise, null.</returns>
        Task<InvoiceDto?> UpdateInvoiceStatus(int id, InvoiceStatusEnum invoiceStatusEnum);

        /// <summary>
        /// Retrieves invoices filtered by their status.
        /// </summary>
        /// <param name="invoiceStatusEnum">Status filter.</param>
        
        /// <returns>List of <see cref="InvoiceDto"/> with the specified status.</returns>
        Task<List<InvoiceDto>> GetInvoicesByStatus(InvoiceStatusEnum invoiceStatusEnum);
    }
}