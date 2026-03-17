namespace AccountingSystemDemo.CommonApplication.DTOs
{
    /// <summary>
    /// DTO used to create a new invoice.
    /// </summary>
    public class CreateInvoiceDto
    {
        /// <summary>
        /// Unique identifier of the customer.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Invoice amount in USD.
        /// </summary>
        public decimal Amount { get; set; }
    }
}
