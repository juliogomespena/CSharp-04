using System.Threading.Channels;

namespace CSharp___04;

internal class Ex02
{
    public static void Executar()
    {
        Console.WriteLine("Digite uma divisão no modelo: X / Y");
        string? readResult = Console.ReadLine();
        string[] numbers = new string[1];

        if (readResult != null)
        {
            numbers = readResult.Split('/');
            numbers[0] = numbers[0].Trim();
            numbers[1] = numbers[1].Trim();

            int.TryParse(numbers[0], out  int number01);
            int.TryParse(numbers[1], out int number02);

            try
            {
                Console.WriteLine($"{number01} / {number02} = {number01 / number02}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        else
        {
            readResult = "Digite algo";
        }

    }
}
