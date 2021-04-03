using System;
using System.Linq;
using Xunit;

namespace Tests
{
    public class LinqMarkdownTableExtensionsTest
    {
        [Fact]
        public void ShouldProduceMarkdownTableWithStringAndNumericColumn()
        {
            var list = new[]
            {
                new { Username = "Falcore", Score = 1293, },
                new { Username = "Dunsby", Score = 2342, },
                new { Username = "Habisham", Score = 5234, },
            };

            var markdownTable = list.ToMarkdownTable();

            string expectedMarkdownTable = 
@"| Username | Score |
| -------- | -----:|
| Falcore  | 1293  |
| Dunsby   | 2342  |
| Habisham | 5234  |";

            Assert.Equal(markdownTable, expectedMarkdownTable);
        }
    }
}
