using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ElleChristine.Web.Pages
{
    public class MediaModel : PageModel
    {
        private readonly ILogger<MediaModel> _logger;

        public MediaModel(ILogger<MediaModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}