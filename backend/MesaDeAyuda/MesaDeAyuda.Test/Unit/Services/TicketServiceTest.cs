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
        public async Task CreateTicket_ShouldBeSaveInDB()
        {
            // Arrange (configuración del test)
            var context = GetInMemoryDbContext();
            var service = new TicketService(context);

            var newTicket = new CreateTicketDTO
            {
                Title = "Test de prueba",
                Description = "Probando xUnit",
            };

            // Act (acción que queremos testear)
            var ticket = await service.CreateTicket(newTicket);

            // Assert (verificación de lo esperado)
            var ticketInBD = await context.Tickets.FindAsync(ticket.Id);

            Assert.NotNull(ticketInBD);
            Assert.Equal("Test de prueba", ticketInBD.Title);
        }

        [Fact]
        public async Task GetTicketById_ShouldGetTicketIfExist()
        {
            // Arrange
            // Arrange (configuración del test)
            var context = GetInMemoryDbContext();
            var service = new TicketService(context);

            var newTicket = new CreateTicketDTO
            {
                Title = "Ticket prueba",
                Description = "Probando xUnit",
            };
            var ticketCreated = await service.CreateTicket(newTicket);

            // Act
            var ticketGet = await service.GetTicketById(ticketCreated.Id);

            // Assert
            Assert.NotNull(ticketGet);
            Assert.Equal(ticketCreated.Id, ticketGet.Id);
            Assert.Equal("Ticket prueba", ticketGet.Title);
        }

        [Fact]
        public async Task GetTicketById_ShouldBeNullIfNotExist()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var service = new TicketService(context);

            // Act
            var result = await service.GetTicketById(99999);

            // Assert
            Assert.Null(result);
        }


    }
}
