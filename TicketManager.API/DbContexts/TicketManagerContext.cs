using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TicketManager.API.Entities;

namespace TicketManager.API.DbContexts
{
    public class TicketManagerContext : DbContext
    {
        public DbSet<Ticket> Tickets { get; set; }

        public TicketManagerContext(DbContextOptions<TicketManagerContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>()
                .HasData(
                new Ticket
                {
                    TicketId = 1,
                    Description = "Conférence sur l'IA Éthique et Responsable",
                    Status = "Open",
                    Date = new DateTime(2024, 09, 15) 
                },
                new Ticket
                {
                    TicketId = 2,
                    Description = "Atelier sur les Techniques de Cybersécurité Avancées",
                    Status = "Open",
                    Date = new DateTime(2024, 10, 05) 
                },
                new Ticket
                {
                    TicketId = 3,
                    Description = "Séminaire sur les Applications de l'IA dans le Secteur de la Santé",
                    Status = "Closed",
                    Date = new DateTime(2024, 08, 20) 
                },
                new Ticket
                {
                    TicketId = 4,
                    Description = "Forum sur les Menaces Cybernétiques et les Solutions",
                    Status = "Open",
                    Date = new DateTime(2024, 11, 10) 
                },
                new Ticket
                {
                    TicketId = 5,
                    Description = "Expo sur l'Innovation Technologique et le Futur",
                    Status = "Open",
                    Date = new DateTime(2024, 12, 01)
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
