using DAL.Data.Context;
using DAL.Data.Models;
using DAL.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos;

internal class DeveloperRepo : EntityRepo<Developer>, IDeveloperRepo
{
    public DeveloperRepo(Context dbContext) : base(dbContext)
    {
    }
}
