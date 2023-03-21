//using Qiiqa.TextProcessing.Data;

//using System.Drawing;

//namespace Qiiqa.TextProcessing.Analyzers.UnitTests;

//[TestClass]
//public class FontsBuilderTests
//{
//    private readonly FontBuilder _fontBuilder = new FontBuilder
//    {
//        AllowedPercentageDifferenceSize = 10,
//        AllowedPercentageDifferenceColor = 5
//    };

//    /// <summary>
//    /// In this test method, we have four symbols with the same color, but their size differs by more than 10%. 
//    /// We set the AllowedPercentageDifferenceSize property to 15%, which means symbols with a size difference of 15% 
//    /// or less will be considered the same. We then call the BuildFont method and verify that the correct fonts are 
//    /// returned. In this case, we expect to have two fonts: one for symbols A and B, and one for symbols C and D.
//    /// </summary>
//    [TestMethod]
//    public void BuildFonts_SymbolsWithPercentageDifference_ReturnsCorrectFonts()
//    {
//        // Arrange
//        var symbols = new List<TextSymbol>
//        {
//            new TextSymbol { Text = "A", Rect = new RectangleF(0, 0, 10, 10), Color = Color.Black.ToArgb() },
//            new TextSymbol { Text = "B", Rect = new RectangleF(10, 0, 10, 10), Color = Color.Black.ToArgb() },
//            new TextSymbol { Text = "C", Rect = new RectangleF(20, 0, 11, 10), Color = Color.Black.ToArgb() },
//            new TextSymbol { Text = "D", Rect = new RectangleF(31, 0, 9, 10), Color = Color.Black.ToArgb() }
//        };

//        _fontBuilder.AllowedPercentageDifferenceSize = 15;

//        // Act
//        var fonts = _fontBuilder.BuildFonts(symbols);

//        // Assert
//        Assert.AreEqual(2, fonts.Count);

//        var regularFont = fonts.FirstOrDefault(f => f.FontName == "Regular");
//        var largeFont = fonts.FirstOrDefault(f => f.FontName == "Large");

//        Assert.IsNotNull(regularFont);
//        Assert.IsNotNull(largeFont);

//        CollectionAssert.AreEqual(new List<TextSymbol> { symbols[0], symbols[1] }, regularFont.Symbols);
//        CollectionAssert.AreEqual(new List<TextSymbol> { symbols[2], symbols[3] }, largeFont.Symbols);
//    }

//    [TestMethod]
//    public void BuildFonts_NoSymbols_ReturnsNoFonts()
//    {
//        // Arrange
//        var symbols = new List<TextSymbol>();

//        // Act
//        var fonts = _fontBuilder.BuildFont(symbols);

//        // Assert
//        Assert.AreEqual(0, fonts.Count);
//    }

//    [TestMethod]
//    public void BuildFonts_SymbolsOfSingleSize_ReturnsSingleFont()
//    {
//        // Arrange
//        var symbols = new List<TextSymbol>
//        {
//            new TextSymbol { Text = "A", Rect = new RectangleF(0, 0, 10, 10), Color = Color.Black.ToArgb() },
//            new TextSymbol { Text = "B", Rect = new RectangleF(10, 0, 10, 10), Color = Color.Black.ToArgb() },
//            new TextSymbol { Text = "C", Rect = new RectangleF(20, 0, 10, 10), Color = Color.Black.ToArgb() }
//        };

//        // Act
//        var fonts = _fontBuilder.BuildFonts(symbols);

//        // Assert
//        Assert.AreEqual(1, fonts.Count);
//        Assert.AreEqual("Regular", fonts[0].FontName);
//        CollectionAssert.AreEqual(symbols, fonts[0].Symbols);
//    }

//    [TestMethod]
//    public void BuildFonts_SymbolsOfTwoSizes_ReturnsTwoFonts()
//    {
//        // Arrange
//        var symbols = new List<TextSymbol>
//        {
//            new TextSymbol { Text = "A", Rect = new RectangleF(0, 0, 10, 10), Color = Color.Black.ToArgb() },
//            new TextSymbol { Text = "B", Rect = new RectangleF(10, 0, 10, 10), Color = Color.Black.ToArgb() },
//            new TextSymbol { Text = "C", Rect = new RectangleF(20, 0, 20, 10), Color = Color.Black.ToArgb() },
//            new TextSymbol { Text = "D", Rect = new RectangleF(40, 0, 20, 10), Color = Color.Black.ToArgb() }
//        };

