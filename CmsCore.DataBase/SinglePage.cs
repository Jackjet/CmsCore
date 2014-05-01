using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsCore.DataBase
{
    public class SinglePage : SeoMeta
    {
        public string Content { get; set; }

        #region Template

        public string DefaultStyle { get; set; }

        public string Template { get; set; }

        #endregion
    }
}
