using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TD1_Xamarin.ViewModels;
using Xamarin.Forms;

namespace TD1_Xamarin.Views
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            BindingContext = ((ViewModelLocator)Application.Current.Resources["Locator"]).Main;
        }
	}
}
