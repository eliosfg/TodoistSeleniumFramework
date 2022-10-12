using Microsoft.Extensions.Configuration;

namespace EmailApplication.config
{
    public class Config
    {
        private IConfigurationRoot _configuration;
        private string currentProjectDirectory;

        public Config()
        {
            string workingDirectory = Environment.CurrentDirectory;
            currentProjectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;

            _configuration = new ConfigurationBuilder()
                .AddJsonFile(currentProjectDirectory + "/config/appsettings.json")
                .Build();
        }

        public string GetFrom()
        {
            return _configuration.GetSection("Mail")["From"];
        }

        public string GetEmailSender()
        {
            return _configuration.GetSection("Gmail")["Sender"];
        }

        public string GetEmailPassword()
        {
            return _configuration.GetSection("Gmail")["password"];
        }

        public int GetEmailPort()
        {
            return int.Parse(_configuration.GetSection("Gmail")["Port"]);
        }

        public string GetSmtpClient()
        {
            return _configuration.GetSection("SmtpClient").Value;
        }

        public string GetHtmlReportPath()
        {
            return Directory.GetParent(currentProjectDirectory)?.FullName + @"\TodoistXUnitTests\TestResults\";
        }
    }
}
