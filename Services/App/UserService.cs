using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;

namespace Services.App
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        Task<User?> IUserService.GetUserById(int id)
        {
            return _unitOfWork.UserRepository.GetByIdAsync(id);
        }

        Task<User?> IUserService.GetUserByEmail(string email)
        {
            return _unitOfWork.UserRepository.GetUserByEmailAsync(email);
        }

        void IUserService.RegisterUser(User user)
        {
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            _unitOfWork.UserRepository.AddAsync(user);
            _unitOfWork.CompleteAsync().Wait();
        }

        void IUserService.UpdateUser(User user)
        {
            _unitOfWork.UserRepository.Update(user);
            _unitOfWork.CompleteAsync().Wait();
        }

        void IUserService.DeleteUser(User user)
        {
            _unitOfWork.UserRepository.Remove(user);
            _unitOfWork.CompleteAsync().Wait();
        }

       
    }
}
