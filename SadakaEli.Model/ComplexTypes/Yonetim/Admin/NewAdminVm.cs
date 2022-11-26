using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace SadakaEli.Model.ComplexTypes.Yonetim.Admin
{
    public class NewAdminVm
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public string FullName { get; set; }
        public string FileName { get; set; }
        public int RoleId { get; set; }

        public List<SelectListItem> Roles { get; set; }
    }
}
