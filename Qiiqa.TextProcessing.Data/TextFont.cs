using System.Drawing;

namespace Qiiqa.TextProcessing.Data;

public sealed record TextFont
{
    public string? FontName { get; set; }

    public float? FontSize { get; set; }

    public List<TextSymbol> Symbols { get; set; } = new();
    public Color? Color { get; set; }
    public float? BaseLine { get; set; }

    public TextSymbol? this[string? text] => Symbols.Find(s => s.Text == text);
}

