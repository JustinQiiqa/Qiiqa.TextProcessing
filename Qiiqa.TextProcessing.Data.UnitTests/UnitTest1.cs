using System.Drawing;

namespace Qiiqa.TextProcessing.Data.UnitTests;

[TestClass]
public class UnitTest1
{
    /// <summary>Add symbols to a word and verify that the Rect and Color properties are correctly recalculated.</summary>
    [TestMethod]
    public void TestTextWordRecalculate()
    {
        // Arrange
        var symbols = new List<TextSymbol>
        {
            new TextSymbol { Text = "A", Rect = new RectangleF(10, 13, 8, 10), Color = Color.Orange },
            new TextSymbol { Text = "B", Rect = new RectangleF(22, 12, 9, 10), Color = Color.Orange },
            new TextSymbol { Text = "C", Rect = new RectangleF(44, 11, 10, 10), Color = Color.Orange },
            new TextSymbol { Text = "D", Rect = new RectangleF(66, 12, 10, 10), Color = Color.Blue }
        };

        var word = new TextWord();

        // Act
        word.AddSymbols(symbols);

        // Assert
        Assert.AreEqual(new RectangleF(10, 11, 66, 12), word.Rect);

        var avgColor = Color.FromArgb(255, 191, 123, 63);
        Assert.AreEqual(avgColor.ToArgb(), word.Color?.ToArgb());
    }

    /// <summary>Add words to a line and verify that the Rect and Color properties are correctly recalculated.</summary>
    [TestMethod]
    public void TestTextLineRecalculate()
    {
        // Arrange
        var words = new List<TextWord>
        {
            new TextWord(new List<TextSymbol>
            {
                new TextSymbol { Text = "A", Rect = new RectangleF(10, 13, 8, 10), Color = Color.Orange },
                new TextSymbol { Text = "B", Rect = new RectangleF(22, 12, 9, 10), Color = Color.Orange },
                new TextSymbol { Text = "C", Rect = new RectangleF(44, 11, 10, 10), Color = Color.Orange }
            }),
            new TextWord(new List<TextSymbol>
            {
                new TextSymbol { Text = "D", Rect = new RectangleF(60, 15, 7, 10), Color = Color.Blue },
                new TextSymbol { Text = "E", Rect = new RectangleF(70, 14, 8, 10), Color = Color.Blue },
                new TextSymbol { Text = "F", Rect = new RectangleF(84, 13, 10, 10), Color = Color.Blue }
            })
        };

        var line = new TextLine();

        // Act
        line.Words.AddRange(words);
        line.Recalculate();

        // Assert
        Assert.AreEqual(new RectangleF(10, 11, 84, 14), line.Rect);
        Assert.AreEqual(Color.Orange, line.Color);
    }


    [TestMethod]
    public void CreateTextEntities_CheckProperties()
    {
        // Create a single Page with a Block, Line, Word, and Symbol
        var symbol = new TextSymbol()
        {
            Text = "A",
            Rect = new RectangleF { X = 100, Y = 100, Width = 10, Height = 10 },
            BaseLine = 90,
            Color = Color.Red,
        };

        var word = new TextWord()
        {
            Text = "Apple",
            Rect = new RectangleF() { X = 50, Y = 80, Width = 50, Height = 10 },
            BaseLine = 70,
            Color = Color.Green,
            Symbols = new List<TextSymbol>() { symbol }
        };

        var line = new TextLine()
        {
            Text = "The quick brown fox jumps over the lazy dog.",
            Rect = new RectangleF() { X = 10, Y = 50, Width = 500, Height = 10 },
            BaseLine = 40,
            Color = Color.Blue,
            Words = new List<TextWord>() { word }
        };

        var block = new TextBlock()
        {
            Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
            Rect = new RectangleF() { X = 0, Y = 0, Width = 500, Height = 100 },
            BaseLine = 30,
            Color = Color.Black,
            Lines = new List<TextLine>() { line }
        };

        var page = new TextPage()
        {
            Blocks = new List<TextBlock>() { block }
        };

        // Test some properties of the entities
        Assert.AreEqual("A", symbol.Text);
        Assert.AreEqual(100, symbol.Rect?.X);
        Assert.AreEqual(70, word.BaseLine);
        Assert.AreEqual(1, line.Words.Count);
        Assert.AreEqual("Apple", line.Words[0].Text);
        Assert.AreEqual(1, block.Lines.Count);
        Assert.AreEqual(40, block.Lines[0].BaseLine);
        Assert.AreEqual(1, page.Blocks.Count);
        Assert.AreEqual(0, page.Blocks[0].Rect?.Y);
    }
}