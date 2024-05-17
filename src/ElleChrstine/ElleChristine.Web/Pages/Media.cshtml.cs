using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RVAGutterPros.Web.Models;
using RVAGutterPros.Web.Services;

namespace RVAGutterPros.Web.Pages
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

        public IActionResult OnPost()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                FormSubmitted = true;
                _emailService.SendAsync(ContactFormInputModel);
                return RedirectToPage("/Contact");
            }
        }
    }
}