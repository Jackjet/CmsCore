using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsCore.Label.Model
{
    public class ToolLabelGetParam : BaseLabelParam
    {
        public string Sql { get; set; }

        public ToolLabelGetParam()
        {
            Sql = string.Empty;
        }
    }
}
