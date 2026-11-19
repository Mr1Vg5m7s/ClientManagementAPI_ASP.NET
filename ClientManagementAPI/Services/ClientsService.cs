using AutoMapper;
using ClientManagementAPI.Data;
using ClientManagementAPI.Interface;
using ClientManagementAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClientManagementAPI.Services
{
    public class ClientsService : IClientsService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ClientsService(
            ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<ClientResponseDto> GetAllAsync(CreateClientDto dto)
        {
            var client = await _context.Clients
                .AsNoTracking()
                .ToListAsync();
            return _mapper.Map<ClientResponseDto>(client);
        }

        public async Task<ClientResponseDto?> GetByIdAsync(int id)
        {
            var client = _context.Clients
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (client == null)
            {
                return null;
            }
            return _mapper.Map<ClientResponseDto>(client);
        }

        public async Task<bool> UpdateAsync(int id, UpdateClientDto dto)
        {
            var client = await _context.Clients.FirstOrDefaultAsync(c => c.Id == id);
            if (client == null)
            {
                return false;
            }

            _mapper.Map(dto, client);
            await _context.SaveChangesAsync();
            return true;

        }
        public async Task<IActionResult> CreateAsync(CreateClientDto dto)
        {
            var client = _mapper.Map<Client>(dto);
            client.RegistrationDate = DateTime.UtcNow;

            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            var responseDto = _mapper.Map<ClientResponseDto>(client);
            return new CreatedAtActionResult(nameof(GetByIdAsync), "Clients", new { id = client.Id }, responseDto);
        }


        public async Task<bool> DeleteAsync(int id)
        {
            var client = await _context.Clients
                .FirstOrDefaultAsync(c => c.Id == id);

            if (client == null)
            {
                return false;
            }

            _context.Clients.Remove(client);

            await _context.SaveChangesAsync();

            return true;
        }

        

        Task<ClientResponseDto> IClientsService.CreateAsync(CreateClientDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<List<ClientResponseDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
