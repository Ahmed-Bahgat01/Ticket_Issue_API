using System.ComponentModel.DataAnnotations;

namespace BL.DTOs.Ticket;

public class TicketAddDto
{
    //[StringLength(50, MinimumLength = 2)]
    public string Title { get; set; } = string.Empty;
    //[MaxLength(5000)]
    public string Description { get; set; } = string.Empty;
    public int DepartmentId { get; set; }
}
