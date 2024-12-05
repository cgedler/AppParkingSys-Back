using AppParkingSys_Back.Core.Entities;
using AppParkingSys_Back.Core.Interfaces;
using AppParkingSys_Back.Core.Interfaces.Repositories;
using AppParkingSys_Back.Core.Interfaces.Services;
using AppParkingSys_Back.Infrastructure.Data.Repositories;
using AppParkingSys_Back.Services.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppParkingSys_Back.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserRepository _userRepository;
        public UserService(IUnitOfWork unitOfWork, UserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task<User> CreateUser(User newUser)
        {
            UserValidator validator = new();

            var validationResult = await validator.ValidateAsync(newUser);
            if (validationResult.IsValid)
            {
                await _unitOfWork.UserRepository.AddAsync(newUser);
                await _unitOfWork.CommitAsync();
            }
            else
            {
                throw new ArgumentException(validationResult.Errors.ToString());
            }

            return newUser;
        }

        public async Task DeleteUser(int UserId)
        {
            User User = await _unitOfWork.UserRepository.GetByIdAsync(UserId);
            _unitOfWork.UserRepository.Remove(User);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await _unitOfWork.UserRepository.GetAllAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _unitOfWork.UserRepository.GetByIdAsync(id);
        }

        public async Task<User> UpdateUser(int UserToBeUpdatedId, User newUserValues)
        {
            UserValidator UserValidator = new();

            var validationResult = await UserValidator.ValidateAsync(newUserValues);
            if (!validationResult.IsValid)
                throw new ArgumentException(validationResult.Errors.ToString());

            User UserToBeUpdated = await _unitOfWork.UserRepository.GetByIdAsync(UserToBeUpdatedId);

            if (UserToBeUpdated == null)
                throw new ArgumentException("Invalid User ID while updating");

            UserToBeUpdated.Name = newUserValues.Name;
            UserToBeUpdated.Email = newUserValues.Email;
            UserToBeUpdated.Password = newUserValues.Password;
            UserToBeUpdated.Role = newUserValues.Role;

            await _unitOfWork.CommitAsync();

            return await _unitOfWork.UserRepository.GetByIdAsync(UserToBeUpdatedId);
        }

        User IUserService.GetUserByEmail(string email)
        {
            return _userRepository.GetUserByEmailAsync(email);
        }
    }
}
