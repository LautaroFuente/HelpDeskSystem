using MesaDeAyuda.API.DTOs;
using MesaDeAyuda.API.Models;

namespace MesaDeAyuda.API.Services
{
    public interface ITicketService
    {
        Task<Ticket> CreateTicket(CreateTicketDTO createTicketDTO);

        Task<Ticket> GetTicketById(int id);
    }
}
