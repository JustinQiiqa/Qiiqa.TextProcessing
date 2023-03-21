namespace Qiiqa.TextProcessing.Data;

public sealed class TextWord : TextBase
{
    public List<TextSymbol> Symbols { get; set; } = new();
}
