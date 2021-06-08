using FluentAssertions;
using SourceCode.URICode;
using System;
using Xunit;

namespace SpecificationBasedTesting
{
    /**
     * 1 - Paramentro: Dias (int)
     * 2 - Valores: >= 0
     * 3 - Exception
     * Dias < 0
     * 4 - Combinações
     *  dia = 0 = sucesso
     *  dia > 0 = sucesso
     *  dia < 0 = ERRO
     */
    public class IdadeEmDiasTest
    {
        [Fact(DisplayName = "Executa com sucesso quando dia é maior do que zero")]
        public void Test1()
        {
            var idade = new IdadeEmDias(400);

            var result = idade.Calcular();

            result.Should().BeEquivalentTo((1, 1, 5));
        }

        [Fact(DisplayName = "Retorna zero quando o dia é igual a zero")]
        public void Test2()
        {
            var idade = new IdadeEmDias(0);

            var result = idade.Calcular();

            result.Should().BeEquivalentTo((0, 0, 0));
        }

        [Fact(DisplayName = "Levanta um erro quando o dia é menor do que zero")]
        public void Test3()
        {
            var idade = new IdadeEmDias(-42);

            Action action = () => idade.Calcular();

            action.Should().Throw<ArgumentException>();
        }
    }
}
