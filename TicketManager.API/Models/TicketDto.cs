namespace TicketManager.API.Models
{
    public class TicketDto
    {
        public int TicketId { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
    }
}
