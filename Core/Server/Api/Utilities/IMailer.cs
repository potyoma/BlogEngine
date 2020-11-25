using System.Threading.Tasks;

namespace BlogEngineApi.Utilities
{
    public interface IMailer
    {
        Task SendEmailAsync(string email, string subject, string body);
    }
}