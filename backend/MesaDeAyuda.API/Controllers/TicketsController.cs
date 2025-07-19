using MesaDeAyuda.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace MesaDeAyuda.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketsController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateTicket([FromBody] Ticket ticket)
        {
            // For now just return the ticket as confirmation
            return Created("", ticket);
        }
    }
}
