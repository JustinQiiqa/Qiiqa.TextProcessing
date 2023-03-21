using Qiiqa.TextProcessing.Data;

using System.Drawing;

namespace Qiiqa.TextProcessing.Analyzers;

/// <summary>
/// This class generates a font by using the System.Drawing library to measure the size of each symbol in the font. 
/// The GenerateFont method takes a font family name and font size, and returns a new TextFont object with the generated symbols. 
/// The GenerateLetters, GenerateSymbols, and GeneratePunctuation methods generate the symbols for the font by calling the GenerateSymbol method for each character. 
/// The GenerateSymbol method measures the size of the symbol using the Graphics.MeasureString method, and calculates the base line position by using the FontFamily.GetCellAscent method.
/// </summary>
public class StandardFontBuilder
{
    public TextFont BuildFont(string fontFamilyName, FontStyle fontStyle = FontStyle.Regular, float fontSize = 12)
    {
        var fontFamily = new FontFamily(fontFamilyName);
        var font = new Font(fontFamily, fontSize, fontStyle, GraphicsUnit.Point);

        var baseLine = font.SizeInPoints * font.FontFamily.GetCellAscent(font.Style) / font.FontFamily.GetEmHeight(font.Style);
        var textFont = new TextFont { FontName = fontFamilyName, FontSize = font.Size, BaseLine = baseLine };

        GenerateFontLetters(textFont, font, baseLine);
        GenerateFontDigits(textFont, font, baseLine);
        GenerateFontPunctuation(textFont, font, baseLine);

        return textFont;
    }

    public static void GenerateFontLetters(TextFont font, Font systemFont, float baseLine)
    {
        foreach (var c in Constants.Letters)
            AddGeneratedSymbol(font, systemFont, c, baseLine);
    }

    public static void GenerateFontDigits(TextFont font, Font systemFont, float baseLine)
    {
        foreach (var c in Constants.Digits)
            AddGeneratedSymbol(font, systemFont, c, baseLine);
    }

    public static void GenerateFontPunctuation(TextFont font, Font systemFont, float baseLine)
    {
        foreach (var c in Constants.Punctuation)
            AddGeneratedSymbol(font, systemFont, c, baseLine);
    }

    public static void AddGeneratedSymbol(TextFont font, Font systemFont, char c, float baseLine)
    {
        var symbol = GenerateSymbol(systemFont, c, baseLine);
        font.Symbols.Add(symbol);
    }

    public static TextSymbol GenerateSymbol(Font systemFont, char c, float baseLine)
    {
        var symbol = new TextSymbol { Text = c.ToString() };

        using (var image = new Bitmap(1, 1))
        using (var graphics = Graphics.FromImage(image))
        {
            var size = graphics.MeasureString(symbol.Text, systemFont);
            symbol.Rect = new RectangleF(0, 0, size.Width, size.Height);
            symbol.BaseLine = baseLine;
        }

        return symbol;
    }
}

