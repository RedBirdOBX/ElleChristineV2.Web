using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RVAGutterPros.Web.Pages
{
    public class ShowsModel : PageModel
    {
        private readonly ILogger<ShowsModel> _logger;

        public ShowsModel(ILogger<ShowsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}