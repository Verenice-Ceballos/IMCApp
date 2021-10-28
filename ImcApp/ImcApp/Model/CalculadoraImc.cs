using System;
using System.Collections.Generic;
using System.Text;

namespace ImcApp.Model
{
    public class CalculadoraImc
    {
        public decimal Peso { get; set; }
        public decimal Estatura { get; set; }

        public decimal Imc
        {
            get
            {
                return Peso / (Estatura * Estatura);
            }
        }

        public enum EstadoNutricional
        {
            PesoBajo,
            PesoNormal,
            SobrePeso,
            Obesidad,
            ObesidadExtrema
        }
        public EstadoNutricional SituacionNutricional
        {
            get
            {
                decimal imc = Imc;
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
        public CalculadoraImc(decimal peso, decimal estatura)
        {
            Peso = peso;
            Estatura = estatura;
        }


    }
}
