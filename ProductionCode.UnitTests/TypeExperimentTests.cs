using System;
using FluentAssertions;
using ProductionCode;
using Xunit;

namespace ProductionCode.UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void CanGetTypeOfObject()
        {
            var expected = "System.String";
            var actual = TypeExperiments.GetParameterType("hello");
            actual.Should().Be(expected);
        }
    }
}
