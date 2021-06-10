using FluentAssertions;
using SourceCode.URICode;
using System;
using Xunit;

namespace SpecificationBasedTesting
{
    /**
     * Particoes:
     * Velocidade < 10
     * Velocidade >=  10 e < 20
     * Velocidade >= 20
     * 
     * Category partition method
     * 1 - Parametros: numero de lesmas (int), velocidade (arr)
     * 2 - Valores possíveis:
     *  n lesmas < 0
     *  n lesmas = 0
     *  n lesmas > 0
     *  velocidade 0 elementos
     *  velocidade 1 elemento
     *  velocidade n elementos
     *  
     *  3 - Excecoes
     *  n lesmas <= 0
     *  velocidade = 0 elementos
     *  
     *  4 - combinações
     *  num lesmas = 1 velocidade = 1 elemntos
     *  num lesmas = n velocidade = n elementos
     */
    public class CorridaDeLesmasTest
    {
        [Theory(DisplayName = "Retorna nível da lesmas")]
        [InlineData(10, Nivel.Um, 9, 9, 1, 1, 5, 3, 2, 4, 1, 3)]
        [InlineData(10, Nivel.Dois, 10, 10, 10, 10, 15, 18, 2, 15, 11, 10)]
        [InlineData(10, Nivel.Tres, 10, 10, 10, 10, 15, 18, 25, 15, 11, 10)]
        [InlineData(1, Nivel.Um, 2)]
        [InlineData(1, Nivel.Dois, 10)]
        [InlineData(1, Nivel.Tres, 25)]
        public void Test1(int numLesmas, Nivel resultadoExperado, params int[] velocidades)
        {

            var corrida = new CorridaDeLesmas(numLesmas, velocidades);

            var result = corrida.Calcular();

            result.Should().Be(resultadoExperado);
        }

        [Theory(DisplayName = "Lança Exception")]
        [InlineData(-1, 9, 9, 1, 1, 5, 3, 2, 4, 1, 3)]
        [InlineData(1, -9)]
        [InlineData(1)]
        public void Test2(int numLesmas, params int[] velocidades)
        {
            var corrida = new CorridaDeLesmas(numLesmas, velocidades);

            Action result = () => corrida.Calcular();

            result.Should().ThrowExactly<InvalidOperationException>();
        }
    }
}
