using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using RazorEngine;
using RazorEngine.Templating;

namespace CmsCore.Service
{
    public class RazorParseEngine : IParseEngine
    {
        public event OnException RenderException;

        public string TemplateRootDirectory { get; set; }

        public RazorParseEngine()
        {
            TemplateRootDirectory = AppDomain.CurrentDomain.BaseDirectory;
        }

        public void Init()
        {
            try
            {
                //加载标签程序集
                AppDomain.CurrentDomain.Load(new AssemblyName("CmsCore.Label"));

                //预编译全局模板
                var files = Directory.GetFiles(
                    string.Format("{0}\\Templates", TemplateRootDirectory), 
                    "_*.cshtml",
                    SearchOption.AllDirectories);
                
                foreach (var filePath in files)
                {
                    if (string.IsNullOrWhiteSpace(filePath)) continue;

                    var fileName = Path.GetFileNameWithoutExtension(filePath).TrimStart('_');

                    if (string.IsNullOrWhiteSpace(fileName)) continue;

                    var fileContext = File.ReadAllText(filePath);
                    Razor.Compile(fileContext, fileName);
                }
            }
            catch (Exception ex)
            {
                if (RenderException != null)
                {
                    RenderException(ex);
                }
            }

        }

        public string Parse(string templateContent)
        {
            try
            {
                return Razor.Parse(templateContent, null, null, null);
            }
            catch (Exception ex)
            {
                if (RenderException != null)
                {
                    RenderException(ex);
                }
            }
            return string.Empty;
        }

        public string Parse(string templateContent, DynamicViewBag viewBag)
        {
            try
            {
                return Razor.Parse(templateContent, null, viewBag, null);
            }
            catch (Exception ex)
            {
                if (RenderException != null)
                {
                    RenderException(ex);
                }
            }
            return string.Empty;
        }
    }
}