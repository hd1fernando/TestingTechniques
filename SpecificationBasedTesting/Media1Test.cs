using FluentAssertions;
using SourceCode.URICode;
using System;
using Xunit;

namespace SpecificationBasedTesting
{
    /**
     * 1 - Parametros: numA (A), numB (B)
     * 
     * 2 - Caracteristicas de cada parâmetro:
     * 0.0 < A < 10.0
     * 0.0 < B < 10.0
     * A < 0.0
     * A > 10.0
     * B < 0.0
     * B > 10.0
     * A = 0
     * B = 0
     * A = B
     * A > B
     * A < B
     * 
     * 3 - Restrições:
     * A: < 0.0 ou > 10.0[exeção]
     * B: < 0.0 ou > 10.0[exeção]
     * 
     * 4 - combinações
     * a = 0.0 e 0.0> b < 10.0 = sucesso
     * b = 0.0 e 0.0> a < 10.0 = sucesso
     * 0.0 > a < 10.0 e 0.0> b < 10.0 e a > b = sucesso
     * 0.0 > a < 10.0 e 0.0> b < 10.0 e a < b = sucesso
     * 0.0 > a < 10.0 e 0.0> b < 10.0 e a = b = sucesso
     * a < 0 e b any = exception
     * a > 0 e b any = exception
     * a any e b < 0 = exception
     * a any e b > 0 = exception
     */
    public class Media1Test
    {
        [Theory(DisplayName = "Executa com sucesso quando A e B possuem valores não nulos e entre 0.0 e 10.0")]
        [InlineData(7.1, 5.0, 5.66818)] // a > b
        [InlineData(5.0, 7.1, 6.43182)] // a < b
        [InlineData(5.0, 5.0,5.0)]// a = b
        [Trait("Unit Test", "Specification Based Testing")]
        public void Test(double a, double b, double resultadoEsperado)
        {
            var media = new Media1(a, b);

            var result = media.Calcular();

            result.Should().Be(resultadoEsperado);
        }

        [Theory(DisplayName = "Executa com sucesso quando A ou B possuem valores  nulos e entre 0.0 e 10.0")]
        [InlineData(0.0, 5.0, 3.40909)] // a > b
        [InlineData(5.0, 0.0, 1.59091)] // a < b
        [Trait("Unit Test", "Specification Based Testing")]
        public void Test3(double a, double b, double resultadoEsperado)
        {
            var media = new Media1(a, b);

            var result = media.Calcular();

            result.Should().Be(resultadoEsperado);
        }

        [Theory(DisplayName = "Levanta erro quando A ou B possuem resutados abaixo de 0.0 ou acima de 10.0")]
        [InlineData(-1.0, 4.2)]
        [InlineData(11.0, 4.2)]
        [InlineData(1.0, -4.2)]
        [InlineData(1.0, 42.0)]
        [Trait("Unit Test", "Specification Based Testing")]
        public void Test2(double a, double b)
        {
            var media = new Media1(a, b);

            Action result = () => media.Calcular();

            result.Should().ThrowExactly<ArgumentException>();
        }
    }
}
