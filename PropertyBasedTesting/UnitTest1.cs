using FluentAssertions;
using FsCheck;
using FsCheck.Xunit;
using SourceCode.URICode;
using System;
using Xunit;

namespace PropertyBasedTesting
{
    public class UnitTest1
    {
        [Property(MaxTest = 100, Arbitrary = new[] { typeof(NumberGenerator) })]
        [Trait("Unit Test", "Property Based Testing")]
        public void Test1(decimal value)
        {
            var sut = new ImpostoDeRenda(value);

            Action result = () => sut.Calcular();

            result.Should().NotThrow();
        }
    }

    public static class NumberGenerator
    {
        public static Arbitrary<decimal> Generate() =>
            Arb.Default.Decimal().Filter(d => d > 0m && d < decimal.MaxValue);
    }
}
