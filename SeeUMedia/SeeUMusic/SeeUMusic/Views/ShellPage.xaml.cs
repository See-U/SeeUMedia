using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using SeeUMedia.Models.SongModel;
using SeeUMedia.ViewModels.SongVM;
using SeeUMedia.Views.AudioView;
using SeeUMedia.Views.VideoView;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace SeeUMedia.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShellPage : Xamarin.Forms.TabbedPage
	{
        // ICommand implementations
        public ICommand NavigateCommand { get; private set; }

		public ShellPage()
        {
            InitializeComponent();
			On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
			NavigateCommand = new Command<Type>(async (Type pageType) =>
			{
				PopupPage page = (PopupPage)Activator.CreateInstance(pageType);
				await PopupNavigation.Instance.PushAsync(page);
			});
			//Main();
			//http://music.163.com/api/playlist/detail?id=387699500
			//http://music.163.com/song/media/outer/url?id=281951.mp3
			//https://music.163.com/outchain/player?type=2&id=34899758&auto=1&height=66&bg=e8e8e8

		}

		private async void Button_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new Page());
		}

		//private void Home_Tapped(object sender, EventArgs e)
		//{
		//	cvContentHolder.Content = new MusicPlayer();
		//	Home_StackLayout.Opacity = 0.5;
		//	//Home_StackLayout.BackgroundColor = Color.LightPink;
		//}

		//private void Video_Tapped(object sender, EventArgs e)
		//{
		//	cvContentHolder.Content = new VideoPage();
		//	Home_StackLayout.Opacity = 0.5;
		//}

		//private void Audio_Tapped(object sender, EventArgs e)
		//{

		//}

		//private void Novel_Tapped(object sender, EventArgs e)
		//{

		//}
	}
}