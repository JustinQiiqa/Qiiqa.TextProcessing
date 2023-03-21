namespace Qiiqa.TextProcessing.Data;

public sealed class TextLine : TextBase
{
    public List<TextWord> Words { get; set; } = new();
}
