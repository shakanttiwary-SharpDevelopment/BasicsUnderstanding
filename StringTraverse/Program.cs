using System;
using System.Text;

public class Program
{
    public static void Main()
    {
        var sentence = "Hi My name is Shashi";
        string word = "";
        string result = "";
        for (int i = 0; i <= sentence.Length; i++)
        {
            if (i == sentence.Length || sentence[i] == ' ')
            {
                result = word + (result == "" ? "" : " " + result);
                word = "";
            }
            else
            {
                word += sentence[i];
            }
        }

        Console.WriteLine("Output : -" + result);
    }
}