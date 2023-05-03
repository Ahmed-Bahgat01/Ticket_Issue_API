namespace BL.DTOs.Department;

public class DepartmentDetailReadDto
{
    public string Name { get; set; } = string.Empty;
    public List<DepartmentDetailTicketInfoDto>? Tickets { get; set; }

}
