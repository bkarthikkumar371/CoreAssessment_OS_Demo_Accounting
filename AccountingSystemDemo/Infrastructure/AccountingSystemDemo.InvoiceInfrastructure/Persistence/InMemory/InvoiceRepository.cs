using AccountingSystemDemo.CommonApplication.Enums;
using AccountingSystemDemo.InvoiceDomain.Entities;

namespace AccountingSystemDemo.InvoiceInfrastructure.Persistence.InMemory
{
    /// <summary>
    /// In-memory repository for managing invoice data.
    /// </summary>
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly List<Invoice> _invoices;

        /// <summary>
        /// Initializes a new instance of <see cref="InvoiceRepository"/> with sample data.
        /// </summary>
        public InvoiceRepository()
        {
            _invoices = new List<Invoice>
            {
                new Invoice { Id = 1, CustomerId = 1, Amount = 10, Status = InvoiceStatusEnum.Submitted },
                new Invoice { Id = 2, CustomerId = 2, Amount = 20, Status = InvoiceStatusEnum.Approved },
                new Invoice { Id = 3, CustomerId = 3, Amount = 30, Status = InvoiceStatusEnum.Rejected },
                new Invoice { Id = 4, CustomerId = 4, Amount = 40, Status = InvoiceStatusEnum.Paid },
                new Invoice { Id = 5, CustomerId = 5, Amount = 50, Status = InvoiceStatusEnum.Submitted },

            };
        }

        public async Task<Invoice> CreateInvoice(Invoice invoice)
        {

            invoice.Id = _invoices.Count + 1;
            invoice.Status = InvoiceStatusEnum.Submitted;

            _invoices.Add(invoice);

            return await Task.FromResult(invoice);
        }

        public async Task<Invoice?> GetInvoiceById(int id)
        {

            var invoice = _invoices.FirstOrDefault(x => x.Id == id);
            if (invoice is null) return null;

            return await Task.FromResult(invoice);
        }

        public async Task<List<Invoice>> GetInvoicesByStatus(InvoiceStatusEnum invoiceStatusEnum)
        {

            var invoices = _invoices
                .Where(x => x.Status == invoiceStatusEnum)
                .ToList();

            return await Task.FromResult(invoices);
        }

        public async Task<List<Invoice>> GetAllInvoices()
        {

            return await Task.FromResult(_invoices);
        }

        public async Task<Invoice?> UpdateInvoiceStatus(int id, InvoiceStatusEnum invoiceStatusEnum)
        {
            var invoice = _invoices.FirstOrDefault(x => x.Id == id);
            if (invoice is null) return null;

            invoice.Status = invoiceStatusEnum;

            return await Task.FromResult(invoice);
        }

    }
}