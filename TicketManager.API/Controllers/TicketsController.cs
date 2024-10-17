using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TicketManager.API.Models;
using TicketManager.API.Services;

namespace TicketManager.API.Controllers
{
    [Route("api/[controller]")] 
    [ApiController] 
    public class TicketsController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository; 

        
        public TicketsController(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository; 
        }

        // GET: api/tickets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketDto>>> GetTickets(
               string? query = null, 
               string? status = null, 
               string? sortBy = null, 
               string? sortDirection = "asc", 
               int? pageNumber = 1, 
               int? pageSize = 10  
              )
        {
            // Validate sortDirection
            if (sortDirection != "asc" && sortDirection != "desc")
            {
                sortDirection = "asc"; 
            }

            // Get all tickets based on filters and pagination
            var tickets = await _ticketRepository.GetAllTicketsAsync(query, status, sortBy, sortDirection, pageNumber, pageSize);
            return Ok(tickets); 
        }

        // Add an endpoint to get the total count of tickets
        [HttpGet("count")]
        public async Task<ActionResult<int>> GetTicketsCount()
        {
            var count = await _ticketRepository.GetCount(); 
            return Ok(count); 
        }

        // GET: api/tickets/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketDto>> GetTicket(int id)
        {
            var ticket = await _ticketRepository.GetTicketByIdAsync(id); 
            if (ticket == null)
            {
                return NotFound(); 
            }
            return Ok(ticket); 
        }

        // POST: api/tickets
        [HttpPost]
        public async Task<ActionResult<TicketDto>> CreateTicket([FromBody] TicketForCreationDto ticketDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            var createdTicket = await _ticketRepository.CreateTicketAsync(ticketDto); // Create a new ticket

            // Return 201 Created with the newly created ticket
            return CreatedAtAction(nameof(GetTicket), new { id = createdTicket.TicketId }, createdTicket);
        }

        // PUT: api/tickets/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket(int id, [FromBody] TicketForUpdateDto ticketDto)
        {
            if (id != ticketDto.TicketId)
            {
                return BadRequest("Ticket ID mismatch"); // Return 400 if IDs don't match
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Return 400 if validation fails
            }

            var existingTicket = await _ticketRepository.GetTicketByIdAsync(id); // Fetch existing ticket
            if (existingTicket == null)
            {
                return NotFound(); // Return 404 if ticket is not found
            }

            await _ticketRepository.UpdateTicketAsync(ticketDto); // Update the ticket
            return NoContent(); // Return 204 No Content after successful update
        }

        // DELETE: api/tickets/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var ticket = await _ticketRepository.GetTicketByIdAsync(id); 
            if (ticket == null)
            {
                return NotFound(); // Return 404 if ticket is not found
            }

            await _ticketRepository.DeleteTicketAsync(id); 
            return NoContent(); 
        }
    }
}
