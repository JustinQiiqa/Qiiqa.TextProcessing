namespace Qiiqa.TextProcessing.Analyzers.UnitTests;

[TestClass]
public class StandardFontBuilderTests
{
    [TestMethod]
    public void TestArialFontSymbols()
    {
        // Arrange
        var builder = new StandardFontBuilder();
        var font = builder.BuildFont("Arial");

        // Act
        var symbols = font.Symbols;

        // Assert
        Assert.AreEqual(95, symbols.Count);

        foreach (var symbol in symbols)
        {
            Assert.AreEqual(12f, symbol.Rect!.Value.Height, 0.1f);
        }
    }

    [TestMethod]
    public void TestCourierFontSymbols()
    {
        // Arrange
        var builder = new StandardFontBuilder();
        var font = builder.BuildFont("Courier New");

        // Act
        var symbols = font.Symbols;

        // Assert
        Assert.AreEqual(95, symbols.Count);

        foreach (var symbol in symbols)
        {
            Assert.AreEqual(12, symbol.Rect!.Value.Height, 0.1);
        }
    }

    [TestMethod]
    public void TestTahomaFontSymbols()
    {
        // Arrange
        var builder = new StandardFontBuilder();
        var font = builder.BuildFont("Tahoma");

        // Act
        var symbols = font.Symbols;

        // Assert
        Assert.AreEqual(95, symbols.Count);

        foreach (var symbol in symbols)
        {
            Assert.AreEqual(12, symbol.Rect!.Value.Height, 0.1f);
        }
    }

}