using Finance.Model;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Finance.View
{
	public partial class PostPage : ContentPage
	{
		public PostPage()
		{
			InitializeComponent();
			Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(this, true);
		}

		public PostPage(Item item)
		{
			InitializeComponent();

			try
			{
				//throw (new Exception("Exception message"));

				Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(this, true);
				webView.Source = item.ItemLink;

				var properties = new Dictionary<string, string>
				{
					{ "Blog_Post_Opened",$"{item.Title}"}
				};
				TrackEvent(properties);
			}
			catch (Exception ex)
			{
				var properties = new Dictionary<string, string>
				{
					{ "Blog_Post",$"{item.Title}"}
				};
				TrackError(ex, properties);
			}
		}

		private async void TrackEvent(Dictionary<string, string> properties)
		{
			if (await Analytics.IsEnabledAsync())
				Analytics.TrackEvent("Blog_Post_Opened", properties);
		}

		private async void TrackError(Exception ex, Dictionary<string, string> properties)
		{
			if (await Crashes.IsEnabledAsync())
				Crashes.TrackError(ex, properties);
		}
	}
}