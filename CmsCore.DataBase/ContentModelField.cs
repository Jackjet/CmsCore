using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsCore.DataBase
{
    public class ContentModelField : BaseModel
    {
        public int ContentModelId { get; set; }

        public string Field { get; set; }

        public string Title { get; set; }
    }
}