//        // Act
//        var fonts = _fontBuilder.BuildFonts(symbols);

//        // Assert
//        Assert.AreEqual(2, fonts.Count);

//        var regularFont = fonts.FirstOrDefault(f => f.FontName == "Regular");
//        var largeFont = fonts.FirstOrDefault(f => f.FontName == "Large");

//        Assert.IsNotNull(regularFont);
//        Assert.IsNotNull(largeFont);

//        CollectionAssert.AreEqual(new List<TextSymbol> { symbols[0], symbols[1] }, regularFont.Symbols);
//        CollectionAssert.AreEqual(new List<TextSymbol> { symbols[2], symbols[3] }, largeFont.Symbols);
//    }

//    [TestMethod]
//    public void BuildFonts_SymbolsOfTwoColors_ReturnsTwoFonts()
//    {
//        // Arrange
//        var symbols = new List<TextSymbol>
//        {
//            new TextSymbol { Text = "A",
//        },
//        new TextSymbol { Text = "C", Rect = new RectangleF(20, 0, 10, 10), Color = Color.Red.ToArgb() },
//        new TextSymbol { Text = "D", Rect = new RectangleF(30, 0, 10, 10), Color = Color.Red.ToArgb() }
//    };

//        // Act
//        var fonts = _fontBuilder.BuildFonts(symbols);

//        // Assert
//        Assert.AreEqual(2, fonts.Count);

//        var blackFont = fonts.FirstOrDefault(f => f.FontName == "Black");
//        var redFont = fonts.FirstOrDefault(f => f.FontName == "Red");

//        Assert.IsNotNull(blackFont);
//        Assert.IsNotNull(redFont);

//        CollectionAssert.AreEqual(new List<TextSymbol> { symbols[0], symbols[1] }, blackFont.Symbols);
//        CollectionAssert.AreEqual(new List<TextSymbol> { symbols[2], symbols[3] }, redFont.Symbols);
//    }

//    [TestMethod]
//    public void BuildFonts_SymbolsOfDifferentSizesAndColors_ReturnsCorrectFonts()
//    {
//        // Arrange
//        var symbols = new List<TextSymbol>
//    {
//        new TextSymbol { Text = "A", Rect = new RectangleF(0, 0, 10, 10), Color = Color.Black.ToArgb() },
//        new TextSymbol { Text = "B", Rect = new RectangleF(10, 0, 10, 10), Color = Color.Black.ToArgb() },
//        new TextSymbol { Text = "C", Rect = new RectangleF(20, 0, 20, 10), Color = Color.Black.ToArgb() },
//        new TextSymbol { Text = "D", Rect = new RectangleF(40, 0, 20, 10), Color = Color.Black.ToArgb() },
//        new TextSymbol { Text = "E", Rect = new RectangleF(60, 0, 20, 10), Color = Color.Blue.ToArgb() },
//        new TextSymbol { Text = "F", Rect = new RectangleF(80, 0, 30, 10), Color = Color.Blue.ToArgb() },
//        new TextSymbol { Text = "G", Rect = new RectangleF(110, 0, 30, 10), Color = Color.Red.ToArgb() },
//        new TextSymbol { Text = "H", Rect = new RectangleF(140, 0, 20, 10), Color = Color.Red.ToArgb() }
//    };

//        // Act
//        var fonts = _fontBuilder.BuildFonts(symbols);

//        // Assert
//        Assert.AreEqual(4, fonts.Count);

//        var regularFont = fonts.FirstOrDefault(f => f.FontName == "Regular");
//        var largeFont = fonts.FirstOrDefault(f => f.FontName == "Large");
//        var blueFont = fonts.FirstOrDefault(f => f.FontName == "Blue");
//        var redFont = fonts.FirstOrDefault(f => f.FontName == "Red");

//        Assert.IsNotNull(regularFont);
//        Assert.IsNotNull(largeFont);
//        Assert.IsNotNull(blueFont);
//        Assert.IsNotNull(redFont);

//        CollectionAssert.AreEqual(new List<TextSymbol> { symbols[0], symbols[1] }, regularFont.Symbols);
//        CollectionAssert.AreEqual(new List<TextSymbol> { symbols[2], symbols[3] }, largeFont.Symbols);
//        CollectionAssert.AreEqual(new List<TextSymbol> { symbols[4], symbols[5] }, blueFont.Symbols);
//        CollectionAssert.AreEqual(new List<TextSymbol> { symbols[6], symbols[7] }, redFont.Symbols);
//    }
//}
