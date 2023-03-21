namespace Qiiqa.TextProcessing.Data;

public sealed record TextPage
{
    public List<TextBlock> Blocks { get; set; } = new();
}
