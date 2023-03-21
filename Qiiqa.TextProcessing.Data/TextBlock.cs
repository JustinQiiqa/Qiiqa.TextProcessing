namespace Qiiqa.TextProcessing.Data;

public sealed class TextBlock : TextBase
{
    public List<TextLine> Lines { get; set; } = new();
}
