namespace AccountingSystemDemo.CustomerDomain.Entities
{
    /// <summary>
    /// Represents a customer in the domain layer.
    /// </summary>
    public class Customer : BaseCustomerEntity
    {
        /// <summary>
        /// Gets or sets the customer's name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the customer's email address.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Gets or sets the customer's phone number.
        /// </summary>
        public string? PhoneNumber { get; set; }
    }
}