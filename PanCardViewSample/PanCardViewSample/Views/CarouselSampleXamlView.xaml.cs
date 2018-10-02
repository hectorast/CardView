using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading.Tasks;

namespace PanCardViewSample.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CarouselSampleXamlView : ContentPage
    {
        async void Handle_Refreshing(object sender, System.EventArgs e)
        {
            await Task.Delay(1000);
            Listview.IsRefreshing = false;
        }

		public CarouselSampleXamlView()
		{
			InitializeComponent();
        }
    }
}
