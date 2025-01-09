using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Infrastructure.Data.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.App
{
    public class TicketService : ITicketService
    {
        private readonly ILogger<TicketService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public TicketService(IUnitOfWork unitOfWork, ILogger<TicketService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        Task<Ticket> ITicketService.DeleteTicket(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Ticket>> ITicketService.GetAll()
        {
            return _unitOfWork.TicketRepository.GetAllAsync(); ;
        }

        Task<Ticket?> ITicketService.GetTicketById(int id)
        {
            return _unitOfWork.TicketRepository.GetByIdAsync(id);
        }

        async Task<Ticket> ITicketService.RegisterTicket(Ticket ticket)
        {
            await _unitOfWork.TicketRepository.AddAsync(ticket);
            _unitOfWork.CompleteAsync().Wait();
            return ticket;
        }

        Task<Ticket> ITicketService.UpdateTicket(int id, Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }
}
