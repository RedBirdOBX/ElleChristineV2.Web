using ElleChristine.Web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;


namespace ElleChristine.Web.Pages
{
    public class ShowsModel : PageModel
    {
        private readonly ILogger<ShowsModel> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public List<Show> UpcomingShows { get; set; }
        public List<Show> PreviousShows { get; set; }

        public ShowsModel(ILogger<ShowsModel> logger, IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            UpcomingShows = new List<Show>();
            PreviousShows = new List<Show>();
        }

        public async Task OnGet()
        {
            await GetUpcomingShowsAsync();
            await GetPreviousShowsAsync();
        }

        private async Task GetUpcomingShowsAsync()
        {
            string url = $"{_configuration["APISettings:baseUrl"]}shows/filter";
            var filter = new ShowFilter() { Active = true, StartDate = DateTime.Today };
            var json = JsonConvert.SerializeObject(filter);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = content;

            // make the post
            HttpResponseMessage response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var results = await response.Content.ReadAsStringAsync();
                UpcomingShows = JsonConvert.DeserializeObject<List<Show>>(results) ?? new List<Show>();
            }
            else
            {
                _logger.LogWarning($"Did not get successful response from {url}");
            }
        }

        private async Task GetPreviousShowsAsync()
        {
            string url = $"{_configuration["APISettings:baseUrl"]}shows/filter";
            var filter = new ShowFilter() { Active = true, StartDate = DateTime.Today.AddYears(-365), EndDate = DateTime.Today.AddDays(-1) };
            var json = JsonConvert.SerializeObject(filter);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Content = content;

            // make the post
            HttpResponseMessage response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            if (response.IsSuccessStatusCode)
            {
                var results = await response.Content.ReadAsStringAsync();
                PreviousShows = JsonConvert.DeserializeObject<List<Show>>(results) ?? new List<Show>();
            }
            else
            {
                _logger.LogWarning($"Did not get successful response from {url}");
            }
        }
    }
}