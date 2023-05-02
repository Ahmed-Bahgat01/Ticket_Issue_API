using DAL.Data.Context;
using DAL.Data.Models;
using DAL.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos;

public class DepartmentRepo : EntityRepo<Department>, IDepartmentRepo
{
    public DepartmentRepo(Context dbContext) : base(dbContext)
    {
    }
}
