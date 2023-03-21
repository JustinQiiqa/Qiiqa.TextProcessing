namespace Qiiqa.TextProcessing.Data;

public sealed record TextBlock : TextBase
{
    public List<TextLine> Lines { get; set; } = new();

    public TextBlock() { }

    public TextBlock(IEnumerable<TextLine> lines)
    {
        AddLines(lines);
    }

    public void AddLines(IEnumerable<TextLine> lines)
    {
        Lines.AddRange(lines);
        Recalculate();
    }

    public void Recalculate()
    {
        Recalculate(Lines);
    }
}
