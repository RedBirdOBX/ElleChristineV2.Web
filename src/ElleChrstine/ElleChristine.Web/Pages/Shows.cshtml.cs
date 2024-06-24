using ElleChristine.Web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;


namespace ElleChristine.Web.Pages
{
    public class ShowsModel : PageModel
    {
        private readonly ILogger<ShowsModel> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public List<Show> Shows { get; set; }

        public ShowsModel(ILogger<ShowsModel> logger, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            Shows = new List<Show>();
        }

        public async Task OnGet()
        {
            string url = $"{_configuration["APISettings:baseUrl"]}shows";
            var request = new HttpRequestMessage(HttpMethod.Get, url) { Headers = { { HeaderNames.Accept, "application/json" } } };
            var client = _httpClientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Shows = JsonConvert.DeserializeObject<List<Show>>(json) ?? new List<Show>();
            }
            else
            {
                _logger.LogWarning($"Did not get successful response from {url}");
            }
        }
    }
}