using OnlineTest.Services.DTO;

namespace OnlineTest.Services.Interface
{
    public interface IMailService
    {
        bool SendMail(MailDTO mail);
    }
}
