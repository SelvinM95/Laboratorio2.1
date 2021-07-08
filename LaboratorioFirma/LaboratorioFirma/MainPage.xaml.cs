using LaboratorioFirma.Data;
using Plugin.Media.Abstractions;
using SignaturePad.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LaboratorioFirma
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async  void guardarDatos_Clicked(object sender, EventArgs e)
        {
            var image = await signatureSample.GetImageStreamAsync(SignatureImageFormat.Png);
 
            byte[] img = GetImageStreamAsBytes(image);

            Datos datos = new Datos
            {
                nombre = nombre.Text,
                descripcion = descrip.Text,
                image = img
            }; 
            await App.SQLiteDB.SaveDatosAsync(datos); 
            await DisplayAlert("Registro", "Registro guardado Correctamente", "Ok");
            nombre.Text = "";
            descrip.Text = "";
            signatureSample.Clear();
        } 
         
        private byte[] GetImageStreamAsBytes(Stream input)
        {
            var buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        } 
        private async void verLista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaDatos());
        }
    }
}
