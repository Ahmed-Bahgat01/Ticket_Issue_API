using DAL.Data.Context;
using DAL.Data.Models;
using DAL.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos;

public class DepartmentRepo : EntityRepo<Department>, IDepartmentRepo
{
    Context _dbContext;
    public DepartmentRepo(Context dbContext) : base(dbContext)
    {
        _dbContext= dbContext;
    }

    public Department? GetWithTicketsAndDevelopers(int id)
    {
        return _dbContext.Departments
            .Include(d => d.Tickets)
            .ThenInclude(t => t.DevelopersTickets)
            .FirstOrDefault(d => d.Id == id);
    }
}
