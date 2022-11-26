using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SadakaEli.Model.ComplexTypes.Yonetim.News
{
    public class UpdateNewsVm
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        public string Headline { get; set; }

        public string Explanation { get; set; }
        public string FileName { get; set; }
    }
}
