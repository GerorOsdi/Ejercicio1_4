using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Ejercicio1_4.Models;

namespace Ejercicio1_4.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class regPhotos : ContentPage
    {
        public regPhotos()
        {
            InitializeComponent();
        }

        private async void lstPhotos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
            {
                Photos itemSelc = e.CurrentSelection[0] as Photos;

                bool rest = await DisplayAlert("Aviso", "Quiere ver la foto: "+itemSelc.nombrePhoto, "Aceptar", "Cancelar");

                if (rest == true)
                {
                    await Navigation.PushAsync(new View.ViewPhoto(itemSelc.bytePhoto));
                }
                else
                {
                    rest = false;
                }
            }
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            lstPhotos.ItemsSource = await App.dbPhoto.getPhotos();
        }
    }
}