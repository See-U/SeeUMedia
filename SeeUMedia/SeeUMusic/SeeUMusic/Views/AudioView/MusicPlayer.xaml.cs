using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using SeeUMedia.ViewModels.SongVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeeUMedia.Views.AudioView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MusicPlayer :ContentPage
    {
        public MusicPlayer()
        {
            InitializeComponent();
            SongViewModel songViewModel = new SongViewModel(mediaElement);
            BindingContext = songViewModel;
        }

        private async void CurMusic_Tapped(object sender, EventArgs e)
        {
            PopupPage page = (PopupPage)Activator.CreateInstance(new CurMusic().GetType());
            await PopupNavigation.Instance.PushAsync(new CurMusic());
        }
    }
}