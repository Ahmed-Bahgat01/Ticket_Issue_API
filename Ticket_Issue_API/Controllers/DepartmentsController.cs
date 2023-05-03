using BL.DTOs;
using BL.DTOs.Department;
using BL.Managers.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ticket_Issue_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentsController : ControllerBase
{
    #region Constructor & Feilds
    private readonly IDepartmentsManager _departmentManager;

    public DepartmentsController(IDepartmentsManager departmentManager)
    {
        _departmentManager = departmentManager;
    }
    #endregion

    #region Endpoints
    [HttpGet]
    [Route("{id}")]
    public ActionResult<DepartmentDetailReadDto> GetDetails(int id)
    {
        DepartmentDetailReadDto? readDto = _departmentManager.GetDetailedDepartment(id);
        if (readDto is null)
            return NotFound();

        return readDto;
    }

    [HttpPost]
    public ActionResult Add(DepartmentAddDto addDto)
    {
        bool exists = _departmentManager.isDepartmentNameExists(addDto.Name);
        if (exists)
            return BadRequest(new GeneralResponseDto { Message = "Department Name Already Exists" });

        var newDepartmentId = _departmentManager.Add(addDto);
        return CreatedAtAction(
            nameof(GetDetails), 
            new { id = newDepartmentId }, 
            new GeneralResponseDto { Message = "Department Created Successfully"});
    }
    #endregion
}
