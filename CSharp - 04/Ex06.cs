using System.Text.Json;

namespace CSharp___04;

internal class Ex06
{
    public static void GravarJson()
    {
        Console.WriteLine("Digite o nome");
        string nome = Console.ReadLine();

        Console.WriteLine("Digite a idade");
        string idade = Console.ReadLine();

        Console.WriteLine("Digite o email");
        string email = Console.ReadLine();

        string jsonSerialize = JsonSerializer.Serialize(new
        {
            nome = nome,
            idade = idade,
            email = email
        });

        File.WriteAllText($"{nome}.json", jsonSerialize);
    }

    public static void LerJson()
    {
        string nome, idade, email;

        string jsonContent = File.ReadAllText("Julio Gomes Pena.json");
        
        using (JsonDocument doc = JsonDocument.Parse(jsonContent))
        {
            JsonElement root = doc.RootElement;
            nome = root.GetProperty("nome").GetString();
            idade = root.GetProperty("idade").GetString();
            email = root.GetProperty("email").GetString();
        }

        Console.WriteLine(nome);
        Console.WriteLine(idade);
        Console.WriteLine(email);
    }
}
