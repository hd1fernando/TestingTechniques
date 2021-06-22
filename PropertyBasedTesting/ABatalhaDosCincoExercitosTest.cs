using FsCheck;
using FsCheck.Xunit;
using SourceCode.URICode;

namespace PropertyBasedTesting
{
    public class ABatalhaDosCincoExercitosTest
    {
        [Property(MaxTest = 100, Arbitrary = new[] { typeof(Tipo) })]
        public Property Test1(int humanos, int elfos, int anoes, int orcs, int wargs, int aguias)
        {
            var sut = new ABatalhaDosCincoExercitos(humanos, elfos, anoes, orcs, wargs, aguias);

            var comparador = (humanos + elfos + anoes + aguias + 1) > (orcs + wargs);

            var calculo = sut.BemVence();

            return (calculo == comparador).ToProperty()
                .Collect(humanos)
                .Collect(elfos)
                .Collect(anoes)
                .Collect(anoes)
                .Collect(orcs)
                .Collect(wargs)
                .Collect(aguias);
        }

        public class Tipo
        {
            public static Arbitrary<int> Exercito()
                => Arb.Default.Int32().Generator.Where(x => x >= 0).ToArbitrary();
        }
    }
}
