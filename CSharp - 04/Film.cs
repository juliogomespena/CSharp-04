using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharp___04;

internal class Film
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("rank")]
    public string Rank { get; set; }

    [JsonPropertyName("fullTitle")]
    public string Title { get; set; }

    [JsonPropertyName("year")]
    public string Year { get; set; }

    [JsonPropertyName("crew")]
    public string Crew { get; set; }

    public async Task Executar()
    {
        using (HttpClient client = new())
        {
            try
            {
                string filmResponse = await client.GetStringAsync("https://raw.githubusercontent.com/ArthurOcFernandes/Exerc-cios-C-/curso-4-aula-2/Jsons/TopMovies.json");

                var films = JsonSerializer.Deserialize<List<Film>>(filmResponse)!;

                var filmsFilteredByYear = films.Where(f => int.Parse(f.Year) > 2000)
                    .OrderBy(f => f.Year)
                    .ToList();

                var filmsFilteredByCrew = films.Where(f => f.Crew.IndexOf("Peter JaCKson", StringComparison.OrdinalIgnoreCase) >= 0).OrderBy(f => f.Title).ToList();

                foreach (var film in filmsFilteredByCrew)
                {
                    Console.WriteLine(film.Id);
                    Console.WriteLine(film.Title);
                    Console.WriteLine(film.Rank);
                    Console.WriteLine(film.Crew);
                    Console.WriteLine(film.Year);
                    Console.WriteLine();
                }

                string json = JsonSerializer.Serialize(filmsFilteredByYear);

                string fileName = "FilmsFilteredByYear.json";

                Console.WriteLine($"Json file generated sucessfully! {Path.GetFullPath(fileName)}");

                File.WriteAllText(fileName, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }            
    }
}
