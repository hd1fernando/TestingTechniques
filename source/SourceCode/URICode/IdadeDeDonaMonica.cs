using System;

namespace SourceCode.URICode
{
    /// <summary>
    /// Fonte: https://www.urionlinejudge.com.br/judge/pt/problems/view/3047
    /// </summary>
    public class IdadeDeDonaMonica
    {
        public int Monica { get; }
        public int FilhoA { get; }
        public int FilhoB { get; }
        public IdadeDeDonaMonica(int monica, int filhoA, int filhoB)
        {
            Monica = monica;
            FilhoA = filhoA;
            FilhoB = filhoB;
            Validar();
        }

        private void Validar()
        {
            if (IdadeDonaMonicaEhInvalida()
                || IdadeFilhoEhIvalido(FilhoA)
                || IdadeFilhoEhIvalido(FilhoB)
                || FilhoA == FilhoB)
                throw new InvalidOperationException();
        }

        private bool IdadeFilhoEhIvalido(int filho)
            => filho < 1 || filho >= Monica;

        private bool IdadeDonaMonicaEhInvalida()
            => Monica is (< 40 or > 110);

        public int IdadeDoFilhoMaisVelho()
            => Monica - (FilhoA + FilhoB);
    }
}
