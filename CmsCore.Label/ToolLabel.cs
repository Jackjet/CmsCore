using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CmsCore.Label.Model;

namespace CmsCore.Label
{
    public class ToolLabel : BaseLabel
    {
        public ToolLabelGetResult Get(ToolLabelGetParam model)
        {
            return new ToolLabelGetResult();
        }

        public ToolLabelXmlResult Xml(ToolLabelXmlParam model)
        {
            return new ToolLabelXmlResult();
        }

        public ToolLabelJsonResult Json(ToolLabelJsonParam model)
        {
            return new ToolLabelJsonResult();
        }
    }
}