class Program
{
    static void Main(string[] args)
    {
        //PrintMessage();
        PrintMessageAsync();
        Console.WriteLine("Main Executed");
    }

    public async static Task PrintMessageAsync()
    {
        await Task.Delay(1000); // Simulate some work  
        Console.WriteLine("Print Message Executing");
    }


    public static void PrintMessage()
    {
        Task.Delay(1000).Wait(); // Simulate some work  
        Console.WriteLine("Print Message Executing");
    }

}