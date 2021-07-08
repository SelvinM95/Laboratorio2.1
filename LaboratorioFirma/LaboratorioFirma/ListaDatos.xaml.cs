using LaboratorioFirma.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LaboratorioFirma
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaDatos : ContentPage
    {
        public ListaDatos()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var listapersonas = await App.SQLiteDB.GetDatosAsync();
            if (listapersonas != null)
            {
                lstPersonas.ItemsSource = listapersonas;
            }

        }

        private async void lstPersonas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var obj = (Datos)e.SelectedItem;

            byte[] foto = obj.image;

            var detail = new Datos
            {
                nombre = obj.nombre,
                descripcion = obj.descripcion,
            };

            var detalles = new DetallesDatos(foto);
            detalles.BindingContext = detail;
            await Navigation.PushAsync(detalles);
        }
    }
}