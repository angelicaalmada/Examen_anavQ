using Examen_anavQ.VistaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Examen_anavQ.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VcalcularIMC : ContentPage
    {
        public VcalcularIMC()
        {
            InitializeComponent();
            BindingContext = new VMcalcularIMC(Navigation);
        }
    }
}