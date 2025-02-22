﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface IPaymentService
    {
        Task<Payment?> GetPaymentById(int id);
        Task<IEnumerable<Payment>> GetAll();
        Task<Payment> RegisterPayment(Payment payment);
        Task<Payment> UpdatePayment(int id, Payment payment);
        Task<Payment> DeletePayment(int id);
    }
}
