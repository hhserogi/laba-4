using System;

interface IPetActivity
{
    public void Eat(string comm);
    public void Walk(string comm);
    public void Health(string comm);
}
public class AnimalLogger : IPetActivity
{
    public string Name { get; private set; }
    public decimal Mood { get; private set; }
    public List<string> Comments { get; private set; }
    public List<string> Napomin { get; private set;  }
    public AnimalLogger(string name)
    {
        Name = name;
        Mood = 50m;
        Comments = new List<string> ();
        Napomin = new List<string> ();
    }
    public void Eat(string comm)
    {
        Comments.Add($"{Comments.Count + 1}) {Name} покормлен. {DateTime.Now}. Комментарий: {comm};");
        Mood += 10m;
        Console.WriteLine($"Настроение {Name} = {Mood}");
    }
    public void Walk(string comm)
    {
        Comments.Add($"{Comments.Count + 1}) {Name} прогулен. {DateTime.Now}. Комментарий: {comm};");
        Mood += 15m;
        Console.WriteLine($"Настроение {Name} = {Mood}");
    }
    public void Health(string comm)
    {
        Comments.Add($"{Comments.Count + 1}) {Name} сходил к ветеринару. {DateTime.Now}. Комментарий: {comm};");
        Mood -= 5m;
        Console.WriteLine($"Настроение {Name} = {Mood}");
    }
    public void DeleteStroke(int i)
    {
        Comments.RemoveAt(i-1);
        Mood -= 10m;
        Console.WriteLine($"Настроение {Name} = {Mood}");
    }
    public void History(string type)
    {
        for (int i = 0; i < Comments.Count; i++)
        {
            if (Comments[i].Contains(type))
            {
                Console.WriteLine($"{Comments[i]}");
            }
        }
    }
    public void History()
    {
        for (int i = 0; i < Comments.Count; i++)
        {
            Console.WriteLine($"{Comments[i]}");
        }
    }
    public void SetNapomin(string input, DateTime time)
    {
        string timeStr = time.ToString();
        Napomin.Add(input+", "+timeStr);
        Console.WriteLine($"{input}, {timeStr}");
    }
    public void PrintNapomin()
    {
        for (int i = 0; i < Napomin.Count; i++)
        {
            Console.WriteLine($"{Napomin[i]}");
        }
    }
}
