using InfraStructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SadakaEli.Model.Domain
{
    public class News : BaseDomain
    {
        public string Photo { get; set; }
        public string Headline { get; set; }

        public string Explanation { get; set; }
    }
}
