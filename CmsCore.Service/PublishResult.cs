using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsCore.Service
{
    public sealed class PublishResult
    {
        public string Path { get; set; }

        public string FileName { get; set; }

        public string Context { get; set; }

        /// <summary>
        /// 发布点(暂未使用)
        /// </summary>
        public int ReleasePoint { get; set; }
    }
}
