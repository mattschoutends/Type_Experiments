using System;
using System.Collections.Generic;
using FluentAssertions;
using ProductionCode;
using Xunit;

namespace ProductionCode.UnitTests
{
    public class TypeExperimentTests
    {
        [Fact]
        public void CanGetTypeOfObject()
        {
            var expected = "System.String";
            var actual = TypeExperiments.GetParameterType("hello");
            actual.Should().Be(expected);
        }

        [Fact]
        public void CanGetTypeOfGeneric()
        {
            var list = new List<int>();
            var expected = "System.Collections.Generic.List`1[System.Int32]";

            var actual = TypeExperiments.GetParameterType(list);
            actual.Should().Be(expected);
        }

        [Fact]
        public void CanGetInternalTypeOfGeneric()
        {
            var list = new List<int>();
            var expected = "System.Int32";

            var actual = TypeExperiments.GetInternalParameterType(list);
            actual.Should().Be(expected);
        }

        [Fact]
        public void CanGetTypeOfBasicGenericInContainer()
        {
            var expected = "System.String";

            var container = new ContainerClass<string>();
            container.Data = "hello";

            var actual = TypeExperiments.GetParameterType(container.Data);
            actual.Should().Be(expected);
        }

        [Fact]
        public void CanGetTypeOfNestedGenericInContainer()
        {
            var expected = "System.Collections.Generic.List`1[System.String]";

            var container = new ContainerClass<List<string>>();
            container.Data = new List<string>() { "hi", "there" };

            var actual = TypeExperiments.GetParameterType(container.Data);
            actual.Should().Be(expected);
        }

        [Fact]
        public void CanReturnContainerForGeneric()
        {
            string param = "YES";
            var actual = TypeExperiments.ReturnContainerOfData(param);

            actual.Data.GetType().ToString().Should().Be("System.String");
        }

        [Fact]
        public void CanPutTogetherTwoListsOfGenericType()
        {
            var first = new List<string>() { "hello" };
            var second = new List<string>() { "there", "children" };

            var expected = new List<string>() { "hello", "there", "children" };

            var actual = TypeExperiments.CombineGenericEnumerableThings<IEnumerable<string>, string>(first, second);
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
