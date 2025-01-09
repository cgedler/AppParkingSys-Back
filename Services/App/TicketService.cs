using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.App
{
    public class TicketService : ITicketService
    {
        Task<Ticket> ITicketService.DeleteTicket(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Ticket>> ITicketService.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<Ticket?> ITicketService.GetTicketById(int id)
        {
            throw new NotImplementedException();
        }

        Task<Ticket> ITicketService.RegisterTicket(Ticket ticket)
        {
            throw new NotImplementedException();
        }

        Task<Ticket> ITicketService.UpdateTicket(int id, Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }
}
