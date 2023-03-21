using System.Diagnostics.CodeAnalysis;

namespace Qiiqa.TextProcessing.Data;

public sealed class TextFont
{
    public string? FontName { get; set; }

    public float? FontSize { get; set; }

    public List<TextSymbol> Symbols { get; set; } = new();

    public TextSymbol? this[string text]
    {
        get
        {
            return Symbols.Find(s => s.Text == text);
        }
    }

    public TextFont() { }

    public TextFont(IEnumerable<TextSymbol> symbols)
    {
        Symbols.AddRange(symbols);
    }

    public TextFont(string fontName, float fontSize, IEnumerable<TextSymbol> symbols) : this(symbols)
    {
        FontName = fontName;
        FontSize = fontSize;
    }
}
