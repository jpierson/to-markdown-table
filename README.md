# ToMarkdownTable

An extension method for transforming tabular data into plain text in [Markdown table](https://github.com/adam-p/markdown-here/wiki/Markdown-Cheatsheet#tables) representation.

## Usage

C#: Transform an array to a Markdown table:

```c#
var list = new[]
{
    new { Username = "Falcore", Score = 1293, },
    new { Username = "Dunsby", Score = 2342, },
    new { Username = "Habisham", Score = 5234, },
};

var markdownTable = list.ToMarkdownTable();

Console.WriteLine(markdownTable);
```

| Username | Score |
| -------- | ----- |
| Falcore  | 1293  |
| Dunsby   | 2342  |
| Habisham | 5234  |

## Getting started

You can install ToMarkdownTable using [NuGet](https://www.nuget.org/).

```
PM> Install-Package ToMarkdownTable
```

## References

- Markdown - https://daringfireball.net/projects/markdown/