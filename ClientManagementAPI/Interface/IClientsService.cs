
namespace ClientManagementAPI.Interface
{
    public interface IClientsService
    {
        Task<List<ClientResponseDto>> GetAllAsync();

        Task<ClientResponseDto?> GetByIdAsync(int id);

        Task<ClientResponseDto> CreateAsync(
            CreateClientDto dto);

        Task<bool> UpdateAsync(
            int id,
            UpdateClientDto dto);

        Task<bool> DeleteAsync(int id);
    }

}



