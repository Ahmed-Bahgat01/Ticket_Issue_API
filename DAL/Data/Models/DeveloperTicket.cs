using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Data.Models;

internal class DeveloperTicket
{
    #region FK's
    [ForeignKey(nameof(Developer))]
    public int DeveloperId { get; set; }

    [ForeignKey(nameof(Ticket))]
    public int TicketId { get; set; }
    #endregion

    #region Navigation Properties
    public Developer? Developer { get; set; }
    public Ticket? Ticket { get; set; }
    #endregion
}
