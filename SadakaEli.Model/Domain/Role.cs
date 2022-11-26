using InfraStructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SadakaEli.Model.Domain
{
    public class Role : BaseDomain
    {
        public Role()
        {
            Admins = new HashSet<Admin>();
        }
        public string RoleName { get; set; }

        public virtual ICollection<Admin> Admins { get; set; }
        
    }
}
