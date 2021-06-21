using FluentAssertions;
using SourceCode.URICode;
using System;
using Xunit;

namespace SpecificationBasedTesting
{
    /*
     Particionamento equivalente:
     Salário entre 0 e 2000
     Salário entre 2000.1 e 3000.00
     Salário entre 3000.1 e 4500.00
     Salário acima de 4500
     Salário abaixo de 0

    Category partition Method
    1 - Parametros: Salário
    2 - Valores:
     Salário entre 0 e 2000
     Salário entre 2000.1 e 3000.00
     Salário entre 3000.1 e 4500.00
     Salário acima de 4500
    3 - Exceptions
          Salário abaixo de 0
    4 - Combinações
     Salário entre 0 e 2000
     Salário entre 2000.1 e 3000.00
     Salário entre 3000.1 e 4500.00
     Salário acima de 4500

     */
    public class ImpostoDeRendaTest

    {
        [Fact(DisplayName = "Calcula 18% quando salário está acima de 3000")]
        [Trait("Unit Test", "Specification Based Testing")]
        public void Test1()
        {
            var imposto = new ImpostoDeRenda(3002);

            var result = imposto.Calcular();

            result.Should().Be("80.36");
        }

        [Fact(DisplayName = "Calcula 28% quando salário está acima de 4500")]
        [Trait("Unit Test", "Specification Based Testing")]
        public void Test2()
        {
            var imposto = new ImpostoDeRenda(4520.00m);

            var result = imposto.Calcular();

            result.Should().Be("355.60");
        }

        [Fact(DisplayName = "Retorna isento quando salário está abaixo de 2000")]
        [Trait("Unit Test", "Specification Based Testing")]
        public void Test3()
        {
            var imposto = new ImpostoDeRenda(1701.12m);

            var result = imposto.Calcular();

            result.Should().Be("Isento");
        }

        [Fact(DisplayName = "Levanta uma exceção quando salário é menor do que zero")]
        [Trait("Unit Test", "Specification Based Testing")]
        public void Test4()
        {
            var imposto = new ImpostoDeRenda(-1);

            Action result = () => imposto.Calcular();

            result.Should().Throw<InvalidOperationException>();
        }
    }
}
