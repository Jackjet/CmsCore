using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CmsCore.DataBase;

namespace CmsCore.Label
{
    /// <summary>
    /// 标签抽象基类
    /// </summary>
    public abstract class BaseLabel
    {
        protected readonly CmsCoreDB CmsCoreDB = new CmsCoreDB();
    }
}