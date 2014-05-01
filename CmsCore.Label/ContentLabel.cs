using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CmsCore.Label.Model;

namespace CmsCore.Label
{
    /// <summary>
    /// 内容标签
    /// </summary>
    public class ContentLabel : BaseLabel
    {
        /// <summary>
        /// 内容数据列表
        /// </summary>
        /// <param name="model">参数对象</param>
        /// <returns>返回结果</returns>
        public ContentLabelGetListsResult GetLists(ContentLabelGetListsParam model)
        {
            var labelContent = new ContentLabelGetListsResult
            {
                Result = CmsCoreDB.Category.ToList()
            };

            //labelContent.Result.Add(model.Where);
            //labelContent.Result.Add(model.Order);
            //labelContent.Result.Add(DateTime.Now);

            return labelContent;
        }

        /// <summary>
        /// 内容栏目列表
        /// </summary>
        /// <param name="model">参数对象</param>
        /// <returns>返回结果</returns>
        public ContentLabelGetCategoryResult GetCategory(ContentLabelGetCategoryParam model)
        {
            //TODO
            return new ContentLabelGetCategoryResult();
        }
    }
}