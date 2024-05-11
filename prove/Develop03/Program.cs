using System;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Proverbs", 3, 5, 6);
        Scripture scripture = new Scripture(reference, "Trust in the Lord with all thine heart and lean not unto thine own understanding; in all thy ways acknowledge him, and he shall direct thy paths.");
        string entry = "";
        while(entry != "quit")
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            entry = Console.ReadLine();
            if(entry != "quit")
            {
                scripture.HideRandomWords(3);
            }
        }
        
                        
    }
}
public class Scripture
{
    private List<Word> _words; 
    private Reference _reference;
    public Scripture(Reference reference, string text)
    {
        _words = new List<Word>();
        _reference = reference;
        string[] words = text.Split(' ');
        foreach(string word in words)
        {
            _words.Add(new Word(word));
        }
    }
    public void HideRandomWords(int numbertohide)
    {
        int NumVisible = 0;
        foreach (Word word in _words) 
        {
            if (word.IsHidden() == false) NumVisible++;
        }
        if (numbertohide >= NumVisible) 
        {
            foreach (Word word in _words) 
            {
                word.Hide();
            }
        }
        else {
            Random random = new Random();
            while (numbertohide > 0)
            {
                int hidevisibleindex = random.Next(1, NumVisible);
                int visibleindex = 0;
                foreach (Word word in _words)
                {
                    if(word.IsHidden() == false)
                    {
                        visibleindex++;
                        if(visibleindex == hidevisibleindex)
                        {
                            word.Hide();
                            numbertohide--;
                            NumVisible--;
                            break;
                        }
                    }
                }
            }
        }
    }
    public string GetDisplayText()
    {
        string text = _reference.GetDisplayText();
        foreach(Word word in _words)
        {
            text += " " + word.GetDisplayText();
        }
        return text;
    }
    public bool IsCompletelyHidden()
    {
        bool allhidden = true;
        foreach(Word word in _words)
        {
            if(word.IsHidden() == false)
            {
                allhidden = false;
                break;
            }
        }
        return allhidden;
    }
    
}
public class Word
{
    private string _text;
    private bool _ishidden;
    public Word(string text)
    {
        _text = text;
        _ishidden = false;
    }
    public void Hide()
    {
        _ishidden = true;
    }
    public void Show()
    {
        _ishidden = false;
    }
    public bool IsHidden()
    {
        return _ishidden;
    }
    public string GetDisplayText()
    {
        if(_ishidden == false)
        {
            return _text;
        }
        else
        {
            string blank = "";
            for (int i = 0; i < _text.Length; i++)
            {
                blank += "_";
            }
            return blank;
        }
    }
}
public class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endverse;
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endverse = 0;
    }
    public Reference(string book, int chapter, int verse, int endverse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endverse = endverse;
    }
    public string GetDisplayText()
    {
        if (_endverse == 0)
        {
            return $"{_book} {_chapter}:{_verse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_verse}-{_endverse}";
        }
    }
    
}