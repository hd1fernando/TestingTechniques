using System;

namespace SourceCode.URICode
{
    /// <summary>
    /// Font: https://www.urionlinejudge.com.br/judge/pt/problems/view/1005
    /// </summary>
    public class Media1
    {

        public double NumA { get; }
        public double NumB { get; }
        public Media1(double numA, double numB)
        {
            NumA = numA;
            NumB = numB;
        }


        public double Calcular()
        {
            Validar();
            var result = (NumA * 3.5 + NumB * 7.5) / 11;
            return double.Parse(result.ToString("n5"));
        }

        private void Validar()
        {
            if (NumA is (< 0.0 or > 10.0) || NumB is (< 0.0 or > 10.0))
                throw new ArgumentException();
        }
    }
}
