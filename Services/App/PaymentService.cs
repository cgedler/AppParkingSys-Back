using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Validators;

namespace Services.App
{
    public class PaymentService : IPaymentService
    {
        private readonly ILogger<PaymentService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public PaymentService(IUnitOfWork unitOfWork, ILogger<PaymentService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        Task<Payment?> IPaymentService.GetPaymentById(int id)
        {
            return _unitOfWork.PaymentRepository.GetByIdAsync(id);
        }
        Task<IEnumerable<Payment>> IPaymentService.GetAll()
        {
            return _unitOfWork.PaymentRepository.GetAllAsync();
        }
        async Task<Payment> IPaymentService.RegisterPayment(Payment payment)
        {
            PaymentValidator validator = new();
            var validationResult = await validator.ValidateAsync(payment);
            if (validationResult.IsValid)
            {
                await _unitOfWork.PaymentRepository.AddAsync(payment);
                _unitOfWork.CompleteAsync().Wait();
            }
            else
            {
                _logger.LogWarning("Inside Register Payment: " + validationResult.Errors.ToString());
                throw new ArgumentException(validationResult.Errors.ToString());
            }
            return payment;
        }

        Task<Payment> IPaymentService.UpdatePayment(int id, Payment payment)
        {
            throw new NotImplementedException();
        }

        Task<Payment> IPaymentService.DeletePayment(int id)
        {
            throw new NotImplementedException();
        }

    }
}
