using BrokerAPI.DTOs;
using BrokerAPI.Models.Views;
using BrokerAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrokerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrokersController : ControllerBase
    {
        private readonly IBrokerService _service;

        public BrokersController(IBrokerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<BrokerDto>>> GetAll()
        {
            var brokers = await _service.GetAllBrokersAsync();
            return Ok(brokers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BrokerDto>> GetById(int id)
        {
            var broker = await _service.GetBrokerByIdAsync(id);
            if (broker == null) return NotFound();
            return Ok(broker);
        }

        [HttpPost]
        public async Task<ActionResult<BrokerDto>> Create([FromBody] BrokerDto brokerDto)
        {
            var createdBroker = await _service.AddBrokerAsync(brokerDto);
            return CreatedAtAction(nameof(GetById), new { id = createdBroker.BrokerId }, createdBroker);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BrokerDto>> Update(int id, [FromBody] BrokerDto brokerDto)
        {
            var updatedBroker = await _service.UpdateBrokerAsync(id, brokerDto);
            if (updatedBroker == null) return NotFound();
            return Ok(updatedBroker);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteBrokerAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }

        [HttpPost("login")]
        public async Task<ActionResult<BrokerDto>> Login([FromBody] LoginDto loginDto)
        {
            var user = await _service.LoginAsync(loginDto);
            return user == null ? Unauthorized() : Ok(user);
        }
    }
}
