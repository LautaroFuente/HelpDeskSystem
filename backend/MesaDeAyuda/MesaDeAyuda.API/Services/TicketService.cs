using MesaDeAyuda.API.Data;
using MesaDeAyuda.API.DTOs;
using MesaDeAyuda.API.Models;

namespace MesaDeAyuda.API.Services
{
    public class TicketService : ITicketService
    {
        private readonly MesaDeAyudaContext _context;

        public TicketService( MesaDeAyudaContext context) {
            _context = context;        
        }

        public async Task<Ticket> CreateTicket (CreateTicketDTO createTicketDTO)
        {
            var ticket = new Ticket
            {
                Title = createTicketDTO.Title,
                Description = createTicketDTO.Description,
                CreatedDate = DateTime.UtcNow,
                State = "No Hecho"
            };

            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();

            return ticket;
        }

        public async Task<Ticket> GetTicketById(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            return ticket;
        }
    }
}
