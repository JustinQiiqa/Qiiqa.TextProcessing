using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qiiqa.TextProcessing.Analyzers.UnitTests;

[TestClass]
public class FontBuilder_UnitTests
{
    private readonly FontBuilder _fontBuilder = new FontBuilder
    {
        AllowedPercentageDifferenceSize = 10,
        AllowedPercentageDifferenceColor = 5
    };

}
