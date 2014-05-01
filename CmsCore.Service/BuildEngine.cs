using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using CmsCore.DataBase;
using RazorEngine.Templating;

namespace CmsCore.Service
{
    public class BuildEngine
    {
        #region 私有字段
        
        private readonly IPublishEngine _publishEngine = new DefaultPublishEngine();
        private readonly IParseEngine _parseEngine = new RazorParseEngine();
        private readonly CmsCoreDB _cmsCoreDB = new CmsCoreDB();

        #endregion

        #region 静态事件

        public static OnException ExceptionHandle; 

        #endregion

        #region 构造函数

        public BuildEngine()
        {
            _parseEngine.RenderException += ParseEngineOnRenderException;
            _parseEngine.Init();
        }

        #endregion

        #region 异步编译

        public async void CompileHomeAsync(int siteId)
        {
            await Task.Factory.StartNew(() => CompileHome(siteId));
        }

        public async void CompileCategoryAsync(int siteId)
        {
            await Task.Factory.StartNew(() => CompileCategory(siteId));
        }

        public async void CompileCategoryListAsync(int siteId)
        {
            await Task.Factory.StartNew(() => CompileCategoryList(siteId));
        }

        public async void CompileCategoryContentAsync(int siteId)
        {
            await Task.Factory.StartNew(() => CompileCategoryContent(siteId));
        }

        #endregion

        #region 公共方法
        
        public void CompileHome(int siteId)
        {
            //获取网站模板风格
            var siteModel = _cmsCoreDB.Site.FirstOrDefault(p => p.ID == siteId);
            if (siteModel != null)
            {
                var homeTemplatePath = string.Format("{0}\\Templates\\{1}\\index.cshtml",
                    AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\'),
                    siteModel.DefaultStyle);

                var viewBag = new DynamicViewBag();
                viewBag.AddValue("Data", siteModel);

                var parseResult = ParsePathContent(homeTemplatePath, viewBag);

                if (!string.IsNullOrEmpty(parseResult))
                {
                    var publishResult = new PublishResult
                    {
                        Context = parseResult,
                        Path = siteModel.RootPath,
                        FileName = "Index",
                        ReleasePoint = siteModel.ReleasePointId
                    };
                    _publishEngine.Push(publishResult);
                }
            }
        }

        public void CompileCategory(int categoryId)
        {
            //编译栏目首页
            //传递参数：模板文件[单页、模型]、SEOMeta
            //发布结果：解析结果、网站发布点、保存路径、保存文件名

            var categoryModel = _cmsCoreDB.Category.FirstOrDefault(p => p.ID == categoryId);
            if (categoryModel != null)
            {
                var templatePath = string.Empty;
                var parseResult = string.Empty;
                var viewBag = new DynamicViewBag();

                if (categoryModel.ModelType == 0)
                {
                    //单页内容模板
                    var singlePageModel = _cmsCoreDB.SinglePage.FirstOrDefault(p => p.ID == categoryModel.ModelId);
                    if (singlePageModel != null)
                    {
                        templatePath = string.Format("{0}\\Templates\\{1}\\{2}",
                            AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\'),
                            singlePageModel.DefaultStyle,
                            singlePageModel.Template.Replace("/", "\\"));

                        viewBag.AddValue("Data", singlePageModel);

                        parseResult = ParsePathContent(templatePath, viewBag);
                    }
                }
                else if (categoryModel.ModelType == 1)
                {
                    //自定义内容模型
                    templatePath = string.Format("{0}\\Templates\\{1}\\{2}",
                        AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\'),
                        categoryModel.DefaultStyle,
                        categoryModel.CategoryTemplate.Replace("/", "\\"));

                    viewBag.AddValue("Data", categoryModel);

                    parseResult = ParsePathContent(templatePath, null);
                }
                else
                {
                    return;
                }

                //发布
                if (!string.IsNullOrEmpty(parseResult))
                {
                    var publishResult = new PublishResult
                    {
                        Context = parseResult,
                        Path = categoryModel.CatPath,   //递归路径
                        FileName = "Index",
                    };
                    _publishEngine.Push(publishResult);
                }
            }
        }

