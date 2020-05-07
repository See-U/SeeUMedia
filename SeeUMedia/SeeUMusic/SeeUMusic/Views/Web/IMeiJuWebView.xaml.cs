using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeeUMedia.Views.Web
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class IMeiJuWebView : ContentPage
    {
        public IMeiJuWebView()
        {
            InitializeComponent();
            Browser.Source = "https://www.imeiju.io/";
            //Label header = new Label
            //{
            //    Text = "WebView",
            //    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            //    HorizontalOptions = LayoutOptions.Center
            //};

            //WebView webView = new WebView
            //{
            //    Source = new UrlWebViewSource
            //    {
            //        Url = "https://www.imeiju.io/",
            //    },
            //    VerticalOptions = LayoutOptions.FillAndExpand
            //};

            //// Accomodate iPhone status bar.
            ////this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            //// Build the page.
            //this.Content = new StackLayout
            //{
            //    Children =
            //    {
            //        header,
            //        webView
            //    }
            //};
        }

        private void backClicked(object sender, EventArgs e)

        {

            //check to see if there is anywhere to go back to

            if (Browser.CanGoBack)
            {

                Browser.GoBack();

            }
            else
            { //if not, leave the view

                //Navigation.PopAsync();
                Browser.Reload();
            }

        }

        private void forwardClicked(object sender, EventArgs e)

        {

            if (Browser.CanGoForward)
            {

                Browser.GoForward();

            }
        }

        private void refreshClicked(object sender, EventArgs e)
        {
            Browser.Reload();
        }
    }
}