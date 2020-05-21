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
        bool polling = true;

        protected override void OnAppearing()
        {
            base.OnAppearing();
            polling = true;
            Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (mediaElement.CurrentState == MediaElementState.Playing)
                    {
                        positionSlider.Maximum = Convert.ToDouble(mediaElement.Duration?.TotalSeconds.ToString());
                        positionLabel.Text = mediaElement.Position.ToString("hh\\:mm\\:ss");
                        positionSlider.Value = mediaElement.Position.TotalSeconds;
                    }
                });
                return polling;
            });

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            polling = false;
        }

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

        private void OnPositionSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (mediaElement.CurrentState == MediaElementState.Playing)
            {
                mediaElement.Pause();
            }
            mediaElement.Position = TimeSpan.FromSeconds(positionSlider.Value); ;
            mediaElement.Play();
            positionLabel.Text = mediaElement.Position.ToString("hh\\:mm\\:ss");
        }

        private void positionSlider_DragCompleted(object sender, EventArgs e)
        {
            mediaElement.Position = mediaElement.Position + TimeSpan.FromSeconds(1000);
            positionLabel.Text = mediaElement.Position.ToString("hh\\:mm\\:ss");
            mediaElement.Play();
        }

        private void positionSlider_DragStarted(object sender, EventArgs e)
        {
            if (mediaElement.CurrentState == MediaElementState.Playing)
            {
                mediaElement.Pause();
            }
        }
    }
}