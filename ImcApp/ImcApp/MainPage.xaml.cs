using ImcApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ImcApp
{
    public partial class MainPage : ContentPage
    {
        private CalculadoraImc imc;

        public MainPage()
        {
            InitializeComponent();
            LimpiarIU();

        }

        

        private void CalcularButton_Clicked(object sender, EventArgs e)
        {
            decimal peso;
            decimal estatura;
            bool pesoEsConvertible = decimal.TryParse(PesoEntry.Text, out peso);
            bool estaturaEsConvertible = decimal.TryParse(EstaturaEntry.Text, out estatura);
            if (pesoEsConvertible && estaturaEsConvertible)
            {
                CalculadoraImc cimc = new CalculadoraImc(peso, estatura);
                ImcLabel.Text = string.Format("{0:F4}", cimc.Imc);
                SituacionNutricionalLabel.Text =
                    GetEstadoNutricional(cimc.SituacionNutricional);
            }
            else
            {
                DisplayAlert(
                    "Alerta",
                      "El peso y la estatura deben ser valores numéricos.",
                "Aceptar"
            );
            }
        }

        private void LimpiarButton_Clicked(object sender, EventArgs e)
        {
            LimpiarIU();
        }
        private string GetEstadoNutricional(CalculadoraImc.EstadoNutricional estado)
        {
            switch (estado)
            {
                case CalculadoraImc.EstadoNutricional.PesoBajo:
                    return "Peso bajo";
                case CalculadoraImc.EstadoNutricional.PesoNormal:
                    return "Peso normal";
                case CalculadoraImc.EstadoNutricional.SobrePeso:
                    return "Sobrepeso";
                case CalculadoraImc.EstadoNutricional.Obesidad:
                    return "Obesidad";
                case CalculadoraImc.EstadoNutricional.ObesidadExtrema:
                    return "Obesidad extrema";
                default:
                    return string.Empty;
            }
        }
        private void LimpiarIU()
        {
            PesoEntry.Text = string.Empty;
            EstaturaEntry.Text = string.Empty;
            ImcLabel.Text = string.Empty;
            SituacionNutricionalLabel.Text = string.Empty;
        }

    }
}

