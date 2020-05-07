using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeeUMedia.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomVolumePage : ContentPage
    {
        public CustomVolumePage()
        {
            InitializeComponent();
        }

        void OnPlayPauseButtonClicked(object sender, EventArgs args)
        {
            if (mediaElement.CurrentState == MediaElementState.Closed ||
                mediaElement.CurrentState == MediaElementState.Stopped ||
                mediaElement.CurrentState == MediaElementState.Paused)
            {
                mediaElement.Play();
            }
            else if (mediaElement.CurrentState == MediaElementState.Playing)
            {
                mediaElement.Pause();
            }
        }

        void OnStopButtonClicked(object sender, EventArgs args)
        {
            mediaElement.Stop();
        }
    }
}