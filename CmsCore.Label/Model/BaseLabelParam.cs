using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsCore.Label.Model
{
    public abstract class BaseLabelParam
    {
        public int Num { get; set; }

        public int Cache { get; set; }

        public int Page { get; set; }

        public string UrlRule { get; set; }

        protected BaseLabelParam()
        {
            UrlRule = string.Empty;
        }
    }
}
