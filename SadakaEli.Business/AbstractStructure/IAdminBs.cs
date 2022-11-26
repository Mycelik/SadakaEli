using SadakaEli.Model.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SadakaEli.Business.AbstractStructure
{
    public interface IAdminBs : IBusinessBs<Admin>
    {
        Admin LogIn(string email, string password);
    }
}
