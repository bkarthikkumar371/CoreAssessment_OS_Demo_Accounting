namespace AccountingSystemDemo.CommonApplication.DTOs
{
    /// <summary>
    /// DTO representing customer details used in API communication.
    /// </summary>
    public class CustomerDto
    {
        /// <summary>
        /// Unique identifier of the customer.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Full name of the customer.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Email address of the customer (optional).
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Contact phone number (optional).
        /// </summary>
        public string? PhoneNumber { get; set; }
    }
}
