using EmailApplication.Implementation;

namespace EmailApplication
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            MailSender mailSender = new();

            Console.WriteLine("Sending test email...");
            //await mailSender.SendPlainTextEmail("saul.fuentes@jalasoft.com", "Test email", "Hello World from C#!!!");
            await mailSender.SendHtmlEmail("eliosfg@gmail.com", "Test email", "Hello World from C#!!!");
            Console.WriteLine("Email sent");
        }
    }
}