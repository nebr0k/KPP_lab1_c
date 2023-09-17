

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

public class Toy
{
    public string Name { get; set; }
    public int Price { get; set; }
    public string AgeRange { get; set; }
    public string SpecialAttribute { get; set; }

    public Toy(string name, int price, string ageRange, string specialAttribute)
    {
        Name = name;
        Price = price;
        AgeRange = ageRange;
        SpecialAttribute = specialAttribute;
    }
}

public class ToyInfo
{
    public static void Main(string[] args)
    {
        List<Toy> toys = ReadFile("toys.txt");

        foreach (var toy in toys.Where(t => t.Name == "blocks").OrderBy(t => t.Price))
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine($"{toy.Name} - {toy.Price / 100} грн і {toy.Price % 100:D2} коп. кількість: {toy.SpecialAttribute}");
        }
    }

    public static List<Toy> ReadFile(string fileName)
    {
        var toys = new List<Toy>();

        try
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split(", ");
                    toys.Add(new Toy(parts[0], int.Parse(parts[1]), parts[2], parts[3]));
                }
            }
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }

        return toys;
    }
}