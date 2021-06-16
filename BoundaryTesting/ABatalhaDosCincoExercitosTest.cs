using FluentAssertions;
using SourceCode.URICode;
using System;
using Xunit;

namespace BoundaryTesting
{
    public class ABatalhaDosCincoExercitosTest
    {
        [Theory(DisplayName = "Deve lançar exception quando  o número de soldados for igual a -1")]
        [InlineData(-1, 0, 0, 0, 0, 0)]
        [InlineData(0, -1, 0, 0, 0, 0)]
        [InlineData(0, 0, -1, 0, 0, 0)]
        [InlineData(0, 0, 0, -1, 0, 0)]
        [InlineData(0, 0, 0, 0, -1, 0)]
        [InlineData(0, 0, 0, 0, 0, -1)]
        [Trait("Unit Test", "Boundary Testing")]
        public void Test1(int humanos, int elfos, int anoes, int orcs, int wargs, int aguias)
        {
            Action action = () => new ABatalhaDosCincoExercitos(humanos, elfos, anoes, orcs, wargs, aguias);

            action.Should().ThrowExactly<InvalidOperationException>();
        }

        [Theory(DisplayName = "Não deve lançar exceptio quando número de soldados é igual a zero.")]
        [InlineData(0, 0, 0, 0, 0, 0)]
        [Trait("Unit Test", "Boundary Testing")]
        public void Test2(int humanos, int elfos, int anoes, int orcs, int wargs, int aguias)
        {
            Action action = () => new ABatalhaDosCincoExercitos(humanos, elfos, anoes, orcs, wargs, aguias);

            action.Should().NotThrow<InvalidOperationException>();
        }

        [Fact(DisplayName = "Bem vence quando a quantidade incial dos exercicios são equivalentes. Pois Bilbo passa a ajudar.")]
        [Trait("Unit Test", "Boundary Testing")]
        public void Test3()
        {
            var batalha = new ABatalhaDosCincoExercitos(0, 1, 1, 1, 1, 0);

            var result = batalha.BemVence();

            result.Should().BeTrue();
        }

        [Fact(DisplayName = "Bem vence quando a quantidade incial dos exercicios são equivalentes. Mas, Gandalf chama as aves.")]
        [Trait("Unit Test", "Boundary Testing")]
        public void Test4()
        {
            var batalha = new ABatalhaDosCincoExercitos(0, 1, 1, 1, 1, 1);

            var result = batalha.BemVence();

            result.Should().BeTrue();
        }

        [Fact(DisplayName = "Mal vence mesmo com a ajuda de Bilbo.")]
        [Trait("Unit Test", "Boundary Testing")]
        public void Test5()
        {
            var batalha = new ABatalhaDosCincoExercitos(0, 1, 0, 1, 1, 0);

            var result = batalha.BemVence();

            result.Should().BeFalse();
        }
    }
}
