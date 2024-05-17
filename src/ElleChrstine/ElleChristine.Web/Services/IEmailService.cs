using RVAGutterPros.Web.Models;

namespace RVAGutterPros.Web.Services
{
    public interface IEmailService
    {
        void SendAsync(ContactFormInputModel input);
    }
}
