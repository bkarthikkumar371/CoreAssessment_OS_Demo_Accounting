using AccountingSystemDemo.CommonApplication.Enums;
using AccountingSystemDemo.InvoiceDomain.Entities;

/// <summary>
/// Use case for updating the status of an invoice.
/// </summary>
public class UpdateInvoiceStatusUseCase : IUpdateInvoiceStatusUseCase
{
    private readonly IInvoiceRepository _invoiceRepository;
    /// <summary>
    /// Initializes a new instance of <see cref="UpdateInvoiceStatusUseCase"/>.
    /// </summary>
    /// <param name="invoiceRepository">Injected invoice repository.</param>
    /// <param name="idValidator">Validator for invoice ID.</param>
    /// <param name="statusValidator">Validator for invoice status enum.</param>
    public UpdateInvoiceStatusUseCase(
        IInvoiceRepository invoiceRepository)
    {
        _invoiceRepository = invoiceRepository;
    }

    /// <summary>
    /// Executes the use case to update the status of an invoice.
    /// </summary>
    /// <param name="id">ID of the invoice to update.</param>
    /// <param name="invoiceStatusEnum">The new status to set.</param>
    /// <returns>The updated invoice DTO if successful; otherwise, null.</returns>
    public async Task<Invoice?> ExecuteAsync(int id, InvoiceStatusEnum invoiceStatusEnum)
    {
        var invoiceDto = await _invoiceRepository.GetInvoiceById(id);
        if (invoiceDto is null)
            return null;

        // Business rules: allowed transitions
        bool isValidTransition =
            ((invoiceStatusEnum == InvoiceStatusEnum.Approved || invoiceStatusEnum == InvoiceStatusEnum.Rejected)
                && invoiceDto.Status == InvoiceStatusEnum.Submitted)
            || (invoiceStatusEnum == InvoiceStatusEnum.Paid
                && invoiceDto.Status == InvoiceStatusEnum.Approved);

        if (!isValidTransition)
            return null;

        return await _invoiceRepository.UpdateInvoiceStatus(id, invoiceStatusEnum);
    }
}