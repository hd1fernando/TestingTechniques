using FluentAssertions;
using SourceCode.URICode;
using System;
using Xunit;

namespace SpecificationBasedTesting
{
    /// <summary>
    /// Parametros:
    /// Monica (int), FilhoA (int), Filho b (int)
    /// 
    /// Caracteristicas:
    /// Monica >= 40 e <= 110 (V)(Necessário)
    /// Monica < 40
    /// Monica > 110
    /// 
    ///  (V)
    /// FilhoA == Monica
    /// FilhoA > Monica
    /// FilhoA != Filho B (V) (Necessário)
    /// FilhoA == FilhoB
    /// FilhoA > FilhoB (v)
    /// 
    /// FilhoB > 0 e < Monica (V) (Necessário)
    /// FilhoB == Monica
    /// FilhoB > Monica
    /// FilhoB > FilhoA (V)
    /// 
    /// Exceptions:
    /// Monica < 40
    /// Monica > 110
    /// 
    /// FilhoA == FilhoB
    /// FilhoA == Monica
    /// FilhoA > Monica
    /// FilhoA < 1
    /// 
    /// FilhoB == Monica
    /// FilhoB > Monica
    /// FilhoB < 1
    /// 
    /// Combinações:
    /// Monica >= 40 e <= 110 | FilhoA > FilhoB (v) | FilhoA > 0 e < Monica | FilhoB > 0 e < Monica
    /// Monica >= 40 e <= 110 | FilhoA < FilhoB (v) | FilhoA > 0 e < Monica | FilhoB > 0 e < Monica
    /// 
    /// Monica < 40  [exception]
    /// Monica > 110 [exception]
    /// 
    /// FilhoA == FilhoB [exception]
    /// FilhoA == Monica [exception]
    /// FilhoA > Monica  [exception]
    /// FilhoA < 1       [exception]
    /// 
    /// FilhoB == Monica [exception]
    /// FilhoB > Monica  [exception]
    /// FilhoB < 1       [exception]   
    /// </summary>
    public class IdadeDeDonaMonicaTest
    {
        [Theory(DisplayName = "Lança exception quando valores de entrada então inválidos")]
        [InlineData(30, 5, 10)]// Monica < 40  [exception]
        [InlineData(120, 5, 10)]// Monica > 110 [exception]
        [InlineData(50, 5, 5)] // FilhoA == FilhoB [exception]
        [InlineData(50, 50, 5)]// FilhoA == Monica [exception]
        [InlineData(50, 55, 5)]// FilhoA > Monica  [exception]
        [InlineData(50, 0, 5)]// FilhoA < 1       [exception]
        [InlineData(50, 5, 50)]// FilhoB == Monica [exception]
        [InlineData(50, 5, 55)]// FilhoB > Monica  [exception]
        [InlineData(50, 5, -1)]// FilhoB < 1       [exception] 

        [Trait("Unit Test", "Specification Based Testing")]
        public void Test(int monica, int filhoA, int filhoB)
        {
            Action action = () => new IdadeDeDonaMonica(monica, filhoA, filhoB);

            action.Should().ThrowExactly<InvalidOperationException>();
        }

        [Theory(DisplayName = "Deve executar validações corretas quando valores estão dentro do limite esperado")]
        [InlineData(52, 14, 18, 20)]
        [InlineData(47, 21, 9, 17)]
        [Trait("Unit Test", "Specification Based Testing")]
        public void Test2(int monica, int filhoA, int filhoB, int resultadoEsperado)
        {
            var sut = new IdadeDeDonaMonica(monica, filhoA, filhoB);

            var result = sut.IdadeDoFilhoMaisVelho();

            result.Should().Be(resultadoEsperado);
        }
    }
}
