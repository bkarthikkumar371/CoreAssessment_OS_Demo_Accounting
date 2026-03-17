using AccountingSystemDemo.CommonApplication.DTOs;
using AccountingSystemDemo.InvoiceDomain.Entities;

namespace AccountingSystemDemo.InvoiceApplication.Interfaces
{
    /// <summary>
    /// Use case for creating a new invoice.
    /// </summary>
    public interface ICreateInvoiceUseCase
    {
        /// <summary>
        /// Executes the use case to create an invoice.
        /// </summary>
        /// <param name="createInvoiceDto">Data transfer object containing invoice creation details.</param>
        
        /// <returns>The created invoice.</returns>
        Task<Invoice> ExecuteAsync(CreateInvoiceDto createInvoiceDto);
    }
}