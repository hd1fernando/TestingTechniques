using System;
using System.Globalization;

namespace SourceCode.URICode
{
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
                total = Acima();

            return total.ToString("#.00", CultureInfo.InvariantCulture);
        }

        private void Validar()
        {
            if (Salario < 0m)
                throw new ArgumentException();
        }

        private decimal OitoPorCento() => (Salario - 2000.00m) * 0.08m;
        private decimal DezoitoPorCento() => (Salario - 3000m) * 0.10m + OitoPorCento();
        private decimal Acima() => (Salario - 4500m) * 0.10m + DezoitoPorCento();
    }
}
