using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Xamarin.Forms;
using ImcApp.Models;

namespace ImcApp.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private decimal _peso;
        private decimal _estatura;
        private decimal _imc;
        private string _situacionNutricional;
        private Command _calcularCommand;
        private Command _limpiarCommand;

        public decimal Peso
        {
            get => _peso;
            set
            {
                if (_peso != value)
                {
                    _peso = value;
                    OnPropertyChanged("Peso");
                    CalcularCommand.ChangeCanExecute();
                }
            }
        }



        public decimal Estatura
        {
            get => _estatura;
            set
            {
                if (_estatura != value)
                {
                    _estatura = value;
                    OnPropertyChanged("Estatura");
                    CalcularCommand.ChangeCanExecute();
                }
            }
        }


        public decimal Imc
        {
            get => _imc;
           private set
            {
                if (_imc != value)
                {
                    _imc = value;
                    OnPropertyChanged("Imc");
                }
            }
        }

        public string SituacionNutricional
        {
            get => _situacionNutricional;
            private set
            {
                if (_situacionNutricional != value)
                {
                    _situacionNutricional = value;
                    OnPropertyChanged("SituacionNutricional");
                }
            }
        }

        public Command CalcularCommand
        {
            get
            {
                if (_calcularCommand == null)
                {
                    _calcularCommand = new Command(CalcularImc, CanCalculate);
                }
                return _calcularCommand;
            }

        }

        public Command LimpiarCommand
        {
            get
            {
                if (_limpiarCommand == null)
                {
                    _limpiarCommand = new Command(LimpiarUI);
                }
                return _limpiarCommand;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void CalcularImc()
        {
            Imc = CalculadoraImc.IndiceDeMasaCorporal(Peso, Estatura);
            SituacionNutricional = GetEstadoNutricional(CalculadoraImc.SituacionNutricional(Imc));
        }

        private bool CanCalculate()
        {
            return Peso > 0M && Estatura > 0M;
        }

        private void LimpiarUI()
        {
            Peso = 0;
            Estatura = 0;
            Imc = 0;
            SituacionNutricional = string.Empty;
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
    }
}
