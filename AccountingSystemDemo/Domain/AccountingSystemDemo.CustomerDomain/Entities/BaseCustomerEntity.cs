namespace AccountingSystemDemo.CustomerDomain.Entities
{
    /// <summary>
    /// Base entity for all customer domain entities.
    /// </summary>
    public class BaseCustomerEntity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the customer entity.
        /// </summary>
        public int Id { get; set; }
    }
}