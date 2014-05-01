using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsCore.Label.Model
{
    public class ContentLabelGetListsParam : BaseLabelParam
    {
        public int CatId { get; set; }

        public string Where { get; set; }

        public bool Thumb { get; set; }

        public string Order { get; set; }

        public ContentLabelGetListsParam()
        {
            Where = string.Empty;
            Order = string.Empty;
        }
    }
}
