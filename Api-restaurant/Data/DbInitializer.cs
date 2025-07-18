using Api_restaurant.Classes;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Api_restaurant.Data
{
    public class DbInitializer
    {
        public static void Database(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<RestaurantDb>();


            // Clients
            if (!db.Clients.Any())
            {
                var clientJson = File.ReadAllText("Data/clientsJson.json");
                var client = JsonSerializer.Deserialize<List<Client>>(clientJson);
                if(client != null)
                {
                    db.Clients.AddRange(client);
                }
            }

            // Articles
            if (!db.Articles.Any())
            {
                var articleJson = File.ReadAllText("Data/ArticlesJson.json");
                var article = JsonSerializer.Deserialize<List<Article>>(articleJson);
                if (article != null)
                {
                    db.Articles.AddRange(article);
                }
            }

            db.SaveChanges();
        }
    }
}
