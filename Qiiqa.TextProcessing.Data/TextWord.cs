namespace Qiiqa.TextProcessing.Data;

public sealed record TextWord : TextBase
{
    public List<TextSymbol> Symbols { get; set; } = new();

    public TextWord() { }

    public TextWord(IEnumerable<TextSymbol> symbols)
    {
        AddSymbols(symbols);
    }

    public void AddSymbols(IEnumerable<TextSymbol> symbols)
    {
        Symbols.AddRange(symbols);
        Recalculate();
    }

    public void Recalculate()
    {
        RecalculateRect(Symbols);
        RecalculateColor(Symbols);
    }
}
