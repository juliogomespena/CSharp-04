
namespace CSharp___04;

internal class Ex03
{
    public static void Executar()
    {
        List<int> inteiros = new List<int> { 1, 2, 3, 4, };

        try
        {
            Console.WriteLine(inteiros[5]);
        }
        catch(ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
