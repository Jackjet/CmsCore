using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsCore.Service
{
    public class DefaultPublishEngine : IPublishEngine
    {
        public void Push(PublishResult result)
        {
            //构建本地目录
            var directoryPath = string.Format("{0}\\{1}",
                AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\'),
                result.Path.TrimStart('/').Trim().Replace("/", "\\"));

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var filePath = string.Format("{0}\\{1}.html", directoryPath.TrimEnd('\\'), result.FileName);

            //删除现有的文件
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            //模板渲染结果写入到本地文件
            File.AppendAllText(filePath, result.Context, Encoding.UTF8);
        }
    }
}
