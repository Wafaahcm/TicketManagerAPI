using System.ComponentModel.DataAnnotations;

namespace TicketManager.API.Models
{
    public class TicketForUpdateDto
    {
        [Required(ErrorMessage = "The Ticket ID is required.")]
        public int TicketId { get; set; }

        [Required(ErrorMessage = "You should provide a description.")]
        [MaxLength(200, ErrorMessage = "The description cannot exceed 200 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "You should provide a status.")]
        [RegularExpression("^(Open|Closed)$", ErrorMessage = "Status must be either 'Open' or 'Closed'.")]
        public string Status { get; set; }
    }
}
