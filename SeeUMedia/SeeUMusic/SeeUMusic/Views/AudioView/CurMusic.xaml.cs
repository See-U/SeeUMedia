using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
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
    public partial class CurMusic : PopupPage
    {
        public CurMusic()
        {
            InitializeComponent();
            SongViewModel songViewModel = new SongViewModel(mediaElement);
            BindingContext = songViewModel;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync();
        }
    }
}