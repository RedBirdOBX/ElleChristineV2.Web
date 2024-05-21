using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ElleChristine.Web.Pages
{
    public class GalleryModel : PageModel
    {
        private readonly ILogger<GalleryModel> _logger;

        public GalleryModel(ILogger<GalleryModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}