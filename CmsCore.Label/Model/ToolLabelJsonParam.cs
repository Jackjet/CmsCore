using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsCore.Label.Model
{
    public class ToolLabelJsonParam : BaseLabelParam
    {
        public string Url { get; set; }

        public ToolLabelJsonParam()
        {
            Url = string.Empty;
        }
    }
}
