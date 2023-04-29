using DAL.Repos.Interfaces;

namespace DAL.UnitOfWork;

public interface IUnitOfWork: IDisposable
{
    IDepartmentRepo Departments { get; }
    IDeveloperRepo Developers { get; }
    ITicketRepo Tickets { get; }
    int Save();
}
