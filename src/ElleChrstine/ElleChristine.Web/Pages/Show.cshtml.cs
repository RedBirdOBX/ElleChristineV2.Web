using ElleChristine.Web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;


namespace ElleChristine.Web.Pages
{
    public class ShowModel : PageModel
    {
        private readonly ILogger<ShowsModel> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public Show Show { get; set; }

        public ShowModel(ILogger<ShowsModel> logger, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            Show = new Show();
        }

        public async Task OnGet(int showId)
        {
            string url = $"{_configuration["APISettings:baseUrl"]}shows/{showId}";
            var request = new HttpRequestMessage(HttpMethod.Get, url) { Headers = { { HeaderNames.Accept, "application/json" } } };
            var client = _httpClientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Show = JsonConvert.DeserializeObject<Show>(json) ?? new Show();
            }
            else
            {
                _logger.LogWarning($"Did not get successful response from {url}");
            }
        }
    }
}