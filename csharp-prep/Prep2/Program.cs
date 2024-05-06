using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter Grade Percentage:");
        string entry = Console.ReadLine();
        int grade = int.Parse(entry);
        string letter = "";
        string pass = "You have passed!";
        string fail = "You can always try again.";
        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
        Console.WriteLine("Your grade is: " + letter);
        if (grade >= 70)
        {
            Console.WriteLine(pass);
        }
        else
        {
            Console.WriteLine(fail);
        }
    }
}