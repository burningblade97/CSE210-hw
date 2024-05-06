using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        List<int> numbers = new List<int>();
        int input = -1;
        while (input != 0)
        {
            
            Console.WriteLine("Enter number: ");
            input = int.Parse(Console.ReadLine());
            if (input != 0)
            {
                numbers.Add(input);
            }
        }
        int total = 0;
        foreach (int number in numbers)
        {
            total += number;
        }
        Console.WriteLine("The sum is: " + total);

        float average = ((float)total) / numbers.Count;
        Console.WriteLine("The average is: " + average);

        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }
        Console.WriteLine("The max is: " + max);
    }
}