using System;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning02 World!");
        
    }
}
public class Job
{
    public string _jobtitle;
    public string _company;
    public int _startYear;
    public int _endYear;
    public void Display()
    {
        Console.WriteLine($"{_jobtitle} ({_company} {_startYear}-{_endYear})");
    }
}
public class Resume
{
    public string _name;
    public List<Job> _jobs = new List<Job>();
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine($"Jobs:");
        foreach (Job job in _jobs)
        {
            job.Display();
        }
    }
}