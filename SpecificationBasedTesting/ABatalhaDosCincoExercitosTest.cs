using FluentAssertions;
using SourceCode.URICode;
using System;
using Xunit;

namespace SpecificationBasedTesting
{
    /// <summary>
    /// Parametros H, E, A, O, W e X
    /// Valores:
    /// H, E, A, O, W ou X >= 0
    /// Exceptions:
    /// H, E, A, O, W ou X menores do que zero
    /// </summary>
    public class ABatalhaDosCincoExercitosTest
    {
        [Theory(DisplayName = "Levanta exception quando qualqueer exercíto tem valor menor do que zero.")]
        [InlineData(-1, 2, 3, 10, 2, 7)]
        [InlineData(1, -2, 3, 10, 2, 7)]
        [InlineData(1, 2, -3, 10, 2, 7)]
        [InlineData(1, 2, 3, -10, 2, 7)]
        [InlineData(1, 2, 3, 10, -2, 7)]
        [InlineData(1, 2, 3, 10, 2, -7)]
        public void Test2(int humanos, int elfos, int anoes, int orcs, int wargs, int aguias)
        {
            Action action = () => new ABatalhaDosCincoExercitos(humanos, elfos, anoes, orcs, wargs, aguias);

            action.Should().ThrowExactly<InvalidOperationException>();
        }


        [Fact(DisplayName = "Quando número de exercitos do bem é maior, BemVence deve retornar true")]
        public void Test()
        {
            var batalha = new ABatalhaDosCincoExercitos(1, 2, 3, 10, 2, 7);

            var result = batalha.BemVence();

            result.Should().BeTrue();
        }

        [Fact(DisplayName = "Quando número de exercitos do bem é menor, BemVence deve retornar false")]
        public void Test3()
        {
            var batalha = new ABatalhaDosCincoExercitos(1, 2, 3, 10, 2, 5);

            var result = batalha.BemVence();

            result.Should().BeFalse();
        }

    }
}
