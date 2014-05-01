using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsCore.DataBase
{
    public abstract class BaseModel
    {
        [Key]
        [Required]
        [Display(Name = "主键编号")]
        public int ID { get; set; }

        [Required]
        [Display(Name = "创建时间")]
        public DateTime CreateTime { get; set; }
    }
}