namespace Qiiqa.TextProcessing.Data;

public sealed record TextLine : TextBase
{
    public List<TextWord> Words { get; set; } = new();

    public TextLine() { }

    public TextLine(IEnumerable<TextWord> words)
    {
        AddWords(words);
    }

    public void AddWords(IEnumerable<TextWord> words)
    {
        Words.AddRange(words);
        Recalculate();
    }

    public void Recalculate()
    {
        Recalculate(Words);
    }
}
