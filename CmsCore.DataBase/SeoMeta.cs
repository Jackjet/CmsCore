using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsCore.DataBase
{
    public abstract class SeoMeta : BaseModel
    {
        [StringLength(200)]
        [Display(Name = "网页标题")]
        public string MetaTitle { get; set; }

        [StringLength(200)]
        [Display(Name = "网页关键词")]
        public string MetaKeywords { get; set; }

        [StringLength(200)]
        [Display(Name = "网页描述")]
        public string MetaDescription { get; set; }
    }
}
