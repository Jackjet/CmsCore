using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsCore.DataBase
{
    public class ContentModel : BaseModel
    {
        public int SiteId { get; set; }

        public string Title { get; set; }

        public string TableName { get; set; }

        public int ItemsCount { get; set; }
    }
}
