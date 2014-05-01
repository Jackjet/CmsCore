using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsCore.DataBase
{
    public class ReleasePoint : BaseModel
    {
        public string Title { get; set; }

        public string Host { get; set; }

        public string UserName { get; set; }

        public string UserPwd { get; set; }

        public ushort Port { get; set; }

        public string RootPath { get; set; }
    }
}
