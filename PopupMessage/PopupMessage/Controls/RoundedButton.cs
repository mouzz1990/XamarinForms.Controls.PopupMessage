using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PopupMessage.Controls
{
    public class RoundedButton : Button
    {
        public RoundedButton()
        {
            Elevation = 20;
        }

        public int Elevation { get; set; }
    }
}
