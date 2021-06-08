using System;

namespace SourceCode.URICode
{
    public class IdadeEmDias
    {
        public int Dias { get; }

        public IdadeEmDias(int dias)
        {
            Dias = dias;
        }

        public (int anos, int mess, int dias) Calcular()
        {
            Validar();
            var anos = Dias / 365;

            var meses = (Dias % 365) / 30;

            var dias = (Dias % 365) % 30;

            return (anos, meses, dias);
        }

        private void Validar()
        {
            if (Dias < 0)
                throw new ArgumentException();
        }
    }
}
