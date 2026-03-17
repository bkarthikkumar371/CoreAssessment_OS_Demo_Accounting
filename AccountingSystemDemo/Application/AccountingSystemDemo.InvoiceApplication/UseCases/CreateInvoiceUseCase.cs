using AccountingSystemDemo.CommonApplication.DTOs;
using AccountingSystemDemo.InvoiceApplication.Interfaces;
using AccountingSystemDemo.InvoiceDomain.Entities;


/// <summary>
/// Use case for creating a new invoice.
/// </summary>
public class CreateInvoiceUseCase : ICreateInvoiceUseCase
{
    private readonly IInvoiceRepository _invoiceRepository;

    /// <summary>
    /// Initializes a new instance of <see cref="CreateInvoiceUseCase"/>.
    /// </summary>
    /// <param name="invoiceRepository">Injected invoice repository.</param>
    /// <param name="validator">Validator for CreateInvoiceDto.</param>
    public CreateInvoiceUseCase(IInvoiceRepository invoiceRepository)
    {
        _invoiceRepository = invoiceRepository;
    }

    /// <summary>
    /// Executes the use case to create a new invoice.
    /// </summary>
    /// <param name="createInvoiceDto">Invoice creation details.</param>
    
    /// <returns>The created invoice.</returns>
    public async Task<Invoice> ExecuteAsync(CreateInvoiceDto createInvoiceDto)
    {
        var invoice = new Invoice
        {
            CustomerId = createInvoiceDto.CustomerId,
            Amount = createInvoiceDto.Amount
        };

        return await _invoiceRepository.CreateInvoice(invoice);
    }
}