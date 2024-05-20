using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RVAGutterPros.Web.Models;
using RVAGutterPros.Web.Services;

namespace RVAGutterPros.Web.Pages
{
    public class Code404Model : PageModel
    {
        private readonly ILogger<Code404Model> _logger;
        private readonly IEmailService _emailService;


        [BindProperty]
        public ContactFormInputModel ContactFormInputModel { get; set; }

        [TempData]
        public bool FormSubmitted { get; set; }

        public Code404Model(ILogger<Code404Model> logger, IEmailService emailService)
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