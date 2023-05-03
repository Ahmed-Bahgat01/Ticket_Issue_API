using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DAL.Data.Models;

[Index(nameof(Name), IsUnique = true)]
public class Department
{
    #region Properties
    [Key]
    public int Id { get; set; }

    [StringLength(20, MinimumLength = 2)]
    public string Name { get; set; } = string.Empty;
    #endregion

    #region Navigation properties
    public ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
    #endregion
}
