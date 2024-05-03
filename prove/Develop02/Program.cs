using System;
using System.Runtime.CompilerServices;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        Prompts prompt = new Prompts();
        while (true)
        {
            Console.WriteLine("Please select one of the following options:");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Load");
        Console.WriteLine("4. Save");
        Console.WriteLine("5. Quit");
        Console.WriteLine("What would you like to do?");
        string choice = Console.ReadLine();
        if (choice == "1")
        {
            Console.WriteLine(prompt.GetRandomPrompt());
        }
        else if (choice == "2")
        {
            journal.DisplayAll();
        }
        else if (choice == "3")
        {
            Console.WriteLine("What file would you like to load?");
            string filething = Console.ReadLine();
            journal.Load(filething);
        }
        else if (choice == "4")
        {
            Console.WriteLine("What is the name of this file?");
            string name = Console.ReadLine();
            journal.Save(name);
        }
        else if (choice == "5")
        {
            break;
        }
        else
        {
            Console.WriteLine("Invalid Command.");
        }
        }
        
    }
}
public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void DisplayAll()
    {
        foreach(Entry Item in _entries)
        {
            Item.Display();
        }
    }
    public void Load(string file)
    {
        using (StreamReader inputFile = new StreamReader(file))
        {
            while (inputFile.EndOfStream == false)
            {
                Entry item = new Entry();
                item._date = inputFile.ReadLine();
                if (item._date == null) break;
                item._promptText = inputFile.ReadLine();
                if (item._promptText == null) break;
                item._entryText = inputFile.ReadLine();
                if (item._entryText == null) break;
                AddEntry(item);
            }
        }
    }
    public void Save(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry item in _entries)
            {
                outputFile.WriteLine(item._date);
                outputFile.WriteLine(item._promptText);
                outputFile.WriteLine(item._entryText);
            }
        }
    }
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }
}
public class Entry
{
    public string _date;
    
    public string _promptText;
    public string _entryText;

    public void Display()
    {
        Console.WriteLine(_date);
        Console.WriteLine(_promptText);
        Console.WriteLine(_entryText);
    }
    
}
public class Prompts
{
    public List<string> _prompts;
    public void prompts() 
    {
        _prompts = new List<string>();
        _prompts.Add("What was the most interesting thing that happened today?");
        _prompts.Add("What was the strongest emotion I felt today?");
        _prompts.Add("If I could do one thing over today, what would it be?");
        _prompts.Add("How did the Lord affect my life today?");
        _prompts.Add("Was there anything today that inspired me today?");
    }
    public string GetRandomPrompt()
    {
        Random random = new Random();
        int i = random.Next(0, _prompts.Count - 1);
        return _prompts[i];
    }
}