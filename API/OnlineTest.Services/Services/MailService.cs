using MailKit.Net.Smtp;
using MimeKit;
using OnlineTest.Services.Configuration;
using OnlineTest.Services.DTO;
using OnlineTest.Services.Interface;

namespace OnlineTest.Services.Services
{
    public class MailService : IMailService
    {
        #region Fields
        private readonly MailConfiguration _mailConfig;
        #endregion

        #region Constructor
        public MailService(MailConfiguration mailConfig)
        {
            _mailConfig = mailConfig;
        }
        #endregion

        #region Methods
        public bool SendMail(MailDTO mail)
        {
            // create mail
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_mailConfig.DisplayName, _mailConfig.From));
            emailMessage.To.Add(MailboxAddress.Parse(mail.To));
            emailMessage.Subject = mail.Subject;
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = mail.Body;
            emailMessage.Body = bodyBuilder.ToMessageBody();

            // send mail
            bool successFlag;
            using (var smtp = new SmtpClient())
            {
                try
                {
                    smtp.Connect(_mailConfig.Host, _mailConfig.Port, true);
                    smtp.Authenticate(_mailConfig.From, _mailConfig.Password);
                    smtp.Send(emailMessage);
                    successFlag = true;
                }
                catch (Exception)
                {
                    successFlag = false;
                }
                finally
                {
                    smtp.Disconnect(true);
                    smtp.Dispose();
                }
            }

            return successFlag;
        }
        #endregion
    }
}