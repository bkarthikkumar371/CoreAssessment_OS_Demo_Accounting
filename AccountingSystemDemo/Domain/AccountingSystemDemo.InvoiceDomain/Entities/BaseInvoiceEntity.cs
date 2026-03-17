namespace AccountingSystemDemo.InvoiceDomain.Entities
{
    /// <summary>
    /// Base entity for all invoice domain entities.
    /// </summary>
    public class BaseInvoiceEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the invoice entity.
        /// </summary>
        public int Id { get; set; }
    }
}