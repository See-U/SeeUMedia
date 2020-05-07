using SeeUMedia.Controls;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeeUMedia.Views.VideoView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VideoPage:ContentPage 
    {
        public VideoPage()
        {
            InitializeComponent();
        }

        void OnAspectSelectedIndexChanged(object sender, EventArgs e)
        {
            mediaElement.Aspect = (Aspect)(sender as EnumPicker).SelectedItem;
        }
    }
}