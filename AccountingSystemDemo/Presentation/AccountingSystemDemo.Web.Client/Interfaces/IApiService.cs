using AccountingSystemDemo.CommonApplication.DTOs;
using AccountingSystemDemo.CommonApplication.Enums;

namespace AccountingSystemDemo.Web.Client.Interfaces
{
    /// <summary>
    /// Abstraction for API service used by the web client.
    /// Handles communication with customer and invoice APIs.
    /// </summary>
    public interface IApiService
    {
        /// <summary>
        /// Retrieves a list of customers, optionally filtered by search string.
        /// </summary>
        /// <param name="searchString">Optional search string to filter customer names.</param>
        /// <returns>List of customer DTOs.</returns>
        Task<List<CustomerDto>> GetCustomers();

        /// <summary>
        /// Retrieves all invoices.
        /// </summary>
        /// <returns>List of invoice DTOs.</returns>
        Task<List<InvoiceDto>> GetAllInvoices();

        /// <summary>
        /// Retrieves invoices filtered by status code.
        /// </summary>
        /// <param name="statusCode">Status code of invoices to retrieve.</param>
        /// <returns>List of invoice DTOs.</returns>
        Task<List<InvoiceDto>> GetAllInvoicesByStatus(int statusCode);

        /// <summary>
        /// Retrieves a single invoice by ID.
        /// </summary>
        /// <param name="id">Invoice ID.</param>
        /// <returns>Invoice DTO or null if not found.</returns>
        Task<InvoiceDto?> GetInvoiceById(int id);

        /// <summary>
        /// Updates the status of an invoice.
        /// </summary>
        /// <param name="id">Invoice ID.</param>
        /// <param name="statusCode">New invoice status.</param>
        /// <returns>Updated invoice DTO or null if update fails.</returns>
        Task<InvoiceDto?> UpdateInvoiceStatus(int id, InvoiceStatusEnum statusCode);

        /// <summary>
        /// Creates a new invoice.
        /// </summary>
        /// <param name="createInvoiceDto">Invoice creation DTO.</param>
        /// <returns>Created invoice DTO.</returns>
        Task<InvoiceDto?> CreateInvoice(CreateInvoiceDto createInvoiceDto);
    }
}