using DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data.Context;

public class Context : DbContext
{
    internal DbSet<Ticket> Tickets => Set<Ticket>();
    internal DbSet<Developer> Developers => Set<Developer>();
    internal DbSet<Department> Departments => Set<Department>();
    internal DbSet<DeveloperTicket> DevelopersTickets => Set<DeveloperTicket>();



    public Context(DbContextOptions<Context> options):base(options)
    {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DeveloperTicket>()
            .HasKey(e => new { e.TicketId, e.DeveloperId });

        base.OnModelCreating(modelBuilder);
    }
}
