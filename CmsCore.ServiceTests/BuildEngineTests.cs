using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CmsCore.DataBase;
using CmsCore.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CmsCore.Service.Tests
{
    [TestClass()]
    public class BuildEngineTests
    {
        private readonly BuildEngine _buildEngine;
        private const int ConstSiteId = 1;
        private const int ConstCategoryId = 1;

        public BuildEngineTests()
        {
            _buildEngine = new BuildEngine();
            BuildEngine.ExceptionHandle += ExceptionHandle;
        }

        private static void ExceptionHandle(Exception exception)
        {
            Debug.Write(exception);
        }

        [TestMethod()]
        public void InitTest()
        {
            Init();
        }

        [TestMethod()]
        public void CompileHomeTest()
        {
            _buildEngine.CompileHome(ConstSiteId);

            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void CompileCategoryTest()
        {
            _buildEngine.CompileCategory(ConstCategoryId + 1);

            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void CompileCategoryListTest()
        {
            //_buildEngine.CompileCategoryList(ConstCategoryId);

            _buildEngine.CompileCategoryList(ConstCategoryId + 1);

            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void CompileCategoryContentTest()
        {
            //_buildEngine.CompileCategoryContent(ConstCategoryId);

            _buildEngine.CompileCategoryContent(ConstCategoryId + 1);

            Assert.IsTrue(true);
        }

        private void Init()
        {
            var db = new CmsCoreDB();
            db.ReleasePoint.Add(new ReleasePoint { CreateTime = DateTime.Now, Host = "127.0.0.1", Port = 21, RootPath = "/", Title = "默认站点", UserName = "anonymous", UserPwd = "" });

            db.Site.Add(new Site { CreateTime = DateTime.Now, DefaultStyle = "Default", Domain = "wangya.com", MetaDescription = "网站描述", MetaKeywords = "网站关键字", MetaTitle = "网站标题", ReleasePointId = 1, RootPath = "/", Title = "测试网站1" });

            db.Category.Add(new Category
            {
                CatPath = "news",
                DefaultStyle = "Default",
                CategoryTemplate = "Content/category_news.cshtml",
                ListTemplate = "Content/list_news.cshtml",
                ShowTemplate = "Content/show_news.cshtml",
                MetaDescription = "新闻类目描述",
                MetaKeywords = "新闻类目关键词",
                MetaTitle = "新闻类目标题",
                ModelType = 0,
                ModelId = 1,
                ParentId = 0,
                ListPageSize = 20,
                SiteId = 1,
                Title = "新闻",
                CreateTime = DateTime.Now
            });

            db.Category.Add(new Category
            {
                CatPath = "products",
                DefaultStyle = "Default",
                CategoryTemplate = "Content/category_news.cshtml",
                ListTemplate = "Content/list_news.cshtml",
                ShowTemplate = "Content/show_news.cshtml",
                MetaDescription = "产品类目描述",
                MetaKeywords = "产品类目关键词",
                MetaTitle = "产品类目标题",
                ModelType = 1,
                ModelId = 1,
                ParentId = 0,
                ListPageSize = 20,
                SiteId = 1,
                Title = "产品",
                CreateTime = DateTime.Now
            });

            db.ContentModel.Add(new ContentModel { CreateTime = DateTime.Now, SiteId = 1, TableName = "news", Title = "文章模型" });

            db.SinglePage.Add(new SinglePage { Content = "测试单页内容", CreateTime = DateTime.Now, DefaultStyle = "Default", MetaDescription = "测试单页Description", MetaKeywords = "测试单页eywords", MetaTitle = "测试单页Title", Template = "Content/page_news.cshtml" });

            db.SaveChanges();
        }

        [TestMethod()]
        public void CompileHomeAsyncTest()
        {
            _buildEngine.CompileHomeAsync(ConstSiteId);

            Thread.Sleep(5 * 1000);
        }

        [TestMethod()]
        public void CompileCategoryAsyncTest()
        {
            _buildEngine.CompileCategoryAsync(ConstSiteId+1);

            Thread.Sleep(5 * 1000);
        }

        [TestMethod()]
        public void CompileCategoryListAsyncTest()
        {
            _buildEngine.CompileCategoryListAsync(ConstSiteId + 1);

            Thread.Sleep(5 * 1000);
        }

        [TestMethod()]
        public void CompileCategoryContentAsyncTest()
        {
            _buildEngine.CompileCategoryContentAsync(ConstSiteId + 1);

            Thread.Sleep(5 * 1000);
        }
    }
}
