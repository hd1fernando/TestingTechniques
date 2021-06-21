using FluentAssertions;
using SourceCode.URICode;
using System;
using Xunit;

namespace StructuralTesting
{
    public class Media1Tetst
    {
        [Fact(DisplayName = "Cobre a primeira condição A> 10")]
        [Trait("Unit Test", "Structural Testing - Condition + Branch coverage")]
        public void Test1()
        {
            var media = new Media1(11.0, 5.0);

            Action action = () => media.Calcular();

            action.Should().ThrowExactly<ArgumentException>();
        }

        [Fact(DisplayName = "Cobre a segunda condição B > 10")]
        [Trait("Unit Test", "Structural Testing - Condition + Branch coverage")]
        public void Test2()
        {
            var media = new Media1(1.0, 50.0);

            Action action = () => media.Calcular();

            action.Should().ThrowExactly<ArgumentException>();
        }

        [Fact(DisplayName = "Cobre execução com sucesso")]
        [Trait("Unit Test", "Structural Testing - Condition + Branch coverage")]
        public void Test3()
        {
            var media = new Media1(1.0, 5.0);

            var result = media.Calcular();

            result.Should().Be(3.72727);
        }
    }
}
