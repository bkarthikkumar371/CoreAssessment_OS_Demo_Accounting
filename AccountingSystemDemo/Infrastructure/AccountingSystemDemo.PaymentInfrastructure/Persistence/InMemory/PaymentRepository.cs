using AccountingSystemDemo.PaymentApplication.DTOs;
using AccountingSystemDemo.PaymentApplication.Interfaces;
using AccountingSystemDemo.PaymentDomain.Entities;

namespace AccountingSystemDemo.PaymentInfrastructure.Persistence.InMemory
{
    public class PaymentRepository : IPaymentRepository
    {
        private List<Payment> _Payments;

        public PaymentRepository()
        {
            _Payments = new List<Payment>
            {
                new Payment { Id = 1, InvoiceId = 1, Amount = 5, PaymentDate = DateTime.Now.AddDays(-20) },
                new Payment { Id = 2, InvoiceId = 1, Amount = 5, PaymentDate = DateTime.Now.AddDays(-18) },

                new Payment { Id = 3, InvoiceId = 2, Amount = 10, PaymentDate = DateTime.Now.AddDays(-25) },
                new Payment { Id = 4, InvoiceId = 2, Amount = 10, PaymentDate = DateTime.Now.AddDays(-22) },

                new Payment { Id = 5, InvoiceId = 3, Amount = 15, PaymentDate = DateTime.Now.AddDays(-30) },
                new Payment { Id = 6, InvoiceId = 3, Amount = 15, PaymentDate = DateTime.Now.AddDays(-28) },

                new Payment { Id = 7, InvoiceId = 4, Amount = 20, PaymentDate = DateTime.Now.AddDays(-12) },
                new Payment { Id = 8, InvoiceId = 4, Amount = 20, PaymentDate = DateTime.Now.AddDays(-10) },

                new Payment { Id = 9, InvoiceId = 5, Amount = 25, PaymentDate = DateTime.Now.AddDays(-40) },
                new Payment { Id = 10, InvoiceId = 5, Amount = 25, PaymentDate = DateTime.Now.AddDays(-35) },

                new Payment { Id = 11, InvoiceId = 6, Amount = 30, PaymentDate = DateTime.Now.AddDays(-15) },
                new Payment { Id = 12, InvoiceId = 6, Amount = 30, PaymentDate = DateTime.Now.AddDays(-13) },

                new Payment { Id = 13, InvoiceId = 7, Amount = 35, PaymentDate = DateTime.Now.AddDays(-50) },
                new Payment { Id = 14, InvoiceId = 7, Amount = 35, PaymentDate = DateTime.Now.AddDays(-48) },

                new Payment { Id = 15, InvoiceId = 8, Amount = 40, PaymentDate = DateTime.Now.AddDays(-5) },
                new Payment { Id = 16, InvoiceId = 8, Amount = 40, PaymentDate = DateTime.Now.AddDays(-3) },

                new Payment { Id = 17, InvoiceId = 9, Amount = 45, PaymentDate = DateTime.Now.AddDays(-60) },
                new Payment { Id = 18, InvoiceId = 9, Amount = 45, PaymentDate = DateTime.Now.AddDays(-58) },

                new Payment { Id = 19, InvoiceId = 10, Amount = 50, PaymentDate = DateTime.Now.AddDays(-7) },
                new Payment { Id = 20, InvoiceId = 10, Amount = 50, PaymentDate = DateTime.Now.AddDays(-6) },

                new Payment { Id = 21, InvoiceId = 11, Amount = 55, PaymentDate = DateTime.Now.AddDays(-33) },
                new Payment { Id = 22, InvoiceId = 11, Amount = 55, PaymentDate = DateTime.Now.AddDays(-31) },

                new Payment { Id = 23, InvoiceId = 12, Amount = 60, PaymentDate = DateTime.Now.AddDays(-14) },
                new Payment { Id = 24, InvoiceId = 12, Amount = 60, PaymentDate = DateTime.Now.AddDays(-12) },

                new Payment { Id = 25, InvoiceId = 13, Amount = 65, PaymentDate = DateTime.Now.AddDays(-90) },
                new Payment { Id = 26, InvoiceId = 13, Amount = 65, PaymentDate = DateTime.Now.AddDays(-88) },

                new Payment { Id = 27, InvoiceId = 14, Amount = 70, PaymentDate = DateTime.Now.AddDays(-2) },
                new Payment { Id = 28, InvoiceId = 14, Amount = 70, PaymentDate = DateTime.Now.AddDays(-1) },

                new Payment { Id = 29, InvoiceId = 15, Amount = 75, PaymentDate = DateTime.Now.AddDays(-120) },
                new Payment { Id = 30, InvoiceId = 15, Amount = 75, PaymentDate = DateTime.Now.AddDays(-118) },

                new Payment { Id = 31, InvoiceId = 16, Amount = 80, PaymentDate = DateTime.Now.AddDays(-16) },
                new Payment { Id = 32, InvoiceId = 16, Amount = 80, PaymentDate = DateTime.Now.AddDays(-14) },

                new Payment { Id = 33, InvoiceId = 17, Amount = 85, PaymentDate = DateTime.Now.AddDays(-45) },
                new Payment { Id = 34, InvoiceId = 17, Amount = 85, PaymentDate = DateTime.Now.AddDays(-43) },

                new Payment { Id = 35, InvoiceId = 18, Amount = 90, PaymentDate = DateTime.Now.AddDays(-8) },
                new Payment { Id = 36, InvoiceId = 18, Amount = 90, PaymentDate = DateTime.Now.AddDays(-7) },

                new Payment { Id = 37, InvoiceId = 19, Amount = 95, PaymentDate = DateTime.Now.AddDays(-27) },
                new Payment { Id = 38, InvoiceId = 19, Amount = 95, PaymentDate = DateTime.Now.AddDays(-25) },

                new Payment { Id = 39, InvoiceId = 20, Amount = 100, PaymentDate = DateTime.Now.AddDays(-3) },
                new Payment { Id = 40, InvoiceId = 20, Amount = 100, PaymentDate = DateTime.Now.AddDays(-2) }
          };
        }

        public async Task<IEnumerable<Payment>> GetPaymentsByName(string PaymentName)
        {
            if (string.IsNullOrWhiteSpace(PaymentName)) return await Task.FromResult(_Payments);
            return _Payments.Where(c => c.Name.Contains(PaymentName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
