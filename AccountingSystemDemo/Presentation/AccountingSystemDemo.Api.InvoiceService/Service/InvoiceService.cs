using AccountingSystemDemo.Api.InvoiceService.Interface;
using AccountingSystemDemo.CommonApplication.DTOs;
using AccountingSystemDemo.CommonApplication.Enums;
using AccountingSystemDemo.InvoiceDomain.Entities;

namespace AccountingSystemDemo.Api.InvoiceService.Service
{
    /// <summary>
    /// Application service implementation for managing invoices.
    /// </summary>
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        /// <summary>
        /// Initializes a new instance of <see cref="InvoiceService"/>.
        /// </summary>
        /// <param name="invoiceRepository">Injected invoice repository.</param>
        public InvoiceService(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public InvoiceDto MapToDto(Invoice invoice)
        {
            return new InvoiceDto { 
                InvoiceId = invoice.Id,
                CustomerId = invoice.CustomerId,
                Amount = invoice.Amount,
                Status = invoice.Status
            };
        }

        /// <summary>
        /// Asynchronously retrieves all invoices as data transfer objects.
        /// </summary>
        /// <returns>A list of <see cref="InvoiceDto"/> objects representing all invoices. Returns an empty list if no invoices
        /// are found.</returns>
        public async Task<List<InvoiceDto>> GetAllInvoices()
        {
            var invoiceDtos = (await _invoiceRepository.GetAllInvoices()).Select(x => MapToDto(x)).ToList();
            return invoiceDtos ?? new List<InvoiceDto>();
        }

        /// <summary>
        /// Asynchronously retrieves invoices filtered by their status as data transfer objects.
        /// </summary>
        /// <param name="invoiceStatusEnum"></param>
        /// <returns></returns>
        public async Task<List<InvoiceDto>> GetInvoicesByStatus(InvoiceStatusEnum invoiceStatusEnum)
        {
            var invoiceDtos = (await _invoiceRepository.GetInvoicesByStatus(invoiceStatusEnum)).Select(x => MapToDto(x)).ToList();
            return invoiceDtos ?? new List<InvoiceDto>();
        }

        /// <summary>
        /// Asynchronously retrieves a single invoice by its unique identifier as a data transfer object.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<InvoiceDto?> GetInvoiceById(int id)
        {
            var result = await _invoiceRepository.GetInvoiceById(id);
            return result is not null ? MapToDto(result) : null;
        }

        /// <summary>
        /// Asynchronously creates a new invoice based on the provided data transfer object and returns the created invoice as a data transfer object.
        /// </summary>
        /// <param name="createInvoiceDto"></param>
        /// <returns></returns>
        public async Task<InvoiceDto> CreateInvoice(CreateInvoiceDto createInvoiceDto)
        {
            var invoice = new Invoice
            {
                CustomerId = createInvoiceDto.CustomerId,
                Amount = createInvoiceDto.Amount
            };
            var result = await _invoiceRepository.CreateInvoice(invoice);
            return result is not null ? MapToDto(result) : new InvoiceDto();
        }

        /// <summary>
        /// Asynchronously updates the status of an existing invoice identified by its unique identifier and returns the updated invoice as a data transfer object. If the invoice is not found, it returns null.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="invoiceStatusEnum"></param>
        /// <returns></returns>
        public async Task<InvoiceDto?> UpdateInvoiceStatus(int id, InvoiceStatusEnum invoiceStatusEnum = default)
        {
            var result = await _invoiceRepository.UpdateInvoiceStatus(id, invoiceStatusEnum);
            return result is not null ? MapToDto(result) : null;
        }
    }
}