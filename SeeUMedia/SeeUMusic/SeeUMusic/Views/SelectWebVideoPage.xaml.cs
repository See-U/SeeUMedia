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
    public partial class SelectWebVideoPage : ContentPage
    {
        public SelectWebVideoPage()
        {
            InitializeComponent();
        }

        private void OnCollectionViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                string key = ((string)e.CurrentSelection.FirstOrDefault()).Replace(" ", string.Empty).Replace("'", string.Empty);
                mediaElement.Source = (UriMediaSource)Application.Current.Resources[key];
            }
        }
    }
}