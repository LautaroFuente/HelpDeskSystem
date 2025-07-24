using MesaDeAyuda.API.Models;
using Microsoft.EntityFrameworkCore;

namespace MesaDeAyuda.API.Data
{
    public class MesaDeAyudaContext : DbContext
    {
        public MesaDeAyudaContext(DbContextOptions<MesaDeAyudaContext> options)
            : base(options)
        {
        }

        public DbSet<Ticket> Tickets { get; set; }
   
    }
}
