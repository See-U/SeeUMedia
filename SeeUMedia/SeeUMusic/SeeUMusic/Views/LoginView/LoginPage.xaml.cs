using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using SeeUMedia.ViewModels.LoginVM;
using System;
using System.Globalization;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SeeUMedia.Views.LoginView
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : PopupPage
	{
        public LoginPage()
        {
            InitializeComponent();
			BindingContext = new LoginViewModel();
		}

		async void Button_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopPopupAsync();
		}
	}

	/// <summary>
	/// Converts an Entry's Text.Length into a 'flag'
	///  * Entry is empty, returns 1
	/// 
	/// </summary>
	public class MultiTriggerConverter : IValueConverter
	{
		public object Convert(object value, Type targetType,
			object parameter, CultureInfo culture)
		{
			var cnt = (int)value;
			if (cnt > 0)
				return true;    // data has been entered
			else
				return false;   // input is empty
		}

		public object ConvertBack(object value, Type targetType,
			object parameter, CultureInfo culture)
		{
			throw new NotSupportedException();
		}
	}
}