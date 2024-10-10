using BrokerAPI.DTOs;
using BrokerAPI.Models;
using BrokerAPI.Models.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrokerAPI.Repositories
{
    public interface IBrokerRepository
    {
        Task<List<Broker>> GetAllBrokersAsync();
        Task<Broker> GetBrokerByIdAsync(int id);
        Task<Broker> AddBrokerAsync(Broker broker);
        Task<Broker> UpdateBrokerAsync(Broker broker);
        Task<bool> DeleteBrokerAsync(int id);

        Task<BrokerDto> LoginAsync(string username, string password);
    }
}
