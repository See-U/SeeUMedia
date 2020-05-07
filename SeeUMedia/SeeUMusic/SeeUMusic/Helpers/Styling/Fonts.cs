using Xamarin.Forms;

namespace SeeUMedia.Helpers.Styling
{
	public static class Fonts
	{
		public static string FontAwesome = Device.OnPlatform("FontAwesome", "fontawesome.ttf", null);
	}
}
