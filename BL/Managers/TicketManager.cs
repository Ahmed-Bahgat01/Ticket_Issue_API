using BL.DTOs.Ticket;
using BL.Managers.Interfaces;
using DAL.Data.Models;
using DAL.Repos.Interfaces;
using DAL.UnitOfWork;

namespace BL.Managers;

public class TicketManager : ITicketManager
{
    #region ctor and feilds

    private readonly IUnitOfWork _unit;
    private readonly ITicketRepo _ticketRepo;
    public TicketManager(IUnitOfWork unit)
    {
        _unit = unit;
        _ticketRepo = unit.Tickets;
    }

    #endregion

    #region methods

    public int Add(TicketAddDto ticketDto)
    {
        var department = _unit.Departments.GetById(ticketDto.DepartmentId);
        if(department is null)
            throw new Exception("Not Found Department Id");

        Ticket newTicket = new Ticket
        {
            Description = ticketDto.Description,
            Title = ticketDto.Title,
            DepartmentId = ticketDto.DepartmentId,
        };
        _unit.Tickets.Add(newTicket);
        _unit.Save();

        return newTicket.Id;
    }

    public void delete(int id)
    {

        Ticket? targetedTicket = _unit.Tickets.GetById(id);
        if(targetedTicket is null)
            throw new Exception("Ticket Not Found");

        _unit.Tickets.Delete(targetedTicket);
        _unit.Save();
    }

    public List<TicketReadDto> GetAll()
    {
        IEnumerable<Ticket> ticketsFromDB = _unit.Tickets.GetAll();
        return ticketsFromDB.Select(t => new TicketReadDto
        {
            Description= t.Description,
            Title= t.Title
        }).ToList();
    }

    public TicketDetailReadDto? GetById(int id)
    {
        Ticket? requiredTicket = _unit.Tickets.GetById(id);
        if(requiredTicket is null)
            return null;

        return new TicketDetailReadDto
        {
            Description = requiredTicket.Description,
            Title = requiredTicket.Title
        };
    }

    public void update(TicketUpdateDto ticketDto)
    {
        var targetTicket = _unit.Tickets.GetById(ticketDto.Id);
        if (targetTicket is null)
            throw new Exception("Not Found Ticket");

        var department = _unit.Departments.GetById(ticketDto.DepartmentId);
        if (department is null)
            throw new Exception("Not Found Department Id");

        targetTicket.Title = ticketDto.Title;
        targetTicket.Description = ticketDto.Description;
        targetTicket.DepartmentId = ticketDto.DepartmentId;
        _unit.Tickets.Update(targetTicket);
        _unit.Save();
    }

    #endregion
}
