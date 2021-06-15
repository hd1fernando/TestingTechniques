using FluentAssertions;
using SourceCode.URICode;
using System;
using Xunit;

namespace SpecificationBasedTesting
{

    /// <summary>
    /// 1 - Parametros:tempo gasto (int), velocidadeMedia (int)
    /// 2 - 
    /// tempo (T): inteiro positivo, 0 a  infinito
    /// velocidade media (VM): inteiro positivo, 0 a infinito
    /// 3 - restrições:
    /// tempo não pode ser menor do que 0
    /// velocidade não pode ser menor do que zero
    /// 4 - combinações:
    /// T = 0 e VM = 0
    /// T > 0 e VM = 0
    /// T = 0 e VM > 0
    /// T > 0 e VM > 0
    /// T < 0 e VM any [exceção]
    /// T any e VM < 0 [exceção]
    /// </summary>
    public class GastoDeCombustivelTest
    {
        [Fact(DisplayName = "Tempo e velocidad são iguais a zero")]
        [Trait("Unit Test", "Specification Based Testing")]
        public void Tempo_e_velocidade_sao_zero()
        {
            var gasto = new GastoDeCombustivel(0, 0);

            var result = gasto.Calcular();

            result.Should().BeEquivalentTo("0.000");
        }

        [Theory(DisplayName = "Lança exception quando tempo ou velocidade é menor do que zero.")]
        [InlineData(10, -1)]
        [InlineData(-1, 10)]
        [Trait("Unit Test", "Specification Based Testing")]

        public void Levanta_excecao_quando_Tempo_ou_velocidade_menores_do_que_zero(int tempo, int velocidade)
        {
            var gasto = new GastoDeCombustivel(tempo, velocidade);

            Action result = () => gasto.Calcular();

            result.Should().ThrowExactly<ArgumentException>();
        }

        [Theory(DisplayName = "Tempo ou velocidade é igual a zero")]
        [InlineData(10, 0, "0.000")]
        [InlineData(0, 10, "0.000")]
        [Trait("Unit Test", "Specification Based Testing")]
        public void Tempo_ou_velocidade_sao_zeros(int tempo, int velocidade, string resultadoEsperado)
        {
            var gasto = new GastoDeCombustivel(tempo, velocidade);
            var result = gasto.Calcular();

            result.Should().Be(resultadoEsperado);
        }

        [Fact(DisplayName = "Tempo e velocidade são maiores do que zero")]
        [Trait("Unit Test", "Specification Based Testing")]
        public void Tempo_e_velocidade_sao_maiores_do_que_zero()
        {
            var gasto = new GastoDeCombustivel(10, 85);

            var result = gasto.Calcular();

            result.Should().BeEquivalentTo("70.833");
        }
    }
}
