using FluentAssertions;
using SourceCode;
using System;
using Xunit;

namespace SpecificationBasedTesting
{
    public class AnoBissextoTest
    {
        [Fact(DisplayName = "Divisível por quatro, mas não por cem")]
        [Trait("Unit Test", "Specification Based Testing")]
        public void Test()
        {
            var ano = new Ano(new DateTime(2016, 1, 1));

            var result = ano.AnoBissexto();

            result.Should().BeTrue();
        }

        [Fact(DisplayName = "Divisível por quatro, cem e quatrocentos")]
        [Trait("Unit Test", "Specification Based Testing")]
        public void Test2()
        {
            var ano = new Ano(new DateTime(2000, 1, 1));

            var result = ano.AnoBissexto();

            result.Should().BeTrue();
        }

        [Fact(DisplayName = "Não é divisível por quatro")]
        [Trait("Unit Test", "Specification Based Testing")]
        public void Test3()
        {
            var ano = new Ano(new DateTime(2039, 1, 1));

            var result = ano.AnoBissexto();

            result.Should().BeFalse();
        }

        [Fact(DisplayName = "Divisível por quatro, cem, mas não por quatrocentos")]
        [Trait("Unit Test", "Specification Based Testing")]
        public void Test4()
        {
            var ano = new Ano(new DateTime(1900, 1, 1));

            var result = ano.AnoBissexto();

            result.Should().BeFalse();
        }
    }
}
