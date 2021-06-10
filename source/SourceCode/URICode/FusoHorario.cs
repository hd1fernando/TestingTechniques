﻿using System;

namespace SourceCode.URICode
{
    /// <summary>
    /// Fonte: https://www.urionlinejudge.com.br/judge/pt/problems/view/2057
    /// </summary>
    public class FusoHorario
    {
        public int HorarioDeSaida { get; }
        public int TempoDeViagem { get; }
        public int FusoHorarioDestino { get; }

        public FusoHorario(int horararioDeSaida, int tempoDeViagem, int fusoHorarioDestino)
        {
            HorarioDeSaida = horararioDeSaida;
            TempoDeViagem = tempoDeViagem;
            FusoHorarioDestino = fusoHorarioDestino;
            Validar();
        }

        private void Validar()
        {
            if (HorarioDeSaida is (< 0 or > 23)
                || TempoDeViagem is (< 1 or > 12)
                || FusoHorarioDestino is (< -5 or > 5))
                throw new InvalidOperationException();
        }
    }
}
