using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsCore.Label.Model
{
    public class ContentLabelGetCategoryParam : BaseLabelParam
    {
        public int CatId { get; set; }

        public string Order { get; set; }

        public int SiteId { get; set; }

        public ContentLabelGetCategoryParam()
        {
            Order = string.Empty;
        }
    }
}
