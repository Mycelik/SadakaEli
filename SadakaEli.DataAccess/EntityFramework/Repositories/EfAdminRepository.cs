using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfraStructure.DataAccess.EntityFramework;
using SadakaEli.DataAccess.AbstractStructure;
using SadakaEli.DataAccess.EntityFramework.Context;
using SadakaEli.Model.Domain;

namespace SadakaEli.DataAccess.EntityFramework.Repositories
{
    public class EfAdminRepository : EfBaseRepository<Admin,SadakaEliContext>,IAdminRepository
    {
    }
}
