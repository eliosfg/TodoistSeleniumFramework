using EmailApplication.config;
using EmailApplication.Implementation;
using EmailApplication.Utils;

namespace EmailApplication
{
    public class Program
    {
        public static async Task Main(string[] arguments)
        {
            MailSender mailSender = new();
            string emailRecipient = "";
            string emailSubject = "";


            for (int index = 0; index < arguments.Length; index++)
            {
                string argument = arguments[index];

                switch (argument)
                {
                    case "--email":
                        emailRecipient = arguments[index + 1];
                        break;

                    case "--subject":
                        emailSubject = arguments[index + 1];
                        break;

                    default:
                        break;
                }

                Console.WriteLine(argument);
            }

            if (emailRecipient.Length > 0)
            {
                Console.WriteLine("Sending report email...");
                await mailSender.SendHtmlEmail(emailRecipient, emailSubject);
                Console.WriteLine("Email sent successfully!");
            }
            else
            {
                Console.WriteLine("You need to specify the \"--email\" and  \"--subject\" arguments to send an email");
            }
        }
    }
}