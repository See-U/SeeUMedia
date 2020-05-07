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
    public partial class NovelWebView : ContentPage
    {
        public NovelWebView()
        {
            InitializeComponent();
            NovelBrowser.Source = "http://www.zongheng.com/";
        }
    }
}