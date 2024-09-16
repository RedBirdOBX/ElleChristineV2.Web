using ElleChristine.Web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;

namespace ElleChristine.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        public Show NextShow;

        public HomePageTitle HomePageTitle;

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            HomePageTitle = new HomePageTitle();
            NextShow = new Show();
        }

        public async Task OnGet()
        {
            await GetNextShowAsync();
        }


        private async Task GetNextShowAsync()
        {
            string url = $"{_configuration["APISettings:baseUrl"]}shows/nextshow";
            var request = new HttpRequestMessage(HttpMethod.Get, url) { Headers = { { HeaderNames.Accept, "application/json" } } };
            var client = _httpClientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                NextShow = JsonConvert.DeserializeObject<Show>(json) ?? new Show();
            }
            else
            {
                _logger.LogWarning($"Did not get successful response from {url}");
            }
        }
    }
}