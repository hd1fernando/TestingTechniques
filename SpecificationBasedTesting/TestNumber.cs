using FluentAssertions;
using SourceCode;
using Xunit;

namespace SpecificationBasedTesting
{

    /// <summary>
    /// * É par e é primo.
    /// * É par e não é primo.
    /// * É impar e é primo.
    /// * É impar e não é primo.
    /// * Está fora do limite < 3
    /// </summary>
    public class TestNumber
    {

        [Fact(DisplayName = "É par e é primo")]
        public void Test1()
        {
            Number num = 2;

            var result = num.IsPrime();

            result.Should().BeTrue();
        }

        [Fact(DisplayName = "É par e não é primo")]
        public void Test2()
        {
            Number num = 42;

            var result = num.IsPrime();

            result.Should().BeFalse();
        }

        [Fact(DisplayName = "É impar e é primo")]
        public void Test3()
        {
            Number num = 97;

            var result = num.IsPrime();

            result.Should().BeTrue();
        }

        [Fact(DisplayName = "É impar e não é primo")]
        public void Test4()
        {
            Number num = 77;

            var result = num.IsPrime();

            result.Should().BeFalse();
        }

        [Fact(DisplayName = "É um valor inválido")]
        public void Test5()
        {
            Number num = -42;

            var result = num.IsPrime();

            result.Should().BeFalse();
        }

        [Theory(DisplayName = "Não é um número primo")]
        [InlineData(42)]
        [InlineData(-42)]
        [InlineData(77)]
        public void Is_not_a_prime_number(int number)
        {
            Number num = number;

            var result = num.IsPrime();

            result.Should().BeFalse();
        }

        [Theory(DisplayName = "É um número primo")]
        [InlineData(2)]
        [InlineData(97)]
        public void Is_a_prime_number(int number)
        {
            Number num = number;

            var result = num.IsPrime();

            result.Should().BeTrue();
        }
    }
}
