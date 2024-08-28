using ElleChristine.Web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;

namespace ElleChristine.Web.Pages
{
    public class GalleryModel : PageModel
    {
        private readonly ILogger<GalleryModel> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public List<Photo> Photos { get; set; }
        public List<Video> Videos { get; set; }

        public GalleryModel(ILogger<GalleryModel> logger, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            Photos = new List<Photo>();
            Videos = new List<Video>();
        }

        public async Task OnGet()
        {
            await GetPhotosAsync();
            await GetVideosAsync();
        }

        private async Task GetPhotosAsync()
        {
            string url = $"{_configuration["APISettings:baseUrl"]}photos";
            var request = new HttpRequestMessage(HttpMethod.Get, url) { Headers = { { HeaderNames.Accept, "application/json" } } };
            var client = _httpClientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Photos = JsonConvert.DeserializeObject<List<Photo>>(json) ?? new List<Photo>();
            }
            else
            {
                _logger.LogWarning($"Did not get successful response from {url}");
            }
        }

        private async Task GetVideosAsync()
        {
            string url = $"{_configuration["APISettings:baseUrl"]}videos";
            var request = new HttpRequestMessage(HttpMethod.Get, url) { Headers = { { HeaderNames.Accept, "application/json" } } };
            var client = _httpClientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Videos = JsonConvert.DeserializeObject<List<Video>>(json) ?? new List<Video>();
            }
            else
            {
                _logger.LogWarning($"Did not get successful response from {url}");
            }
        }
    }
}