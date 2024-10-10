using BrokerAPI.DTOs;
using BrokerAPI.Models.Views;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrokerAPI.Services
{
    public interface IBrokerService
    {
        Task<List<BrokerDto>> GetAllBrokersAsync();
        Task<BrokerDto> GetBrokerByIdAsync(int id);
        Task<BrokerDto> AddBrokerAsync(BrokerDto brokerDto);
        Task<BrokerDto> UpdateBrokerAsync(int id, BrokerDto brokerDto);
        Task<bool> DeleteBrokerAsync(int id);
        Task<BrokerDto> LoginAsync(LoginDto loginDto);
    }
}
