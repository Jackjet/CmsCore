using System;
using RazorEngine.Templating;

namespace CmsCore.Service
{
    public delegate void OnException(Exception e);

    public interface IParseEngine
    {
        event OnException RenderException;

        string TemplateRootDirectory { get; set; }

        void Init();

        string Parse(string templateContent);

        string Parse(string templateContent, DynamicViewBag viewBag);
    }
}