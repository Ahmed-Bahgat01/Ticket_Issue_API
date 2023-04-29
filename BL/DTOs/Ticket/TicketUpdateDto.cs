namespace BL.DTOs.Ticket
{
    public class TicketUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
    }
}
