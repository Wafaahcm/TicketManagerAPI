using TicketManager.API.Models;

public interface ITicketRepository
{
    Task<IEnumerable<TicketDto>> GetAllTicketsAsync(
        string? query = null,
        string? status = null,
        string? sortBy = null,
        string? sortDirection = "asc",
        int? pageNumber = 1,    
        int? pageSize = 100    
    );

    Task<int> GetCount(); 
    Task<TicketDto> GetTicketByIdAsync(int id);
    Task<TicketDto> CreateTicketAsync(TicketForCreationDto ticketDto);
    Task UpdateTicketAsync(TicketForUpdateDto ticketDto);
    Task DeleteTicketAsync(int id);
}
