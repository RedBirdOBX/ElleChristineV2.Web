using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ElleChristine.Web.Pages
{
    public class Code404Model : PageModel
    {
        private readonly ILogger<Code404Model> _logger;

        [TempData]
        public bool FormSubmitted { get; set; }

        public Code404Model(ILogger<Code404Model> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}