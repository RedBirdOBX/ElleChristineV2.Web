using ElleChristine.Web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace ElleChristine.Web.Pages
{
    public class ShowsModel2 : PageModel
    {
        private readonly ILogger<ShowsModel> _logger;

        public List<Show> Shows { get; set; }

        public ShowsModel2(ILogger<ShowsModel> logger)
        {
            _logger = logger;
            Shows = new List<Show>();
        }

        public void OnGet()
        {
            string file = "data.json";
            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            string fileAndPath = $"{appPath}data\\{file}";

            FileInfo fileInfo = new FileInfo(fileAndPath);
            if (!fileInfo.Exists)
            {
                throw new ArgumentException($"File {fileInfo.FullName} does not exist.");
            }

            string json = System.IO.File.ReadAllText(fileAndPath);
            if (!string.IsNullOrEmpty(json))
            {
                Shows = JsonConvert.DeserializeObject<List<Show>>(json);
            }
        }
    }
}