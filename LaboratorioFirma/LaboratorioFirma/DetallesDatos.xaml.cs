using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LaboratorioFirma
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetallesDatos : ContentPage
    {
        byte[] photo;
        public DetallesDatos(byte[] foto)
        {
            InitializeComponent();
            photo = foto;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Stream stream = new MemoryStream(photo);
            foto.Source = ImageSource.FromStream(() => stream);
        }
    }
}