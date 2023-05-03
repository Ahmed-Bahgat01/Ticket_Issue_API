using BL.DTOs.Department;

namespace BL.Managers.Interfaces;

public interface IDepartmentsManager
{
    int Add(DepartmentAddDto DepartmentDto);
    DepartmentDetailReadDto? GetDetailedDepartment(int id);
    bool isDepartmentNameExists(string departmentName);

}
