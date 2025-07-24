using MesaDeAyuda.API.DTOs;
using MesaDeAyuda.API.Models;
using MesaDeAyuda.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MesaDeAyuda.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromBody] CreateTicketDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var ticket = await _ticketService.CreateTicket(dto);
            return CreatedAtAction(nameof(GetTicketById), new { id = ticket.Id }, ticket);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicketById(int id)
        {
            var ticket = await _ticketService.GetTicketById(id);
            if (ticket == null)
            {
                return NotFound();
            }

            return Ok(ticket);
        }
    }
}
