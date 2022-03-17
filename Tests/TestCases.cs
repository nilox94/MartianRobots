using System;
using Xunit;
using System.IO;
using System.Collections.Generic;

namespace Tests
{
    public class TestCases
    {
        [Theory]
        [MemberData(nameof(TestData.Data), MemberType = typeof(TestData))]
        public void FromFile(string name)
        {
            using var inputReader = new StringReader(File.ReadAllText($"./Data/{name}.in"));
            using var outputWriter = new StringWriter();

            Console.SetIn(inputReader);
            Console.SetOut(outputWriter);

            MartianRobots.Program.Main();

            string expected = File.ReadAllText($"./Data/{name}.out");
            string actual = outputWriter.ToString();

            Assert.Equal(expected, actual);
        }
    }
}
