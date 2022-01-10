using System;
using System.Collections.Generic;
using System.Text;

namespace ImcApp.Models
{
    public class CalculadoraImc
    {
        //calcula el indice de masa corporal
        public static decimal IndiceDeMasaCorporal(decimal peso, decimal estatura)
             => peso / (estatura * estatura);

        public enum EstadoNutricional
        {
            PesoBajo,
            PesoNormal,
            SobrePeso,
            Obesidad,
            ObesidadExtrema
        }

        public static EstadoNutricional SituacionNutricional(decimal imc)
        {
            if (imc < 18.5M)
            {
                    return EstadoNutricional.PesoBajo;
                }
                else if (imc < 25.0M)
                {
                    return EstadoNutricional.PesoNormal;
                }
                else if (imc < 30.0M)
                {
                    return EstadoNutricional.SobrePeso;
                }
                else if (imc < 40.0M)
                {
                    return EstadoNutricional.Obesidad;
                }
                else
                {
                    return EstadoNutricional.ObesidadExtrema;
            }
        }
        
    }
}
