using AccountingSystemDemo.CommonApplication.Enums;

namespace AccountingSystemDemo.CommonApplication.DTOs
{
    /// <summary>
    /// DTO representing invoice details exchanged between layers.
    /// </summary>
    public class InvoiceDto
    {
        /// <summary>
        /// Unique identifier of the invoice.
        /// </summary>
        public int InvoiceId { get; set; }

        /// <summary>
        /// Identifier of the associated customer.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Total invoice amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Current status of the invoice (e.g., Pending, Paid, Cancelled).
        /// </summary>
        public InvoiceStatusEnum Status { get; set; }
    }
}