        public void CompileCategoryList(int categoryId)
        {
            //分页生成

            //获取栏目实体
            var categoryModel = _cmsCoreDB.Category.FirstOrDefault(p => p.ID == categoryId);
            if (categoryModel != null)
            {
                //自定义内容模型
                if (categoryModel.ModelType == 1)
                {
                    var customContentModel = _cmsCoreDB.ContentModel.FirstOrDefault(p => p.ID == categoryModel.ModelId);
                    if (customContentModel != null)
                    {
                        //按分页遍历生成
                        var dataModelManage = new DataModelManage();

                        var pageSize = categoryModel.ListPageSize;
                        var pageIndex = 0;
                        var templateFilePath = string.Format("{0}\\Templates\\{1}\\{2}",
                            AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\'),
                            categoryModel.DefaultStyle,
                            categoryModel.ListTemplate.Replace("/", "\\"));
                        
                    //GOTO返回获取数据标志
                    RELOADPAGELIST:

                        #region GOTO循环获取分页数据，直至分页为0

                        var pageListModel = dataModelManage.GetPageList(customContentModel.TableName, categoryId, pageIndex, pageSize);

                        //如果存在数据
                        if (pageListModel.Any())
                        {
                            //add ViewBag
                            var viewBag = new DynamicViewBag();
                            viewBag.AddValue("Data", pageListModel);

                            //渲染
                            var parseResult = ParsePathContent(templateFilePath, viewBag);

                            //发布
                            if (!string.IsNullOrEmpty(parseResult))
                            {
                                var publishResult = new PublishResult
                                {
                                    Context = parseResult,
                                    Path = categoryModel.CatPath,   //递归路径
                                    FileName = string.Format("list-{0}", pageIndex),
                                };

                                _publishEngine.Push(publishResult);
                            }

                            //当前分页索引递增至下一页
                            pageIndex++;

                            //重新获取下一分页数据
                            goto RELOADPAGELIST;
                        }

                        #endregion
                    }
                }
            }
        }

        public void CompileCategoryContent(int categoryId)
        {
            //逐条生成

            //获取栏目实体
            var categoryModel = _cmsCoreDB.Category.FirstOrDefault(p => p.ID == categoryId);
            if (categoryModel != null)
            {
                //自定义内容模型
                if (categoryModel.ModelType == 1)
                {
                    var customContentModel = _cmsCoreDB.ContentModel.FirstOrDefault(p => p.ID == categoryModel.ModelId);
                    if (customContentModel != null)
                    {
                        var pageSize = categoryModel.ShowPageSize;
                        var pageIndex = 0;
                        var templateFilePath = string.Format("{0}\\Templates\\{1}\\{2}",
                            AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\'),
                            categoryModel.DefaultStyle,
                            categoryModel.ShowTemplate.Replace("/", "\\"));

                        //按分页遍历生成
                        var dataModelManage = new DataModelManage();

                    //GOTO返回获取数据标志
                    RELOADPAGELIST:

                        #region GOTO循环获取分页数据，直至分页为0

                        var pageListModel = dataModelManage.GetPageList(customContentModel.TableName, categoryId, pageIndex, pageSize);

                        //如果存在数据
                        var listModel = pageListModel as dynamic[] ?? pageListModel.ToArray();
                        if (listModel.Any())
                        {
                            //逐个渲染模型
                            foreach (var m in listModel)
                            {
                                var viewBag = new DynamicViewBag();

                                viewBag.AddValue("Data", m);

                                //渲染
                                var parseResult = ParsePathContent(templateFilePath, viewBag);

                                //发布
                                if (!string.IsNullOrEmpty(parseResult))
                                {
                                    var publishResult = new PublishResult
                                    {
                                        Context = parseResult,
                                        Path = categoryModel.CatPath,   //递归路径
                                    };

                                    publishResult.FileName = m.ID.ToString();

                                    _publishEngine.Push(publishResult);
                                }
                            }

                            //当前分页索引递增至下一页
                            pageIndex++;

                            //重新获取下一分页数据
                            goto RELOADPAGELIST;
                        }

                        #endregion
                    }
                }
            }
        }

        #endregion

        #region 私有方法
        
        private string ParsePathContent(string filePath, DynamicViewBag viewBag)
        {
            if (File.Exists(filePath))
            {
                var homeTemplateContent = File.ReadAllText(filePath);
                if (homeTemplateContent.Length != 0)
                {
                    return _parseEngine.Parse(homeTemplateContent, viewBag);
                }
            }
            return string.Empty;
        }

        #endregion

        #region 私有事件

        private static void ParseEngineOnRenderException(Exception exception)
        {
            if (ExceptionHandle != null)
            {
                ExceptionHandle(exception);
            }
        }

        #endregion
    }
}