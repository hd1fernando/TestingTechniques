using System;
using System.Globalization;

namespace SourceCode.URICode
{
    /// <summary>
    /// Fonte: https://www.urionlinejudge.com.br/judge/pt/problems/view/1051
    /// </summary>
    public class ImpostoDeRenda
    {
        public decimal Salario { get; }

        public ImpostoDeRenda(decimal salario)
        {
            Salario = salario;
        }

        public string Calcular()
        {
            Validar();
            if (Salario is (>= 0.0m and <= 2000m))
                return "Isento";

            var total = 0.0m;
            if (Salario is (> 2000m and <= 3000m))
                total = OitoPorCento();

            if (Salario is (> 3000m and <= 4500m))
                total = DezoitoPorCento();

            if (Salario > 4500m)
                total = VinteEOitoPorCento();

            return total.ToString("0.00", CultureInfo.InvariantCulture);
        }

        private void Validar()
        {
            if (Salario < 0m)
                throw new InvalidOperationException();
        }

        private decimal OitoPorCento() => (Salario - 2000.00m) * 0.08m;
        private decimal DezoitoPorCento() => (Salario - 3000m) * 0.10m + OitoPorCento();
        private decimal VinteEOitoPorCento() => (Salario - 4500m) * 0.10m + DezoitoPorCento();
    }
}
