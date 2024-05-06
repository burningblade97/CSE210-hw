using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGen = new Random();
        int number = randomGen.Next(1, 101);
        int guess = -1;
        
        while (guess != number)
        {
            Console.WriteLine("Try to guess my number: ");
            guess = int.Parse(Console.ReadLine());
            
            if (number > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (number < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You got it!");
            }
        }
    }
}