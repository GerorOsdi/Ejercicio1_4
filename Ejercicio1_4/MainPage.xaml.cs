using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;
using Xamarin.Essentials;
using System.IO;

using Ejercicio1_4.Models;

namespace Ejercicio1_4
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {

        Plugin.Media.Abstractions.MediaFile PhotoFile = null;
        public MainPage()
        {
            InitializeComponent();

        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            if(PhotoFile == null)
            {
                await DisplayAlert("Aviso","No se ha tomado la fotografía","Aceptar");

                return;
            }

            var varPhoto = new Photos
            {
                Id = 0,
                nombrePhoto = txtNombrePhoto.Text,
                descPhoto = txtDescPhoto.Text,
                bytePhoto = ConvertImageToByteArray()
            };


            var resul = await App.dbPhoto.savePhoto(varPhoto);

            if (resul > 0) {
                await DisplayAlert("Notificacion", "Dato Guardado con Exito", "Aceptar");
            }
            else
            {
                await DisplayAlert("Erro", "Dato no se pudo almacenar", "Aceptar");
                limpiar();
            }

        }

        private async void btnPic_Clicked(object sender, EventArgs e)
        {
            PhotoFile = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "MisFotos",
                Name = "Prueba1.jpg",
                SaveToAlbum = true,
            });

            if (PhotoFile != null)
            {
                viewPhoto.Source = ImageSource.FromStream(() => { return PhotoFile.GetStream(); });
            }
        }

        private Byte[] ConvertImageToByteArray() { 
            if(PhotoFile != null)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    Stream stream = PhotoFile.GetStream();
                    stream.CopyTo(memory);
                    return memory.ToArray();
                }
            }
            return null;
        }

        private void limpiar() {
            txtNombrePhoto.Text = "";
            txtDescPhoto.Text = "";
            viewPhoto = null;
        }

        private async void btnlstPhotos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.regPhotos());
        }
    }
}
