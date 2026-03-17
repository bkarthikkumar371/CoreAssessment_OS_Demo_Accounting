using AccountingSystemDemo.CustomerApplication.Interfaces;
using AccountingSystemDemo.CustomerDomain.Entities;

namespace AccountingSystemDemo.CustomerInfrastructure.Persistence.InMemory
{
    /// <summary>
    /// In-memory repository for managing customer data.
    /// </summary>
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> _customers;

        /// <summary>
        /// Initializes a new instance of <see cref="CustomerRepository"/> with sample data.
        /// </summary>
        public CustomerRepository()
        {
            _customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "AAAAA", Email = "aa.aa@gmail.com", PhoneNumber = "1111111111" },
                new Customer { Id = 2, Name = "BBBBB", Email = "bb.bb@gmail.com", PhoneNumber = "2222222222" },
                new Customer { Id = 3, Name = "CCCCC", Email = "cc.cc@gmail.com", PhoneNumber = "3333333333" },
                new Customer { Id = 4, Name = "DDDDD", Email = "dd.dd@gmail.com", PhoneNumber = "4444444444" },
                new Customer { Id = 5, Name = "EEEEE", Email = "ee.ee@gmail.com", PhoneNumber = "5555555555" }
            };
        }

        /// <summary>
        /// Retrieves customers filtered by name. Case-insensitive search.
        /// </summary>
        
        /// <returns>A collection of <see cref="Customer"/>.</returns>
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await Task.FromResult(_customers);
        }
    }
}