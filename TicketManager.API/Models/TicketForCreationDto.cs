using System.ComponentModel.DataAnnotations;

namespace TicketManager.API.Models
{
    public class TicketForCreationDto
    {
        [Required(ErrorMessage = "You should provide a description.")]
        [MaxLength(200, ErrorMessage = "The description cannot exceed 200 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "You should provide a status.")]
        [RegularExpression("^(Open|Closed)$", ErrorMessage = "Status must be either 'Open' or 'Closed'.")]
        public string Status { get; set; }

        [Required(ErrorMessage = "The creation date is required.")]
        public DateTime Date { get; set; }
    }
}
