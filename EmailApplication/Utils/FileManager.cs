using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailApplication.Utils
{
    public class FileManager
    {
        private readonly string rootPath;

        public FileManager(string rootPath)
        {
            this.rootPath = rootPath;
        }

        public string GetLastHtmlReportFile()
        {
            var htmlFile = Directory.GetFiles(rootPath, "*.html");

            return htmlFile[^1];
        }
    }
}
