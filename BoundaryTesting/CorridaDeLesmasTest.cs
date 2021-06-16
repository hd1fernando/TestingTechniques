using FluentAssertions;
using SourceCode.URICode;
using System;
using System.Linq;
using Xunit;

namespace BoundaryTesting
{
    public class CorridaDeLesmasTest
    {
        [Theory(DisplayName = "Levanta exception quando número de lesmas é igual a 0 ou 501")]
        [InlineData(0)]
        [InlineData(501)]
        [Trait("Unit Test", "Boundary Testing")]
        public void Test(int numeroDeLesmas)
        {
            var sut = new CorridaDeLesmas(numeroDeLesmas, 1);

            Action action = () => sut.Calcular();

            action.Should().ThrowExactly<InvalidOperationException>();
        }

        [Fact(DisplayName = "Executa com sucesso quando o número de lesmas for igual a 1")]
        [Trait("Unit Test", "Boundary Testing")]
        public void Test2()
        {
            var sut = new CorridaDeLesmas(1, 2);

            var result = sut.Calcular();

            result.Should().Be(Nivel.Um);
        }


        [Fact(DisplayName = "Executa com sucesso quando o número de lesmas for igual a 500")]
        [Trait("Unit Test", "Boundary Testing")]
        public void Test7()
        {
            // Arrange
            var velocidades = Enumerable.Range(1, 500)
                .Select(x =>
                {
                    x = x / 50;
                    return x + 1;
                }).ToArray();

            var sut = new CorridaDeLesmas(500, velocidades);

            // Act
            var result = sut.Calcular();

            // Assert
            result.Should().Be(Nivel.Dois);
        }

        [Fact(DisplayName = "Levanta exception quando velocidade for menor do que zero")]
        [Trait("Unit Test", "Boundary Testing")]
        public void Test3()
        {
            var sut = new CorridaDeLesmas(1, 0);

            Action action = () => sut.Calcular();

            action.Should().ThrowExactly<InvalidOperationException>();
        }

        [Fact(DisplayName = "Levanta exception quando quantidade de lesmas é maior do número informado")]
        [Trait("Unit Test", "Boundary Testing")]
        public void Test8()
        {
            var sut = new CorridaDeLesmas(1, 0, 0);

            Action action = () => sut.Calcular();

            action.Should().ThrowExactly<InvalidOperationException>();
        }

        [Fact(DisplayName = "Levanta exception quando quantidade de lesmas é menor do número informado")]
        [Trait("Unit Test", "Boundary Testing")]
        public void Test9()
        {
            var sut = new CorridaDeLesmas(1);

            Action action = () => sut.Calcular();

            action.Should().ThrowExactly<InvalidOperationException>();
        }

        [Theory(DisplayName = "Retorna Nivel 1 quando velocidade for igual a 1 ou 9")]
        [InlineData(1)]
        [InlineData(9)]
        [Trait("Unit Test", "Boundary Testing")]
        public void Test4(int velocidade)
        {
            var sut = new CorridaDeLesmas(1, velocidade);

            var result = sut.Calcular();

            result.Should().Be(Nivel.Um);
        }

        [Theory(DisplayName = "Retorna Nivel 2 quando velocidade for igual a 10 ou 19")]
        [InlineData(10)]
        [InlineData(19)]
        [Trait("Unit Test", "Boundary Testing")]
        public void Test5(int velocidade)
        {
            var sut = new CorridaDeLesmas(1, velocidade);

            var result = sut.Calcular();

            result.Should().Be(Nivel.Dois);
        }

        [Fact(DisplayName = "Retorna Nivel 3 quando velocidade for igual a 20")]
        [Trait("Unit Test", "Boundary Testing")]
        public void Test6()
        {
            var sut = new CorridaDeLesmas(1, 20);

            var result = sut.Calcular();

            result.Should().Be(Nivel.Tres);
        }


    }
}
