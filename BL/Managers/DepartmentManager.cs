using BL.DTOs.Department;
using BL.Managers.Interfaces;
using DAL.Data.Models;
using DAL.UnitOfWork;

namespace BL.Managers;

public class DepartmentManager : IDepartmentsManager
{
    #region Constructor & Feilds
    private readonly IUnitOfWork _unit;

    public DepartmentManager(IUnitOfWork unit)
    {
        _unit = unit;
    }
    #endregion

    #region Methods
    public DepartmentDetailReadDto? GetDetailedDepartment(int id)
    {
        Department? requiredDepartment = _unit.Departments.GetWithTicketsAndDevelopers(id);
        if (requiredDepartment is null)
            return null;

        return new DepartmentDetailReadDto
        {
            Name = requiredDepartment.Name,
            Tickets = requiredDepartment.Tickets
                .Select(t => new DepartmentDetailTicketInfoDto
                {
                    Title = t.Title,
                    Description = t.Description,
                    DevelopersCount = t.DevelopersTickets.Count
                }).ToList()
        };
    }


    public int Add(DepartmentAddDto DepartmentDto)
    {
        Department newDept = new Department
        {
            Name = DepartmentDto.Name
        };
        _unit.Departments.Add(newDept);
        _unit.Save();
        return newDept.Id;
    }

    public bool isDepartmentNameExists(string departmentName)
    {
        var deptsWithTargetName = _unit.Departments.Search(d => d.Name == departmentName);
        return deptsWithTargetName.Any();
    }
    #endregion
}
