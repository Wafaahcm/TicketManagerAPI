using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TicketManager.API.DbContexts;
using TicketManager.API.Entities;
using TicketManager.API.Models;

namespace TicketManager.API.Services
{
    public class TicketRepository : ITicketRepository
    {
        private readonly TicketManagerContext _context;
        private readonly IMapper _mapper;

        public TicketRepository(TicketManagerContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TicketDto>> GetAllTicketsAsync(
            string? query = null,
            string? status = null,
            string? sortBy = null,
            string? sortDirection = "asc",
            int? pageNumber = 1, 
            int? pageSize = 100  
 )
        {
            var ticketsQuery = _context.Tickets.AsQueryable();

            // Filtering
            if (!string.IsNullOrWhiteSpace(query))
            {
                ticketsQuery = ticketsQuery.Where(t => t.Description.Contains(query) || t.Status.Contains(query));
            }

            if (!string.IsNullOrWhiteSpace(status))
            {
                ticketsQuery = ticketsQuery.Where(t => t.Status == status);
            }

            // Sorting
            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                if (sortDirection?.ToLower() == "desc" || sortDirection?.ToLower() == "dsc")
                {
                    ticketsQuery = ticketsQuery.OrderByDescending(t => EF.Property<object>(t, sortBy));
                }
                else
                {
                    ticketsQuery = ticketsQuery.OrderBy(t => EF.Property<object>(t, sortBy));
                }
            }

            // Pagination
            var skipResults = (pageNumber.Value - 1) * pageSize.Value;
            var tickets = await ticketsQuery.Skip(skipResults).Take(pageSize.Value).ToListAsync();

            return _mapper.Map<IEnumerable<TicketDto>>(tickets);
        }

        
        public async Task<int> GetCount()
        {
            return await _context.Tickets.CountAsync(); 
        }

        public async Task<TicketDto> GetTicketByIdAsync(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            return _mapper.Map<TicketDto>(ticket);
        }

        public async Task<TicketDto> CreateTicketAsync(TicketForCreationDto ticketDto)
        {
            var ticket = _mapper.Map<Ticket>(ticketDto);
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
            return _mapper.Map<TicketDto>(ticket);
        }

        public async Task UpdateTicketAsync(TicketForUpdateDto ticketDto)
        {
            var ticket = await _context.Tickets.FindAsync(ticketDto.TicketId);
            if (ticket != null)
            {
                _mapper.Map(ticketDto, ticket);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteTicketAsync(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                await _context.SaveChangesAsync();
            }
        }
    }
}
