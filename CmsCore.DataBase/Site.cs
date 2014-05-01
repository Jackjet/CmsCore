using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsCore.DataBase
{
    public class Site :  SeoMeta
    {
        public string Title { get; set; }

        public string RootPath { get; set; }

        public string Domain { get; set; }

        public string DefaultStyle { get; set; }

        public int ReleasePointId { get; set; }
    }
}
