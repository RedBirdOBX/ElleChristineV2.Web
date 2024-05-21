using ElleChristine.Web.Models;

namespace ElleChristine.Web.Services
{
    public interface IEmailService
    {
        void SendAsync(ContactFormInputModel input);
    }
}
