using System;

namespace SourceCode.URICode
{
    /// <summary>
    /// Fonte: https://www.urionlinejudge.com.br/judge/pt/problems/view/1789
    /// </summary>
    public class CorridaDeLesmas
    {
        public int NumeroDeLesmas { get; }

        private int[] VelocidadesDasLesmas { get; set; }
        public CorridaDeLesmas(int numeroDeLesmas, params int[] velocidades)
        {
            NumeroDeLesmas = numeroDeLesmas;
            PreencherVelocidades(velocidades);
        }

        private void PreencherVelocidades(int[] velocidades)
        {
            VelocidadesDasLesmas = new int[velocidades.Length];
            for (int i = 0; i < velocidades.Length; i++)
            {
                VelocidadesDasLesmas[i] = velocidades[i];
            }
        }

        public Nivel Calcular()
        {
            Nivel resultado = 0;
            ValidarNumeroDeLesmas();
            foreach (var velocidade in VelocidadesDasLesmas)
            {
                ValidarVelocidades(velocidade);
                var temp = CompararVelocidade(velocidade);
                if (temp > resultado)
                    resultado = temp;
            }

            if (resultado == 0)
                throw new InvalidOperationException();

            return resultado;
        }

        private Nivel CompararVelocidade(int velocidade)
            => velocidade switch
            {
                > 0 and < 10 => Nivel.Um,
                >= 10 and < 20 => Nivel.Dois,
                >= 20 => Nivel.Tres,
                _ => throw new InvalidOperationException()
            };

        private void ValidarVelocidades(int velocidade)
        {
            if (velocidade is (< 1 or > 50))
                throw new InvalidOperationException();
        }

        private void ValidarNumeroDeLesmas()
        {
            if (NumeroDeLesmas is (< 1 or > 500)
                || NumeroDeLesmas != VelocidadesDasLesmas.Length)
                throw new InvalidOperationException();
        }
    }

    public enum Nivel
    {
        Um = 1,
        Dois = 2,
        Tres = 3,
    }
}
