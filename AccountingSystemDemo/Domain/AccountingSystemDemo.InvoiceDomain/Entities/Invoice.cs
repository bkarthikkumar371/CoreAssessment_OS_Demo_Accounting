using AccountingSystemDemo.CommonApplication.Enums;

namespace AccountingSystemDemo.InvoiceDomain.Entities
{
    /// <summary>
    /// Represents an invoice in the domain layer.
    /// </summary>
    public class Invoice : BaseInvoiceEntity
    {
        /// <summary>
        /// Gets or sets the ID of the customer associated with the invoice.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the total amount of the invoice.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the status of the invoice.
        /// Stored as <see cref="InvoiceStatusEnum"/>.
        /// </summary>
        public InvoiceStatusEnum Status { get; set; }
    }
}