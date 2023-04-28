using DAL.Data.Context;
using DAL.Repos;
using DAL.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork;

internal class UnitOfWork : IUnitOfWork
{
    private readonly Context _context;

    public UnitOfWork(Context context)
    {
        _context = context;
    }

    public IDepartmentRepo Departments => new DepartmentRepo(_context);

    public IDeveloperRepo Developers => new DeveloperRepo(_context);

    public ITiketRepo Tikets => new TiketRepo(_context);

    public void Dispose()
    {
        _context.Dispose();
    }

    public int Save()
    {
        return _context.SaveChanges();
    }
}
