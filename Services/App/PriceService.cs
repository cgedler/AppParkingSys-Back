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
    public class PriceService : IPriceService
    {
        private readonly ILogger<PriceService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public PriceService(IUnitOfWork unitOfWork, ILogger<PriceService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        Task<Price?> IPriceService.GetPriceById(int id)
        {
            return _unitOfWork.PriceRepository.GetByIdAsync(id);
        }
        Task<IEnumerable<Price>> IPriceService.GetAll()
        {
            return _unitOfWork.PriceRepository.GetAllAsync();
        }
        async Task<Price> IPriceService.RegisterPrice(Price price)
        {
            PriceValidator validator = new();
            var validationResult = await validator.ValidateAsync(price);
            if (validationResult.IsValid)
            {
                await _unitOfWork.PriceRepository.AddAsync(price);
                _unitOfWork.CompleteAsync().Wait();
            }
            else
            {
                _logger.LogWarning("Inside Register Price: " + validationResult.Errors.ToString());
                throw new ArgumentException(validationResult.Errors.ToString());
            }
            return price;
        }
        async Task<Price> IPriceService.UpdatePrice(int id, Price price)
        {
            PriceValidator validator = new();
            var validationResult = await validator.ValidateAsync(price);
            if (!validationResult.IsValid)
            {
                _logger.LogWarning("Inside Update Price: " + validationResult.Errors.ToString());
                throw new ArgumentException(validationResult.Errors.ToString());
            }
            else
            {
                var existingPrice = await _unitOfWork.PriceRepository.GetByIdAsync(id);
                if (existingPrice == null)
                {
                    _logger.LogWarning("Inside Update Price: Invalid price ID while updating");
                    throw new ArgumentException("Invalid price ID while updating");
                }
                else
                {
                    existingPrice.Amount = price.Amount;
                    _unitOfWork.PriceRepository.Update(existingPrice);
                    _unitOfWork.CompleteAsync().Wait();
                }
            }
            return price;
        }
        async Task<Price> IPriceService.DeletePrice(int id)
        {
            var price = await _unitOfWork.PriceRepository.GetByIdAsync(id);
            if (price == null) throw new ArgumentNullException(nameof(price));
            _unitOfWork.PriceRepository.Remove(price);
            _unitOfWork.CompleteAsync().Wait();
            return price;
        }
    }
}
