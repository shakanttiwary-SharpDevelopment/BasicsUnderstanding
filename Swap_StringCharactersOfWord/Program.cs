using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a string to process:");

        string data = Console.ReadLine();

        string result = PrintMessage(data);
        Console.WriteLine("Processed string: " + result);
    }

    public static string PrintMessage(string data)
    {
        StringBuilder sb = new StringBuilder();
        char[] charArray = data.ToCharArray();

        for(int i=0; i < data.Length; i++)
        {
            if(i != (data.Length -1))
                sb.Append(data[i+1]); // Append the next character

            sb.Append(data[i]); // Append previous character

            i++; // Increment i to skip the next character since it's already appended
        }

        return sb.ToString();
    }
}