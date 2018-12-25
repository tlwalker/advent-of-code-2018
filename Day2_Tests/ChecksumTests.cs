using System.Collections.Generic;
using System.Linq;
using Day2;
using NUnit.Framework;

namespace Day2_Tests
{
    public class ChecksumTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Calculate_ShouldReturnZeroForEmptyList()
        {
            var chksum = new Checksum(Enumerable.Empty<string>()); 
            Assert.That(chksum.Calculate(), Is.EqualTo(0));
        }

        [Test]
        public void Calculate_ShouldReturnZero_WhenNoDoublesOrTriplesFound()
        {
            var chksum = new Checksum(new List<string>{ "abcdef" });
            Assert.That(chksum.Calculate(), Is.EqualTo(0));
        }
        [Test]
        public void Calculate_ShouldReturnOne_WhenThereIsOneDoubleAndOneTriple()
        {
            var chksum = new Checksum(new []{ "bababc" });
            Assert.That(chksum.Calculate(), Is.EqualTo(1));
        }

        [Test]
        public void Calculate_ShouldReturnCorrectChecksum()
        {
            var lines = new[]
            {
                "abcdef",
                "bababc",
                "abbcde",
                "abcccd",
                "aabcdd",
                "abcdee",
                "ababab"
            };
            var chksum = new Checksum(lines);
            Assert.That(chksum.Calculate(), Is.EqualTo(12));
        }
    }
}