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
        Task<IEnumerable<Ticket>> ITicketService.GetToPay()
        {
            return _unitOfWork.TicketRepository.FindAsync(t => t.ExitTime == null); ;
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
        async Task<Ticket> ITicketService.UpdateTicket(int id, Ticket ticket)
        {
            var existingTicket = await _unitOfWork.TicketRepository.GetByIdAsync(id);
            if (existingTicket == null)
            {
                _logger.LogWarning("Inside Update Ticket: Invalid ticket ID while updating");
                throw new ArgumentException("Invalid ticket ID while updating");
            }
            else
            {
                existingTicket.ExitTime = ticket.ExitTime;
                _unitOfWork.TicketRepository.Update(existingTicket);
                _unitOfWork.CompleteAsync().Wait();
            }
            return ticket;
        }
    }
}
