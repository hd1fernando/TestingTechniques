using System;

namespace SourceCode
{
    public class Ano
    {
        public DateTime Valor { get; }

        public Ano(DateTime valor)
        {
            Valor = valor;
        }

        public bool AnoBissexto()
        {
            var ano = Valor.Year;
            if (ano % 400 == 0)
                return true;

            if (ano % 100 == 0)
                return false;

            return ano % 4 == 0;
        }
    }
}
