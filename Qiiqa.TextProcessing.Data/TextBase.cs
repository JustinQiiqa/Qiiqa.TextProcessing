using System.Drawing;

namespace Qiiqa.TextProcessing.Data;

public abstract class TextBase
{
    public string? Text { get; set; }

    public RectangleF? Rect { get; set; }

    public TextFont? Font { get; set; }

    /// <summary>
    /// The baseline of a font is the imaginary line upon which characters sit.
    /// The BaseLine property should be set to a value that reflects the position of the baseline relative to the top of the symbol's bounding box.
    /// </summary>
    public float? BaseLine { get; set; }

    public int? Color { get; set; }
}
