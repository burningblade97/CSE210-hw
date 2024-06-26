using System;
using System.ComponentModel;

class Program
{
    static void Main(string[] args)
    {
        static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to the program!");
        }
        static string PromptUserName()
        {
            Console.WriteLine($"Please enter your name: ");
            string name = Console.ReadLine();
            return name;
        }
        static int PromptUserNumber()
        {
            Console.WriteLine($"Please enter your favorite number: ");
            int number = int.Parse(Console.ReadLine());
            return number;
        }
        static int SquareNumber(int number)
        {
            int square = number * number;
            return square;
        }
        static void DisplayResults(string name, int square)
        {
            Console.WriteLine(name + ", the square of your number is " + square);
        }
        DisplayWelcome();
        string username = PromptUserName();
        int usernumber = PromptUserNumber();
        int squarenumber = SquareNumber(usernumber);
        DisplayResults(username, squarenumber);
    }
}