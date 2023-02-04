using Diagnostyka.Application.Common.Interfaces;
using Diagnostyka.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Diagnostyka.Infrastructure.Persistance
{
    public class DiagnostykaDbContext : DbContext, IDiagnostykaDbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Kolor> Kolory { get; set; }

        public DiagnostykaDbContext(DbContextOptions<DiagnostykaDbContext> options) : base(options) { }
    }
}
