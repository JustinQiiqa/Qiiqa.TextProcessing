using System.Drawing;

namespace Qiiqa.TextProcessing.Data;

public abstract record TextBase
{
    public string? Text { get; set; }

    public RectangleF? Rect { get; set; }

    public TextFont? Font { get; set; }

    /// <summary>
    /// The baseline of a font is the imaginary line upon which characters sit.
    /// The BaseLine property should be set to a value that reflects the position of the baseline relative to the top of the symbol's bounding box.
    /// </summary>
    public float? BaseLine { get; set; }

    public Color? Color { get; set; }

    protected void RecalculateRect(IEnumerable<TextBase> texts)
    {
        if (!texts.Any()) { Rect = null; return; }

        var left = texts.Min(s => s.Rect?.Left) ?? 0;
        var top = texts.Min(s => s.Rect?.Top) ?? 0;
        var right = texts.Max(s => s.Rect?.Right) ?? 0;
        var bottom = texts.Max(s => s.Rect?.Bottom) ?? 0;

        Rect = new RectangleF(left, top, right - left, bottom - top);
    }

    protected void RecalculateColor(IEnumerable<TextBase> texts)
    {
        this.Color = AverageColor(texts);
    }

    public static Color? AverageColor(IEnumerable<TextBase> allTexts)
    {
        var texts = allTexts.Where(t => t.Color != null).ToList();

        var count = texts.Count;
        if (count == 0) return null;

        var averageA = texts.Average(t => t.Color!.Value.A);
        var averageR = texts.Average(t => t.Color!.Value.R);
        var averageG = texts.Average(t => t.Color!.Value.G);
        var averageB = texts.Average(t => t.Color!.Value.B);

        return System.Drawing.Color.FromArgb((int)averageA, (int)averageR, (int)averageG, (int)averageB);
    }

    public static Dictionary<Color, int> CountColors(IEnumerable<TextBase> texts)
    {
        var counts = new Dictionary<Color, int>();

        foreach (var text in texts)
        {
            var color = text.Color;
            if (color == null)
                continue;

            if (counts.ContainsKey(color.Value))
                counts[color.Value]++;
            else
                counts[color.Value] = 1;
        }

        return counts;
    }

    protected void Recalculate(IEnumerable<TextBase> texts)
    {
        RecalculateRect(texts);
        RecalculateColor(texts);
    }
}
