using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ElleChristine.Web.Models;
using ElleChristine.Web.Services;

namespace ElleChristine.Web.Pages
{
    public class MediaModel : PageModel
    {
        private readonly ILogger<MediaModel> _logger;
        private readonly IEmailService _emailService;


        [BindProperty]
        public ContactFormInputModel ContactFormInputModel { get; set; }

        [TempData]
        public bool FormSubmitted { get; set; }

        public MediaModel(ILogger<MediaModel> logger, IEmailService emailService)
        {
            _logger = logger;
            _emailService = emailService;
            ContactFormInputModel = new ContactFormInputModel();
        }

        public void OnGet()
        {
            ContactFormInputModel= new ContactFormInputModel();
        }
    }
}