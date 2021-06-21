using FluentAssertions;
using SourceCode.URICode;
using System;
using Xunit;

namespace StructuralTesting
{
    public class ImpostoDeRendaTest
    {
        [Theory(DisplayName = "Retornar 'isento' quando salário está entre 0 e 2000")]
        [Trait("Unit Test", "Structural Testing - Condition + Branch coverage")]
        [InlineData(0.0)]
        [InlineData(2000.0)]
        public void Test1(decimal salario)
        {
            var sut = new ImpostoDeRenda(salario);

            var result = sut.Calcular();

            result.Should().Be("Isento");
        }

        [Theory(DisplayName = "Retorna 8% quando salário está entre 2001 e 3000")]
        [Trait("Unit Test", "Structural Testing - Condition + Branch coverage")]
        [InlineData(2001.0, "0.08")]
        [InlineData(3000.0, "80.00")]
        public void Test2(decimal salario, string resultadoEsperado)
        {
            var sut = new ImpostoDeRenda(salario);

            var result = sut.Calcular();

            result.Should().Be(resultadoEsperado);
        }

        [Theory(DisplayName = "Retorna 18% quando salário está entre 3001 e 4500")]
        [Trait("Unit Test", "Structural Testing - Condition + Branch coverage")]
        [InlineData(3001.0, "80.18")]
        [InlineData(4500.0, "350.00")]
        public void Test3(decimal salario, string resultadoEsperado)
        {
            var sut = new ImpostoDeRenda(salario);

            var result = sut.Calcular();

            result.Should().Be(resultadoEsperado);
        }

        [Fact(DisplayName = "Retorna 28% quando salário está entre 3001 e 4500")]
        [Trait("Unit Test", "Structural Testing - Condition + Branch coverage")]
        public void Test4()
        {
            var sut = new ImpostoDeRenda(4501);

            var result = sut.Calcular();

            result.Should().Be("350.28");
        }

        [Fact(DisplayName = "Levanta erro quando valor está abaixo de zero")]
        [Trait("Unit Test", "Structural Testing - Condition + Branch coverage")]
        public void Test5()
        {
            var sut = new ImpostoDeRenda(-1);

            Action result = () => sut.Calcular();

            result.Should().ThrowExactly<InvalidOperationException>();
        }

    }
}
