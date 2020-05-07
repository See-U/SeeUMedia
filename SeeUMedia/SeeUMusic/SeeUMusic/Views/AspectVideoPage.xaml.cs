using SeeUMedia.Controls;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeeUMedia.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AspectVideoPage : ContentPage
    {
        public AspectVideoPage()
        {
            InitializeComponent();
        }

        void OnAspectSelectedIndexChanged(object sender, EventArgs e)
        {
            mediaElement.Aspect = (Aspect)(sender as EnumPicker).SelectedItem;
        }
    }
}