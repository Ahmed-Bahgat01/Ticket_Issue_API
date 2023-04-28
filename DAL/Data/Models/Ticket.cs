using System.ComponentModel.DataAnnotations;

namespace DAL.Data.Models;

internal class Ticket
{
    #region Properties
    [Key]
    public int Id { get; set; }

    [StringLength(50, MinimumLength = 2)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(5000)]
    public string Description { get; set; } = string.Empty;
    #endregion


    #region FK's
    public int DepartmentId { get; set; }
    #endregion


    #region Navigation properties
    public Department? Department { get; set; }
    ICollection<DeveloperTicket> DevelopersTickets { get; set; } = new HashSet<DeveloperTicket>();
    #endregion
}
