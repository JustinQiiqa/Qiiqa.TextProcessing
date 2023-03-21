using System.Diagnostics.CodeAnalysis;

namespace Qiiqa.TextProcessing.Data;

public class TextSymbol : TextBase
{
    public TextSymbol() : base() { }

    public TextSymbol(string text, TextRect rect, TextFont? font = null, double? baseLine = null, int? color = null)
        : base(text, rect, font, baseLine, color)
    {
    }
}
