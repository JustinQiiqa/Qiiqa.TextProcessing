using Qiiqa.TextProcessing.Data;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qiiqa.TextProcessing.Analyzers;

public class FontAnalyzer
{
    public float AllowedPercentageDifferenceSize { get; set; }
    public float AllowedPercentageDifferenceColor { get; set; }

    /// <summary>
    /// Iterates over each symbol in <paramref name="symbols"/> and check if each size or color is the same as previous symbols,
    /// otherwise throws an exception. Adds new symbols to the font to set size and color to the first symbol encountered.
    /// This assumes that all symbols belong to the same font.
    /// </summary>
    public TextFont BuildFont(IEnumerable<TextSymbol> symbols)
    {
        var font = new TextFont();
        var sizeSet = false;
        var colorSet = false;

        foreach (var symbol in symbols)
        {
            // Check if the symbol size is within the allowed range
            if (!IsNullableSizeWithinPercentageDifference(symbol.Rect?.Size, font.Symbols.FirstOrDefault()?.Rect?.Size))
            {
                throw new Exception($"Symbol '{symbol}' size outside allowed range.");
            }

            // Check if the symbol color is within the allowed range
            if (!IsNullableColorWithinPercentageDifference(symbol.Color, font.Symbols.FirstOrDefault()?.Color))
            {
                throw new Exception($"Symbol '{symbol}' color outside allowed range.");
            }

            font.Symbols.Add(symbol);

            // Set the font size and color based on the first symbol encountered
            if (!sizeSet)
            {
                font.FontSize = symbol.Rect?.Height;
                sizeSet = true;
            }

            if (!colorSet)
            {
                font.Color = symbol.Color;
                colorSet = true;
            }
        }

        return font;
    }

    private bool IsNullableSizeWithinPercentageDifference(SizeF? size1, SizeF? size2)
    {
        if (size1 == null) return (size2 == null);
        if (size2 == null) return (size1 == null);

        return IsKnownSizeWithinPercentageDifference(size1.Value, size2.Value);
    }

    private bool IsKnownSizeWithinPercentageDifference(SizeF size1, SizeF size2)
    {
        var widthDelta = Math.Abs(size2.Width - size1.Width) / size1.Width;
        var heightDelta = Math.Abs(size2.Height - size1.Height) / size1.Height;

        if (widthDelta > AllowedPercentageDifferenceSize) return false;
        if (heightDelta > AllowedPercentageDifferenceSize) return false;

        return true;
    }

    private bool IsNullableColorWithinPercentageDifference(Color? color1, Color? color2)
    {
        if (color1 == null) return (color2 == null);
        if (color2 == null) return (color1 == null);

        return IsKnownColorWithinPercentageDifference(color1.Value, color2.Value);
    }

    private bool IsKnownColorWithinPercentageDifference(Color color1, Color color2)
    {
        float r = Math.Abs(color1.R - color2.R) / 255f;
        if (r > AllowedPercentageDifferenceColor) return false;

        float g = Math.Abs(color1.G - color2.G) / 255f;
        if (g > AllowedPercentageDifferenceColor) return false;

        float b = Math.Abs(color1.B - color2.B) / 255f;
        if (b > AllowedPercentageDifferenceColor) return false;

        float a = Math.Abs(color1.A - color2.A) / 255f;
        return a <= AllowedPercentageDifferenceColor;
    }
}

