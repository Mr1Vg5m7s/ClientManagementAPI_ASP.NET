using ClientManagementAPI.Data;
using ClientManagementAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClientManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClientsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetById()
        {
            var clients = await _context.Clients.ToListAsync();
            return Ok(clients);
        }
        [HttpPost]
        public async Task<IActionResult> Create(Client client)
        {
            client.RegistrationDate = DateTime.UtcNow;


            _context.Clients.Add(client);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = client.Id }, client);
                
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Client client)
        {
            if(id != client.Id)
            {
                return BadRequest();
            }

            var existingClient = await _context.Clients.FindAsync(id);
            if(existingClient == null)
            {
                return NotFound();
            }

            existingClient.FullName = client.FullName;
            existingClient.Email = client.Email;
            existingClient.Phone = client.Phone;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}