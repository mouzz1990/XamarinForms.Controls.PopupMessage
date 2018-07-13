using PopupMessage.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PopupMessage
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private async void btnShowPopup_Clicked(object sender, EventArgs e)
        {
            await popMenu.ShowPopup();
        }

        private async void btnHide_Clicked(object sender, EventArgs e)
        {
            await popMenu.HidePopup();
        }

        private void btnChangeImageAnchor_Clicked(object sender, EventArgs e)
        {
            popMenu.ImagePosition =
                popMenu.ImagePosition == ImageAnchor.Left ? ImageAnchor.Right : ImageAnchor.Left;
        }
    }
}
