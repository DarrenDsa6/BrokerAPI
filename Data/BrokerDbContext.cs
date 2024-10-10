using Microsoft.EntityFrameworkCore;
using BrokerAPI.Models;
using BrokerAPI.Models.Domain;

namespace BrokerAPI.Data
{
    public class BrokerDbContext : DbContext
    {
        public BrokerDbContext(DbContextOptions<BrokerDbContext> options) : base(options) { }

        public DbSet<Broker> Brokers { get; set; }
    }
}
