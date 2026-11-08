public class Program
{

    public static void Main(string[] args)
    {
        string? value;
        value = Console.ReadLine();

        PolindromeCheck(value);
    }

    /// <summary>
    /// Checks if a string is a palindrome
    /// </summary>
    /// <param name="data"></param>
    private static void PolindromeCheck(string data)
    {
        bool result=true;
        for (int i = 0; i < data.Length/2; i++)
        {
            if(data[i] != data[data.Length -1 - i])
            {
                result = false;
                break;
            }
        }

        Console.WriteLine(result ? "String is Polindrome" : "String is not Polindrome");
    }
}