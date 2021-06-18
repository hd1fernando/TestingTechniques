using System;

namespace SourceCode.URICode
{
    /// <summary>
    /// Fonte: https://www.urionlinejudge.com.br/judge/pt/problems/view/3147
    /// </summary>
    public class ABatalhaDosCincoExercitos
    {
        public int Humanos { get; }
        public int Elfos { get; }
        public int Anoes { get; }
        public int Orcs { get; }
        public int Wargs { get; }
        public int Aguias { get; }

        public ABatalhaDosCincoExercitos(int humanos, int elfos, int anoes, int orcs, int wargs, int aguias)
        {
            Humanos = humanos;
            Elfos = elfos;
            Anoes = anoes;
            Orcs = orcs;
            Wargs = wargs;
            Aguias = aguias;
            Validar();
        }

        private void Validar()
        {
            if (Ltz(Humanos) || Ltz(Elfos) || Ltz(Anoes) || Ltz(Orcs) || Ltz(Wargs) || Ltz(Aguias))
                throw new InvalidOperationException();

            bool Ltz(int n) => n < 0;
        }

        public bool BemVence()
        {
            var totalBem = Humanos + Elfos + Anoes;
            var totalMal = Orcs + Wargs;

            if (totalBem <= totalMal)
                totalBem += Aguias;

            if (totalBem <= totalMal)
            {
                var bilbo = 1;
                totalBem += bilbo;
            }

            return totalBem > totalMal;
        }
    }
}
