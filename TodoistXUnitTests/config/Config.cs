﻿using Microsoft.Extensions.Configuration;

namespace TodoistXUnitTests.config
{
    public class Config
    {
        private IConfigurationRoot _configuration;
        public string CurrentProjectDirectory { get; }
        public string CurrentSolutionDirectory { get; }

        public Config()
        {
            string workingDirectory = Environment.CurrentDirectory;
            CurrentProjectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            CurrentSolutionDirectory = Directory.GetParent(workingDirectory).Parent.Parent.Parent.FullName;

            _configuration = new ConfigurationBuilder()
                .AddJsonFile(CurrentProjectDirectory + "/config/appSettings.json")
                .Build();
        }

        public string GetBaseUrl()
        {
            return _configuration.GetSection("baseUrl").Value;
        }

        public string GetBrowserType()
        {
            return _configuration.GetSection("browserType").Value;
        }

        public string GetReportFilename()
        {
            return CurrentSolutionDirectory + @"\reports\testResults.html";
        }
    }
}
