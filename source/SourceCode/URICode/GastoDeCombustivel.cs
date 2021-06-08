using System;

namespace SourceCode.URICode
{

    /// <summary>
    /// Fonte: https://www.urionlinejudge.com.br/judge/pt/problems/view/1017
    /// </summary>
    public class GastoDeCombustivel
    {
        public int TempoGasto { get; }
        public int VelocidadeMedia { get; }

        public GastoDeCombustivel(int tempoGasto, int velocidadeMedia)
        {
            TempoGasto = tempoGasto;
            VelocidadeMedia = velocidadeMedia;
        }

        public string Calcular()
        {
            Validar();

            var distancia = VelocidadeMedia * TempoGasto;
            var result = distancia / 12.0f;
            return result.ToString("n3");
        }

        private void Validar()
        {
            if (TempoGasto < 0 || VelocidadeMedia < 0)
                throw new ArgumentException("Inválido");
        }
    }
}
