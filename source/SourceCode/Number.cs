namespace SourceCode
{

    public struct Number
    {
        public int Num;

        public Number(int num)
        {
            Num = num;
        }

        public static implicit operator Number(int num)
            => new Number(num);

        /// <summary>
        /// * Divisível por 1 e por ele mesmo.
        /// * > 1
        /// Obs: O número 2 é o único par divisível por 2
        /// </summary>
        /// <returns></returns>
        public bool IsPrime()
        {
            if (Num == 2)
                return true;

            if (Num < 3)
                return false;

            for (int i = 2; i < Num; i++)
            {
                if (Num % i == 0)
                    return false;
            }

            return true; ;
        }
    }
}
