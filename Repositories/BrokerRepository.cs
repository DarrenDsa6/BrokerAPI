using BrokerAPI.Data;
using BrokerAPI.DTOs;
using BrokerAPI.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrokerAPI.Repositories
{
    public class BrokerRepository : IBrokerRepository
    {
        private readonly BrokerDbContext _context;

        public BrokerRepository(BrokerDbContext context)
        {
            _context = context;
        }

        public async Task<List<Broker>> GetAllBrokersAsync() => await _context.Brokers.ToListAsync();

        public async Task<Broker> GetBrokerByIdAsync(int id) => await _context.Brokers.FindAsync(id);

        public async Task<Broker> AddBrokerAsync(Broker broker)
        {
            await _context.Brokers.AddAsync(broker);
            await _context.SaveChangesAsync();
            return broker;
        }

        public async Task<Broker> UpdateBrokerAsync(Broker broker)
        {
            _context.Brokers.Update(broker);
            await _context.SaveChangesAsync();
            return broker;
        }

        public async Task<bool> DeleteBrokerAsync(int id)
        {
            var broker = await GetBrokerByIdAsync(id);
            if (broker == null) return false;

            _context.Brokers.Remove(broker);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<BrokerDto> LoginAsync(string username, string password)
        {
            // Fetch the broker by username
            var broker = await _context.Brokers
                .FirstOrDefaultAsync(b => b.UserName == username);

            // Validate the password (ensure you hash the password in a real application)
            if (broker != null && broker.Password == password) // Use a hashing mechanism here
            {
                return new BrokerDto
                {
                    BrokerId = broker.BrokerId,
                    Name = broker.Name,
                    UserName = broker.UserName,
                    Password = broker.Password,
                    ContactNumber = broker.ContactNumber,
                    Pincode = broker.Pincode,
                    Address = broker.Address,
                    AdhaarCard = broker.AdhaarCard
                };
            }

            return null;
        }
    }
}
