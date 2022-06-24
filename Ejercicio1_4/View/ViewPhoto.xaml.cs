using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Ejercicio1_4.Conver;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio1_4.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewPhoto : ContentPage
    {
        object photo;
        public ViewPhoto(byte[] FotoView)
        {
            InitializeComponent();
            photo = FotoView;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ImageSource recurso = null;
            if (photo != null)
            {
                byte[] byteImage = (byte[])photo;
                recurso = ImageSource.FromStream(() => new MemoryStream(byteImage));
                PhotoView1.Source = recurso;
            }
        }
    }

}