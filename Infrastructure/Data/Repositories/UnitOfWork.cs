using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    /// <summary>
    /// manage transactions and persistence of multiple repositories in a single operation
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context; 
        private IUserRepository? _userRepository;
        private ITicketRepository? _ticketRepository;
        private IPriceRepository? _priceRepository;
        private IPaymentRepository? _paymentRepository;
        public UnitOfWork(ApplicationDbContext context, IUserRepository? userRepository, ITicketRepository? ticketRepository, IPriceRepository? priceRepository, IPaymentRepository? paymentRepository)
        {
            _context = context;
            _userRepository = userRepository;
            _ticketRepository = ticketRepository;
            _priceRepository = priceRepository;
            _paymentRepository = paymentRepository;
        }
        public IUserRepository UserRepository 
        {
            get { return _userRepository ??= new UserRepository(_context); }
        }
        public ITicketRepository TicketRepository
        { 
            get { return _ticketRepository ??= new TicketRepository(_context); }
        }
        public IPriceRepository PriceRepository
        { 
            get { return _priceRepository ??= new PriceRepository(_context); }
        }
        public IPaymentRepository PaymentRepository
        {
            get { return _paymentRepository ??= new PaymentRepository(_context); }
        }
        public async Task<int> CompleteAsync()
        { 
            return await _context.SaveChangesAsync(); 
        }
        public void Dispose() 
        { 
            _context.Dispose(); 
        }
    }
}
