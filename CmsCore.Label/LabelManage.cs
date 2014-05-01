using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsCore.Label
{
    /// <summary>
    /// 标签管理
    /// </summary>
    public class LabelManage
    {
        private static readonly ContentLabel ContentLabel = new ContentLabel();
        private static readonly ToolLabel ToolLabel=new ToolLabel();

        /// <summary>
        /// 内容标签
        /// </summary>
        public static ContentLabel Content
        {
            get
            {
                return ContentLabel;
            }
        }

        /// <summary>
        /// 工具标签
        /// </summary>
        public static ToolLabel Tool
        {
            get
            {
                return ToolLabel;
            }
        }
    }
}