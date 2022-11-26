using InfraStructure.DataAccess.EntityFramework;
using SadakaEli.DataAccess.AbstractStructure;
using SadakaEli.DataAccess.EntityFramework.Context;
using SadakaEli.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SadakaEli.DataAccess.EntityFramework.Repositories
{
    public class EfUserRepository : EfBaseRepository<User,SadakaEliContext>,IUserRepository
    {
    }
}
