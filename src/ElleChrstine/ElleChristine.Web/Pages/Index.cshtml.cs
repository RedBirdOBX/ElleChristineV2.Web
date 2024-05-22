using ElleChristine.Web.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace ElleChristine.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public List<Show> Shows { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            string file = "data.json";
            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            string fileAndPath = $"{appPath}Data\\{file}";

            FileInfo fileInfo = new FileInfo(fileAndPath);
            if (!fileInfo.Exists)
            {
                throw new ArgumentException($"File {fileInfo.FullName} does not exist.");
            }

            string json = System.IO.File.ReadAllText(fileAndPath);

            Shows = JsonConvert.DeserializeObject<List<Show>>(json);

        }
    }
}