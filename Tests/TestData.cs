using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tests
{
    public static class TestData
    {
        public static IEnumerable<object[]> Data => Directory
            .GetFiles("Data", "*.in")
            .Select(p => new []{ Path.GetFileNameWithoutExtension(p) });
    }
}
