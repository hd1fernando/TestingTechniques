using FluentAssertions;
using SourceCode.URICode;
using System;
using Xunit;

namespace SpecificationBasedTesting
{
    /**
     *Particões:
     *   HorarioDeSaida (HS) (0 ≤ S ≤ 23), 
     *   HS < 0  [Exception]
     *   HS > 23 [Exception]
     *   
     *   TempoDeViagem (TV) (1 ≤ T ≤ 12) 
     *   TV < 1 [Exception]
     *   TV > 12 [Exception]
     *   
     *   FusoHorarioDestino (F)(-5 ≤ F ≤ 5)
     *   F < -5 [Exception]
     *   F > 5 [Exception]
     *  
     *  Combinações
     *  HS > 0 + TV + F < 0
     *  HS = 0 + TV + F < 0
     *  
     *  HS > 0 + TV + F = 0
     *  HS = 0 + TV + F = 0
     *  
     *  HS > 0 + TV + F = 0
     *  HS = 0 + TV + F > 0
     *  
     */
    public class FusoHorarioTest
    {
        [Theory(DisplayName = "Levanta exception quando parametros estão fora dos limites esperado")]
        [InlineData(-1, 1, 1)]
        [InlineData(25, 1, 1)]
        [InlineData(1, -1, 1)]
        [InlineData(1, 13, 1)]
        [InlineData(1, 1, -10)]
        [InlineData(1, 1, 10)]
        [Trait("Unit Test", "Specification Based Testing")]
        public void Test1(int horararioDeSaida, int tempoDeViagem, int fusoHorarioDestino)
        {
            Action fuso = () => new FusoHorario(horararioDeSaida, tempoDeViagem, fusoHorarioDestino);

            fuso.Should().ThrowExactly<InvalidOperationException>();
        }

        [Theory]
        [InlineData(22, 6, -2, 2)]
        [InlineData(0, 3, -4, 23)]
        [InlineData(10, 7, 0, 17)]
        [InlineData(0, 7, 0, 7)]
        [InlineData(10, 7, 3, 20)]
        [InlineData(0, 7, 3, 10)]
        [Trait("Unit Test", "Specification Based Testing")]
        public void Test2(int horararioDeSaida, int tempoDeViagem, int fusoHorarioDestino, int resultadoEsperado)
        {
            var fuso = new FusoHorario(horararioDeSaida, tempoDeViagem, fusoHorarioDestino);

            var result = fuso.Calcular();

            result.Should().Be(resultadoEsperado);
        }

    }
}
