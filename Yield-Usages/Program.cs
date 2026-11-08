class Program
{
    // Method that generates even numbers up to a specified limit using deferred execution
    static IEnumerable<int> GetEvenNumbers(int upto)
    {
        for (int i = 0; i <= upto; i += 2)
        {
            yield return i;
            Console.WriteLine("print");
        }
    }

    static void Main(string[] args)
    {
        // The method call doesn't execute immediately due to the 'yield return' keyword
        IEnumerable<int> getEventNumbers = GetEvenNumbers(10);

        // Iterating through the collection triggers the actual execution step-by-step
        foreach (int eventNumber in getEventNumbers)
        {
            Console.WriteLine(eventNumber);
        }
    }
}