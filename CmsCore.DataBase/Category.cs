using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsCore.DataBase
{
    public class Category :  SeoMeta
    {
        [Display(Name = "站点编号")]
        public int SiteId { get; set; }

        #region 栏目信息
        
        [Display(Name = "栏目名称")]
        public string Title { get; set; }

        [Display(Name = "父级栏目")]
        public int ParentId { get; set; }

        [Display(Name = "排列顺序")]
        public int Order { get; set; }

        [Display(Name = "栏目路径")]
        public string CatPath { get; set; }
        
        #endregion

        #region 栏目类型

        /// <summary>
        /// 模型类型
        /// 0：单页内容模型(SinglePage.ModelId)
        /// 1：自定义内容模型(ContentModel.ModelId,DefaultStyle,CategoryTemplate,ListTemplate,ShowTemplate)
        /// 2：指向一个URL地址(Url)
        /// </summary>
        [Display(Name = "模型类型")]
        public int ModelType { get; set; }

        /// <summary>
        /// 内容模型，由IsSinglePage指定ContentModel或SinglePage
        /// </summary>
        [Display(Name = "模型编号")]
        public int ModelId { get; set; }

        /// <summary>
        /// 链接
        /// </summary>
        [Display(Name = "模型链接")]
        public string Url { get; set; }

        #endregion
        
        #region Template

        [Display(Name = "模板样式")]
        public string DefaultStyle { get; set; }

        [Display(Name = "首页模板")]
        public string CategoryTemplate { get; set; }

        [Display(Name = "列表模板")]
        public string ListTemplate { get; set; }

        [Display(Name = "列表分页大小")]
        public int  ListPageSize { get; set; }

        [Display(Name = "内容模板")]
        public string ShowTemplate { get; set; }

        [Display(Name = "内容分页大小")]
        public int ShowPageSize { get; set; }

        #endregion
    }
}
