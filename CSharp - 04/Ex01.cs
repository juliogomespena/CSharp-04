/*
    {
        "internalName":"BROTATO",
        "title":"Brotato",
        "metacriticLink":"\/game\/brotato\/",
        "dealID":"5hzUOEgnVu63Kr20QBhRJFXW2sy8oc2vAqlDU%2BKeMgk%3D",
        "storeID":"25",
        "gameID":"251420",
        "salePrice":"0.00",
        "normalPrice":"4.99",
        "isOnSale":"1",
        "savings":"100.000000",
        "metacriticScore":"76",
        "steamRatingText":"Overwhelmingly Positive",
        "steamRatingPercent":"96",
        "steamRatingCount":"83284",
        "steamAppID":"1942280",
        "releaseDate":1687478400,
        "lastChange":1732811588,
        "dealRating":"10.0",
        "thumb":"https:\/\/shared.fastly.steamstatic.com\/store_item_assets\/steam\/apps\/1942280\/capsule_sm_120.jpg?t=1732204619"
    }
 */

using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharp___04;

internal class Ex01
{
    [JsonPropertyName("title")]
    public string? Name { get; set; }

    [JsonPropertyName("storeID")]
    public string? StoreId { get; set; }

    [JsonPropertyName("isOnSale")]
    public string? Avaiable { get; set; }

    [JsonPropertyName("normalPrice")]
    public string? Price { get; set; }

    public async Task Executar()
    {
        string cheapSharkResponse;
        try 
        {
            using (HttpClient client = new())
            {
                cheapSharkResponse = await client.GetStringAsync("https://www.cheapshark.com/api/1.0/deals");
            }

            var games = JsonSerializer.Deserialize<List<Ex01>>(cheapSharkResponse)!;

            foreach(Ex01 game in games)
            {
                Console.WriteLine(game.Name);
                Console.WriteLine(game.StoreId);
                Console.WriteLine(game.Price);
                Console.WriteLine(game.Avaiable == "1" ? "Avaiable" : "Not avaiable");
                Console.WriteLine();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
