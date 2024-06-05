using Microsoft.Extensions.Logging;
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using ElleChristine.Web.Models;

namespace ElleChristine.Web.Services
{
    // https://learn.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-6.0
    //public class APIService(IHttpClientFactory httpClientFactory)
    //{
    //    public async Task<Show[]> GetShowsAsync()
    //    {
    //        // Create the client
    //        using HttpClient client = httpClientFactory.CreateClient();

    //        try
    //        {
    //            // Make HTTP GET request
    //            // Parse JSON response deserialize into Todo types
    //            Show[]? shows = await client.GetFromJsonAsync<Show[]>($"https://jsonplaceholder.typicode.com/todos?userId={userId}",new JsonSerializerOptions(JsonSerializerDefaults.Web));

    //            return shows ?? [];
    //        }
    //        catch (Exception ex)
    //        {
    //            //logger.LogError("Error getting something fun to say: {Error}", ex);
    //        }

    //        return [];
    //    }
    //}
}
