using InfraStructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SadakaEli.Model.Domain
{
    public class Admin :BaseDomain
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public int? RoleId { get; set; }
        public string Photo { get; set; }

        public virtual Role Role { get; set; }
    }
}
