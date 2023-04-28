using DAL.Repos.Interfaces;

namespace DAL.UnitOfWork;

internal interface IUnitOfWork: IDisposable
{
    IDepartmentRepo Departments { get; }
    IDeveloperRepo Developers { get; }
    ITiketRepo Tikets { get; }
    int Save();
}
