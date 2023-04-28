using DAL.Data.Context;
using DAL.Data.Models;
using DAL.Repos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos;

internal class TiketRepo : EntityRepo<Ticket>, ITiketRepo
{
    public TiketRepo(Context dbContext) : base(dbContext)
    {
    }
}
