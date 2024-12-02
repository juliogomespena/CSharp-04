namespace CSharp___04;

internal class Ex05
{
    public static void Executar()
    {
        Dictionary<string, int> productList = new();
        Random rand = new();

        for (int i = 0; i < 100; i++)
        {
            productList.Add($"Product{i}", rand.Next(1, 50));
        }

        decimal averagePriceOfProducts = (decimal)productList.Select(p => p.Value).Average();

        Console.WriteLine(averagePriceOfProducts);
    }
}
