using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Microsoft.Extensions.Logging;
using Services.Validators;

namespace Services.App
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork, ILogger<UserService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        Task<User?> IUserService.GetUserById(int id)
        {
            return _unitOfWork.UserRepository.GetByIdAsync(id);
        }
        Task<User?> IUserService.GetUserByEmail(string email)
        {
            return _unitOfWork.UserRepository.GetUserByEmailAsync(email);
        }
        Task<IEnumerable<User>> IUserService.GetAll()
        {
            return _unitOfWork.UserRepository.GetAllAsync();
        }
        async Task<User> IUserService.RegisterUser(User user)
        {
            UserValidator validator = new();
            var validationResult = await validator.ValidateAsync(user);
            if (validationResult.IsValid)
            {
                user.PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(user.PasswordHash, 13);
                await _unitOfWork.UserRepository.AddAsync(user);
                _unitOfWork.CompleteAsync().Wait();
            }
            else
            {
                _logger.LogWarning("Inside Register User: " + validationResult.Errors.ToString());
                throw new ArgumentException(validationResult.Errors.ToString());
            }
            return user;
        }
        async Task<User> IUserService.UpdateUser(int id, User user)
        {
            UserValidator validator = new();
            var validationResult = await validator.ValidateAsync(user);
            if (!validationResult.IsValid)
            {
                _logger.LogWarning("Inside UpdateUser: " + validationResult.Errors.ToString());
                throw new ArgumentException(validationResult.Errors.ToString());
            }
            else
            {
                var existingUser = await _unitOfWork.UserRepository.GetByIdAsync(id);
                if (existingUser == null)
                {
                    _logger.LogWarning("Inside UpdateUser: Invalid user ID while updating");
                    throw new ArgumentException("Invalid user ID while updating");
                }
                else
                {
                    existingUser.Email=user.Email;
                    existingUser.Role = user.Role;
                    existingUser.PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(user.PasswordHash, 13);
                    _unitOfWork.UserRepository.Update(existingUser); 
                    _unitOfWork.CompleteAsync().Wait();
                }
            }
            return user;
        }
        async Task<User> IUserService.DeleteUser(int id)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(id); 
            if (user == null) throw new ArgumentNullException(nameof(user));
            _unitOfWork.UserRepository.Remove(user);
            _unitOfWork.CompleteAsync().Wait();
            return user;
        }
    }
}
