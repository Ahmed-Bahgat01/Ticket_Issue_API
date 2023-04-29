using BL.DTOs.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers.Interfaces;

public interface ITicketManager
{
    List<TicketReadDto> GetAll();
    TicketDetailReadDto? GetById(int id);
    int Add(TicketAddDto ticketDto);
    void update(TicketUpdateDto ticketDto);
    void delete(int id);
}
