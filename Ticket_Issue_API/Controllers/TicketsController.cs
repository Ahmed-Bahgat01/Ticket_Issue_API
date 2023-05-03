using BL.DTOs;
using BL.DTOs.Ticket;
using BL.Managers.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ticket_Issue_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TicketsController : ControllerBase
{
    #region Constructor & Feilds
    private readonly ITicketManager _ticketManager;

    public TicketsController(ITicketManager ticketManager)
    {
        _ticketManager = ticketManager;
    }
    #endregion

    #region Endpoints
    [HttpGet]
    public ActionResult<List<TicketReadDto>> GetAll()
    {
        return _ticketManager.GetAll();
    }

    [HttpGet]
    [Route("{id}")]
    public ActionResult<TicketDetailReadDto> GetDetails(int id)
    {
        TicketDetailReadDto? readDto = _ticketManager.GetById(id);
        if(readDto is null)
            return NotFound();

        return readDto;
    }

    [HttpPost]
    public ActionResult Add(TicketAddDto ticketAddDto)
    {
        int newTicketId;
        try
        {
            newTicketId = _ticketManager.Add(ticketAddDto);
        }
        catch (Exception e)
        {
            return NotFound(new GeneralResponseDto { Message = $"{e.Message}" });
        }
        return CreatedAtAction(
            nameof(GetDetails), 
            new { Id = newTicketId }, 
            new GeneralResponseDto { Message = "Ticket Created Successfully"});
    }


    [HttpPut]
    public ActionResult Update(TicketUpdateDto ticketDto)
    {
        var targetedTicket = _ticketManager.GetById(ticketDto.Id);
        if (targetedTicket == null)
            return NotFound();

        _ticketManager.update(ticketDto);
        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult Delete(int id)
    {
        var targetedTicket = _ticketManager.GetById(id);
        if (targetedTicket is null)
            return NotFound();

        _ticketManager.delete(id);
        return NoContent();
    }

    #endregion
}
