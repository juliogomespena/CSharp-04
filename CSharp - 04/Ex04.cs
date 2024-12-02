
namespace CSharp___04;

internal class Ex04
{
    public static async Task Executar()
    {
        string ratesRequest;
        try
        {
            using (HttpClient client = new HttpClient())
            {
                ratesRequest = await client.GetStringAsync("https://data.fixer.io/api/latest?access_key=39d5d8633d38b8ffb98a115855fe42c2&format=1");
                Console.WriteLine(ratesRequest);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }
}
