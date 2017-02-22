using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var list = new[]
        {
            new { Username = "Falcore", Score = 1293, },
            new { Username = "Dunsby", Score = 2342, },
            new { Username = "Habisham", Score = 5234, },
        };

        var markdownTable = list.ToMarkdownTable();

        Console.WriteLine(markdownTable);
    }
}