using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Examen_anavQ.VistaModelo
{
    public class VMcalcularIMC : BaseViewModel
    {
        #region VARIABLES
        string _Mensaje;
        string _Imagen;

        double _Peso;
        double _Altura;
        double _Latidos;

        double _Imc;
        #endregion
        #region CONSTRUCTOR
        public VMcalcularIMC(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region OBJETOS
        public string Mensaje
        {
            get { return _Mensaje; }
            set { SetValue(ref _Mensaje, value); }
        }
        public double Peso
        {
            get { return _Peso; }
            set { SetValue(ref _Peso, value); }
        }
        public double Altura
        {
            get { return _Altura; }
            set { SetValue(ref _Altura, value); }
        }
        public double Latidos
        {
            get { return _Latidos; }
            set { SetValue(ref _Latidos, value); }
        }
        public double Imc
        {
            get { return _Imc; }
            set { SetValue(ref _Imc, value); }
        }
        public string Imagen
        {
            get { return _Imagen; }
            set { SetValue(ref _Imagen, value); }
        }
        #endregion
        #region PROCESOS
        public async Task ProcesoAsyncrono()
        {

        }
        public void CalcularIMC(double p, double a)
        {
            Imc = (Peso) /(Math.Pow(a, 2));
        }

        public async void BtnCalcularIMC()
        {
            if (Peso > 0 && Altura > 0)
            {

                CalcularIMC(Peso, Altura);

                if (Imc < 18.5)
                {
                    _Imagen = "https://i.ibb.co/55SfTVK/crisis.png";
                    Mensaje = "Bajo insuficiente";
                }
                else
                {
                    if (Imc >= 18.5 && Imc < 24.9)
                    {
                        Mensaje = "Peso Normal o saludable";
                        _Imagen = "https://i.ibb.co/7CJVtRX/comprobar.png";
                    }
                    else
                    {
                        if (Imc >= 24.9 && Imc <= 29.9)
                        {
                            Mensaje = "Sobrepeso";
                            _Imagen = "https://i.ibb.co/55SfTVK/crisis.png";
                        }
                        else
                        {
                            Mensaje = "Obesidad";
                            _Imagen = "https://i.ibb.co/55SfTVK/crisis.png";
                        }
                    }
                }
            }
            else {
                double totalLatidos = Latidos * 4;
                if (totalLatidos < 60)
                {
                    Mensaje = "FC Baja";
                }
                else if (totalLatidos >= 60 && totalLatidos <= 100)
                {
                    Mensaje = "FC Normal";

                }
                else
                    Mensaje = "FC Alta";
                {
                }
            }
            await DisplayAlert("Estado", Mensaje, "Salir");
        }

        #endregion
        #region COMANDOS
        public ICommand ProcesoAsyncommand => new Command(async () => await ProcesoAsyncrono());
        public ICommand CalcularIMCCommand => new Command(BtnCalcularIMC);
        #endregion

    }
}
