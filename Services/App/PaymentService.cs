using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.App
{
    public class PaymentService : IPaymentService
    {
        Task<Payment> IPaymentService.DeletePayment(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Payment>> IPaymentService.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<Payment?> IPaymentService.GetPaymentById(int id)
        {
            throw new NotImplementedException();
        }

        Task<Payment> IPaymentService.RegisterPayment(Payment payment)
        {
            throw new NotImplementedException();
        }

        Task<Payment> IPaymentService.UpdatePayment(int id, Payment payment)
        {
            throw new NotImplementedException();
        }
    }
}
