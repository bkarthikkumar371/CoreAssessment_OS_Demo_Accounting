using AccountingSystemDemo.CommonApplication.DTOs;
using AccountingSystemDemo.CommonApplication.Enums;

/// <summary>
/// Client interface for interacting with external invoice services.
/// </summary>
public interface IInvoiceServiceClient
{
    Task<IEnumerable<InvoiceDto>> GetAllInvoices();
    Task<IEnumerable<InvoiceDto>> GetInvoicesByStatus(InvoiceStatusEnum invoiceStatusEnum);
    Task<InvoiceDto?> GetInvoiceById(int id);
    Task<InvoiceDto?> CreateInvoice(CreateInvoiceDto creatTnvoiceDto);
    Task<InvoiceDto?> UpdateInvoiceStatus(int id, InvoiceStatusEnum invoiceStatusEnum);
}