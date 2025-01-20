using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface ITicketService
    {
        Task<Ticket?> GetTicketById(int id);
        Task<IEnumerable<Ticket>> GetAll();
        Task<IEnumerable<Ticket>> GetToPay();
        Task<Ticket> RegisterTicket(Ticket ticket);
        Task<Ticket> UpdateTicket(int id, Ticket ticket);
        Task<Ticket> DeleteTicket(int id);
    }
}
