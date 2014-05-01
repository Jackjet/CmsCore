using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CmsCore.Label;
using CmsCore.Label.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RazorEngine;

namespace CmsCore.Label.Tests
{
    [TestClass()]
    public class LabelManageTests
    {
        [TestMethod()]
        public void LabelManageTest()
        {
            //var result = LabelManage.Content.GetLists(new ContentLabelGetListsParam());

            var templateFileName = "LabelContentTest.cshtml";

            var templateFileResult = string.Format("{0}.result.html", templateFileName);

            //标签程序集仅加载一次
            AppDomain.CurrentDomain.Load(new AssemblyName("CmsCore.Label"));
            //AppDomain.CurrentDomain.Load(new AssemblyName("CmsCore.Label"));
            
            try
            {
                var templateContent = File.ReadAllText(templateFileName);

                var viewContent = Razor.Parse(templateContent);
                
                if (File.Exists(templateFileResult))
                {
                    File.Delete(templateFileResult);
                }

                File.AppendAllText(templateFileResult, viewContent);
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
            }

            Assert.Fail();
        }
    }
}