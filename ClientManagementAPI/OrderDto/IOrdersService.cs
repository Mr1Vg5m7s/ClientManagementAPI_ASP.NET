using ClientManagementAPI.DTOs;

public interface IOrdersService
{
    Task<List<OrderResponseDto>> GetAllAsync();

    Task<OrderResponseDto?> GetByIdAsync(int id);

    Task<OrderResponseDto?> CreateAsync(
        CreateOrderDto dto);
}
