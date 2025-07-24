using MesaDeAyuda.API.Data;
using MesaDeAyuda.API.DTOs;
using MesaDeAyuda.API.Models;
using MesaDeAyuda.API.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace MesaDeAyuda.API.MesaDeAyuda.Test
{
    public class TicketServiceTest
    {
        private MesaDeAyudaContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<MesaDeAyudaContext>()
                .UseInMemoryDatabase(databaseName: "TestDB")
                .Options;

            return new MesaDeAyudaContext(options);
        }

        [Fact]
        public async Task CrearTicket_DeberiaGuardarTicketEnBase()
        {
            // Arrange (configuración del test)
            var context = GetInMemoryDbContext();
            var service = new TicketService(context);

            var nuevoTicket = new CreateTicketDTO
            {
                Title = "Test de prueba",
                Description = "Probando xUnit",
            };

            // Act (acción que queremos testear)
            var ticket = await service.CreateTicket(nuevoTicket);

            // Assert (verificación de lo esperado)
            var ticketEnBase = await context.Tickets.FindAsync(ticket.Id);

            Assert.NotNull(ticketEnBase);
            Assert.Equal("Test de prueba", ticketEnBase.Title);
        }
    }
}
