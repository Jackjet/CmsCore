using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsCore.DataBase
{
    public class User
    {
        [Key]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(32)]
        public string UserPwd { get; set; }

        [Required]
        public DateTime CreateTime { get; set; }
    }
}
