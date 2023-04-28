using System.ComponentModel.DataAnnotations;

namespace DAL.Data.Models;

internal class Developer
{
    #region Properties
    [Key]
    public int Id { get; set; }

    [StringLength(30, MinimumLength = 3)]
    public string Name { get; set; } = string.Empty;
    #endregion

    #region Navigation properties
    ICollection<DeveloperTicket> DevelopersTickets { get; set; } = new HashSet<DeveloperTicket>();
    #endregion
}
