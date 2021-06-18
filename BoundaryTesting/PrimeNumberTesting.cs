using FluentAssertions;
using SourceCode;
using Xunit;

namespace BoundaryTesting
{
    public class PrimeNumberTesting
    {
        [Fact(DisplayName ="N�o � n�mero primo quando valor � menor do que 2")]
        [Trait("Unit Test","Boundary Testing")]
        public void Test1()
        {
            Number number = 1;

            var result = number.IsPrime();

            result.Should().BeFalse();
        }


    }
}
